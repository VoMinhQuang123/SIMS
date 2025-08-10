using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Moq;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Controllers;
using SIMS.Interface;
using SIMS.Service;

namespace SIMS.Tests
{
    public class Xunit_ClassController
    {
        private readonly Mock<IClass> _mockClassRepository;
        private readonly SIMSDBContext _context;
        private readonly Service_Class _classService;
        private readonly ClassController _controller;

        public Xunit_ClassController()
        {
            _mockClassRepository = new Mock<IClass>();
            
            // Use Mock.Of for SIMSDBContext
            _context = Mock.Of<SIMSDBContext>();
            _classService = new Service_Class(_mockClassRepository.Object, _context);
            _controller = new ClassController(_classService, _context);

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
        public async Task Index_ReturnsViewWithClasses()
        {
            // Arrange
            var classes = new List<Class>
            {
                new Class { ClassID = 1, ClassName = "Class 1", TypeID = 1 },
                new Class { ClassID = 2, ClassName = "Class 2", TypeID = 2 }
            };
            var types = new List<SIMS.BDContext.Entity.Type>
            {
                new SIMS.BDContext.Entity.Type { TypeID = 1, TypeName = "Type 1" },
                new SIMS.BDContext.Entity.Type { TypeID = 2, TypeName = "Type 2" }
            };

            _mockClassRepository.Setup(x => x.GetAllClassesAsync()).ReturnsAsync(classes);
            
            // Mock DbSet for Types
            var mockTypesDbSet = new Mock<DbSet<SIMS.BDContext.Entity.Type>>();
            var queryableTypes = types.AsQueryable();
            mockTypesDbSet.As<IQueryable<SIMS.BDContext.Entity.Type>>().Setup(m => m.Provider).Returns(queryableTypes.Provider);
            mockTypesDbSet.As<IQueryable<SIMS.BDContext.Entity.Type>>().Setup(m => m.Expression).Returns(queryableTypes.Expression);
            mockTypesDbSet.As<IQueryable<SIMS.BDContext.Entity.Type>>().Setup(m => m.ElementType).Returns(queryableTypes.ElementType);
            mockTypesDbSet.As<IQueryable<SIMS.BDContext.Entity.Type>>().Setup(m => m.GetEnumerator()).Returns(queryableTypes.GetEnumerator());
            
            Mock.Get(_context).Setup(x => x.TypesDb).Returns(mockTypesDbSet.Object);

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Class>>(viewResult.Model);
            Assert.Equal(2, model.Count);
            Assert.NotNull(_controller.ViewBag.Types);
        }

        [Fact]
        public async Task Create_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var classModel = new Class { ClassID = 1, ClassName = "Test Class", TypeID = 1 };
            
            var mockClassesDbSet = new Mock<DbSet<Class>>();
            Mock.Get(_context).Setup(x => x.ClassesDb).Returns(mockClassesDbSet.Object);
            Mock.Get(_context).Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _controller.Create(classModel);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            
            // Verify that Add was called
            mockClassesDbSet.Verify(x => x.Add(It.IsAny<Class>()), Times.Once);
            Mock.Get(_context).Verify(x => x.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task Create_InvalidModel_ReturnsIndexViewWithModel()
        {
            // Arrange
            var classModel = new Class();
            _controller.ModelState.AddModelError("ClassName", "Required");
            
            var types = new List<SIMS.BDContext.Entity.Type>
            {
                new SIMS.BDContext.Entity.Type { TypeID = 1, TypeName = "Type 1" }
            };
            var classes = new List<Class>
            {
                new Class { ClassID = 1, ClassName = "Class 1", TypeID = 1 }
            };

            // Mock DbSets
            var mockTypesDbSet = new Mock<DbSet<SIMS.BDContext.Entity.Type>>();
            var queryableTypes = types.AsQueryable();
            mockTypesDbSet.As<IQueryable<SIMS.BDContext.Entity.Type>>().Setup(m => m.Provider).Returns(queryableTypes.Provider);
            mockTypesDbSet.As<IQueryable<SIMS.BDContext.Entity.Type>>().Setup(m => m.Expression).Returns(queryableTypes.Expression);
            mockTypesDbSet.As<IQueryable<SIMS.BDContext.Entity.Type>>().Setup(m => m.ElementType).Returns(queryableTypes.ElementType);
            mockTypesDbSet.As<IQueryable<SIMS.BDContext.Entity.Type>>().Setup(m => m.GetEnumerator()).Returns(queryableTypes.GetEnumerator());
            
            var mockClassesDbSet = new Mock<DbSet<Class>>();
            var queryableClasses = classes.AsQueryable();
            mockClassesDbSet.As<IQueryable<Class>>().Setup(m => m.Provider).Returns(queryableClasses.Provider);
            mockClassesDbSet.As<IQueryable<Class>>().Setup(m => m.Expression).Returns(queryableClasses.Expression);
            mockClassesDbSet.As<IQueryable<Class>>().Setup(m => m.ElementType).Returns(queryableClasses.ElementType);
            mockClassesDbSet.As<IQueryable<Class>>().Setup(m => m.GetEnumerator()).Returns(queryableClasses.GetEnumerator());
            
            Mock.Get(_context).Setup(x => x.TypesDb).Returns(mockTypesDbSet.Object);
            Mock.Get(_context).Setup(x => x.ClassesDb).Returns(mockClassesDbSet.Object);

            // Act
            var result = await _controller.Create(classModel);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
            Assert.NotNull(_controller.ViewBag.Types);
        }

        [Fact]
        public void Controller_HasCorrectDependencies()
        {
            // Assert that controller is instantiated properly with services
            Assert.NotNull(_controller);
            Assert.IsType<ClassController>(_controller);
        }
    }
}
