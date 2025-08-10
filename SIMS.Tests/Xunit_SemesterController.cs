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
    public class Xunit_SemesterController
    {
        private readonly Mock<ISemester> _mockSemesterRepository;
        private readonly Service_Semester _semesterService;
        private readonly SemesterController _controller;

        public Xunit_SemesterController()
        {
            _mockSemesterRepository = new Mock<ISemester>();
            _semesterService = new Service_Semester(_mockSemesterRepository.Object);
            _controller = new SemesterController(_semesterService);

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
        public async Task IndexAsync_ReturnsViewWithSemesters()
        {
            // Arrange
            var semesters = new List<Semester>
            {
                new Semester { SemesterID = 1, Name = "Semester 1" },
                new Semester { SemesterID = 2, Name = "Semester 2" }
            };

            _mockSemesterRepository.Setup(x => x.GetAllSemesteresAsync()).ReturnsAsync(semesters);

            // Act
            var result = await _controller.IndexAsync();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Semester>>(viewResult.Model);
            Assert.Equal(2, model.Count);
            Assert.Equal(semesters, model);
        }

        [Fact]
        public async Task IndexAsync_EmptySemesters_ReturnsViewWithEmptyList()
        {
            // Arrange
            var semesters = new List<Semester>();
            _mockSemesterRepository.Setup(x => x.GetAllSemesteresAsync()).ReturnsAsync(semesters);

            // Act
            var result = await _controller.IndexAsync();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Semester>>(viewResult.Model);
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
            Assert.IsType<SemesterController>(_controller);
        }

        [Fact]
        public async Task IndexAsync_CallsServiceCorrectly()
        {
            // Arrange
            var semesters = new List<Semester>();
            _mockSemesterRepository.Setup(x => x.GetAllSemesteresAsync()).ReturnsAsync(semesters);

            // Act
            await _controller.IndexAsync();

            // Assert
            _mockSemesterRepository.Verify(x => x.GetAllSemesteresAsync(), Times.Once);
        }

        [Fact]
        public void Controller_InheritsFromController()
        {
            // Assert that controller inherits from Controller base class
            Assert.IsAssignableFrom<Controller>(_controller);
        }
    }
}
