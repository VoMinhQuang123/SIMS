using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using SIMS.Controllers;

namespace SIMS.Tests
{
    public class Xunit_DashBoard_StudentController
    {
        private readonly DashBoard_StudentController _controller;

        public Xunit_DashBoard_StudentController()
        {
            _controller = new DashBoard_StudentController();

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
        public void Index_ReturnsView()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view name
            Assert.Null(viewResult.Model); // No model passed
        }

        [Fact]
        public void Controller_CanBeInstantiated()
        {
            // Assert that controller is instantiated properly
            Assert.NotNull(_controller);
            Assert.IsType<DashBoard_StudentController>(_controller);
        }

        [Fact]
        public void Controller_InheritsFromController()
        {
            // Assert that controller inherits from Controller base class
            Assert.IsAssignableFrom<Controller>(_controller);
        }
    }
}
