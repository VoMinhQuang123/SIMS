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
    public class Xunit_CourseController
    {
        private readonly Mock<ICourse> _mockCourseRepository;
        private readonly Service_Course _courseService;
        private readonly CourseController _controller;

        public Xunit_CourseController()
        {
            _mockCourseRepository = new Mock<ICourse>();
            _courseService = new Service_Course(_mockCourseRepository.Object);
            
            // Use Mock.Of to create a simple mock context without constructor issues
            var mockContext = Mock.Of<SIMS.BDContext.SIMSDBContext>();
            _controller = new CourseController(_courseService, mockContext);

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
        public async Task Index_ReturnsViewWithCourses()
        {
            // Arrange
            var courses = new List<Course>
            {
                new Course { CourseID = 1, NameCourse = "Course 1", TypeID = 1 },
                new Course { CourseID = 2, NameCourse = "Course 2", TypeID = 2 }
            };

            _mockCourseRepository.Setup(x => x.GetAllCoursesAsync()).ReturnsAsync(courses);

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Course>>(viewResult.Model);
            Assert.Equal(2, model.Count);
            Assert.Equal(courses, model);
        }

        [Fact]
        public async Task Index_EmptyCourses_ReturnsViewWithEmptyList()
        {
            // Arrange
            var courses = new List<Course>();
            _mockCourseRepository.Setup(x => x.GetAllCoursesAsync()).ReturnsAsync(courses);

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Course>>(viewResult.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Controller_HasCorrectDependencies()
        {
            // Assert that controller is instantiated properly with services
            Assert.NotNull(_controller);
            Assert.IsType<CourseController>(_controller);
        }

        [Fact]
        public async Task Index_CallsServiceCorrectly()
        {
            // Arrange
            var courses = new List<Course>();
            _mockCourseRepository.Setup(x => x.GetAllCoursesAsync()).ReturnsAsync(courses);

            // Act
            await _controller.Index();

            // Assert
            _mockCourseRepository.Verify(x => x.GetAllCoursesAsync(), Times.Once);
        }

        [Fact]
        public void Controller_InheritsFromController()
        {
            // Assert that controller inherits from Controller base class
            Assert.IsAssignableFrom<Controller>(_controller);
        }
    }
}
