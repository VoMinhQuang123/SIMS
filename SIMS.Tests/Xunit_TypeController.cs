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
    public class Xunit_TypeController
    {
        private readonly Mock<IType> _mockTypeRepository;
        private readonly Service_Type _typeService;
        private readonly TypeController _controller;

        public Xunit_TypeController()
        {
            _mockTypeRepository = new Mock<IType>();
            _typeService = new Service_Type(_mockTypeRepository.Object);
            _controller = new TypeController(_typeService);

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
        public async Task IndexAsync_ReturnsViewWithTypes()
        {
            // Arrange
            var types = new List<SIMS.BDContext.Entity.Type>
            {
                new SIMS.BDContext.Entity.Type { TypeID = 1, TypeName = "Type 1" },
                new SIMS.BDContext.Entity.Type { TypeID = 2, TypeName = "Type 2" }
            };

            _mockTypeRepository.Setup(x => x.GetAllTypesAsync()).ReturnsAsync(types);

            // Act
            var result = await _controller.IndexAsync();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<SIMS.BDContext.Entity.Type>>(viewResult.Model);
            Assert.Equal(2, model.Count);
            Assert.Equal(types, model);
        }

        [Fact]
        public async Task IndexAsync_EmptyTypes_ReturnsViewWithEmptyList()
        {
            // Arrange
            var types = new List<SIMS.BDContext.Entity.Type>();
            _mockTypeRepository.Setup(x => x.GetAllTypesAsync()).ReturnsAsync(types);

            // Act
            var result = await _controller.IndexAsync();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<SIMS.BDContext.Entity.Type>>(viewResult.Model);
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
            Assert.IsType<TypeController>(_controller);
        }

        [Fact]
        public async Task IndexAsync_CallsServiceCorrectly()
        {
            // Arrange
            var types = new List<SIMS.BDContext.Entity.Type>();
            _mockTypeRepository.Setup(x => x.GetAllTypesAsync()).ReturnsAsync(types);

            // Act
            await _controller.IndexAsync();

            // Assert
            _mockTypeRepository.Verify(x => x.GetAllTypesAsync(), Times.Once);
        }
    }
}
