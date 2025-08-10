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
    public class Xunit_TeachingAssignmentController
    {
        private readonly Mock<ITeachingAssignment> _mockAssignmentRepository;
        private readonly Service_TeachingAssignment _assignmentService;
        private readonly TeachingAssignmentController _controller;

        public Xunit_TeachingAssignmentController()
        {
            _mockAssignmentRepository = new Mock<ITeachingAssignment>();
            _assignmentService = new Service_TeachingAssignment(_mockAssignmentRepository.Object);
            _controller = new TeachingAssignmentController(_assignmentService);

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
        public async Task IndexAsync_ReturnsViewWithAssignments()
        {
            // Arrange
            var assignments = new List<TeachingAssignment>
            {
                new TeachingAssignment { AssignmentID = 1, TeacherID = 1, CourseID = 1 },
                new TeachingAssignment { AssignmentID = 2, TeacherID = 2, CourseID = 2 }
            };

            _mockAssignmentRepository.Setup(x => x.GetAllTeachingAssignmentsAsync()).ReturnsAsync(assignments);

            // Act
            var result = await _controller.IndexAsync();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<TeachingAssignment>>(viewResult.Model);
            Assert.Equal(2, model.Count);
            Assert.Equal(assignments, model);
        }

        [Fact]
        public async Task IndexAsync_EmptyAssignments_ReturnsViewWithEmptyList()
        {
            // Arrange
            var assignments = new List<TeachingAssignment>();
            _mockAssignmentRepository.Setup(x => x.GetAllTeachingAssignmentsAsync()).ReturnsAsync(assignments);

            // Act
            var result = await _controller.IndexAsync();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<TeachingAssignment>>(viewResult.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Controller_HasCorrectDependencies()
        {
            // Assert that controller is instantiated properly with services
            Assert.NotNull(_controller);
            Assert.IsType<TeachingAssignmentController>(_controller);
        }

        [Fact]
        public async Task IndexAsync_CallsServiceCorrectly()
        {
            // Arrange
            var assignments = new List<TeachingAssignment>();
            _mockAssignmentRepository.Setup(x => x.GetAllTeachingAssignmentsAsync()).ReturnsAsync(assignments);

            // Act
            await _controller.IndexAsync();

            // Assert
            _mockAssignmentRepository.Verify(x => x.GetAllTeachingAssignmentsAsync(), Times.Once);
        }
    }
}
