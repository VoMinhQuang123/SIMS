using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using SIMS.BDContext.Entity;
using SIMS.Controllers;
using SIMS.Interface;
using SIMS.Service;

namespace SIMS.Tests
{
    public class Xunit_TeacherController
    {
        private readonly Mock<ITeacher> _mockTeacherRepository;
        private readonly Service_Teacher _teacherService;
        private readonly TeacherController _controller;

        public Xunit_TeacherController()
        {
            _mockTeacherRepository = new Mock<ITeacher>();
            _teacherService = new Service_Teacher(_mockTeacherRepository.Object);
            _controller = new TeacherController(_teacherService);

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
        public async Task IndexAsync_ReturnsViewWithTeachers()
        {
            // Arrange
            var teachers = new List<Teacher>
            {
                new Teacher { TeacherID = 1, Name = "Teacher 1" },
                new Teacher { TeacherID = 2, Name = "Teacher 2" }
            };

            _mockTeacherRepository.Setup(x => x.GetAllTeacheresAsync()).ReturnsAsync(teachers);

            // Act
            var result = await _controller.IndexAsync();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Teacher>>(viewResult.Model);
            Assert.Equal(2, model.Count);
            Assert.Equal(teachers, model);
        }

        [Fact]
        public async Task IndexAsync_EmptyTeachers_ReturnsViewWithEmptyList()
        {
            // Arrange
            var teachers = new List<Teacher>();
            _mockTeacherRepository.Setup(x => x.GetAllTeacheresAsync()).ReturnsAsync(teachers);

            // Act
            var result = await _controller.IndexAsync();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Teacher>>(viewResult.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Create_ReturnsView()
        {
            // Act
            var result = _controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view name
        }

        [Fact]
        public void Controller_HasCorrectDependencies()
        {
            // Assert that controller is instantiated properly with services
            Assert.NotNull(_controller);
            Assert.IsType<TeacherController>(_controller);
        }

        [Fact]
        public async Task IndexAsync_CallsServiceCorrectly()
        {
            // Arrange
            var teachers = new List<Teacher>();
            _mockTeacherRepository.Setup(x => x.GetAllTeacheresAsync()).ReturnsAsync(teachers);

            // Act
            await _controller.IndexAsync();

            // Assert
            _mockTeacherRepository.Verify(x => x.GetAllTeacheresAsync(), Times.Once);
        }

        [Fact]
        public void Controller_InheritsFromController()
        {
            // Assert that controller inherits from Controller base class
            Assert.IsAssignableFrom<Controller>(_controller);
        }
    }
}
