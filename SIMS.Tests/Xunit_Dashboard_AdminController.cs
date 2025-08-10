using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using SIMS.BDContext.Entity;
using SIMS.Controllers;
using SIMS.Interface;
using SIMS.Models;
using SIMS.Service;

namespace SIMS.Tests
{
    public class Xunit_Dashboard_AdminController
    {
        private readonly Mock<IAdmin> _mockAdminRepository;
        private readonly Service_Admin _adminService;
        private readonly Dashboard_AdminController _controller;

        public Xunit_Dashboard_AdminController()
        {
            _mockAdminRepository = new Mock<IAdmin>();
            _adminService = new Service_Admin(_mockAdminRepository.Object);
            _controller = new Dashboard_AdminController(_adminService);

            // Setup HttpContext
            var mockHttpContext = new Mock<HttpContext>();
            var mockServiceProvider = new Mock<IServiceProvider>();
            var mockTempDataDictionary = new Mock<ITempDataDictionary>();

            mockHttpContext.Setup(x => x.RequestServices).Returns(mockServiceProvider.Object);
            
            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockHttpContext.Object
            };
            
            _controller.TempData = mockTempDataDictionary.Object;
        }

        [Fact]
        public async Task IndexAdmin_ReturnsViewWithAdminViewModels()
        {
            // Arrange
            var admins = new List<Admin>
            {
                new Admin 
                { 
                    AdminID = 1, 
                    Name = "Admin 1", 
                    Email = "admin1@test.com",
                    Role = "Admin",
                    CreatedAt = DateTime.Now,
                    UserID = 1
                },
                new Admin 
                { 
                    AdminID = 2, 
                    Name = "Admin 2", 
                    Email = "admin2@test.com",
                    Role = "SuperAdmin",
                    CreatedAt = DateTime.Now,
                    UserID = 2
                }
            };

            _mockAdminRepository.Setup(x => x.GetAllAdminsAsync()).ReturnsAsync(admins);

            // Act
            var result = await _controller.IndexAdmin();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<AdminViewModel>>(viewResult.Model);
            Assert.Equal(2, model.Count);
            Assert.Equal("Admin 1", model[0].Name);
            Assert.Equal("admin1@test.com", model[0].Email);
            Assert.Equal("Admin", model[0].Role);
        }

        [Fact]
        public async Task IndexAdmin_EmptyAdmins_ReturnsViewWithEmptyList()
        {
            // Arrange
            var admins = new List<Admin>();
            _mockAdminRepository.Setup(x => x.GetAllAdminsAsync()).ReturnsAsync(admins);

            // Act
            var result = await _controller.IndexAdmin();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<AdminViewModel>>(viewResult.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Index_ReturnsView()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view name
        }

        [Fact]
        public void Controller_HasCorrectDependencies()
        {
            // Assert that controller is instantiated properly with services
            Assert.NotNull(_controller);
            Assert.IsType<Dashboard_AdminController>(_controller);
        }

        [Fact]
        public async Task IndexAdmin_CallsServiceCorrectly()
        {
            // Arrange
            var admins = new List<Admin>();
            _mockAdminRepository.Setup(x => x.GetAllAdminsAsync()).ReturnsAsync(admins);

            // Act
            await _controller.IndexAdmin();

            // Assert
            _mockAdminRepository.Verify(x => x.GetAllAdminsAsync(), Times.Once);
        }

        [Fact]
        public void Controller_InheritsFromController()
        {
            // Assert that controller inherits from Controller base class
            Assert.IsAssignableFrom<Controller>(_controller);
        }
    }
}
