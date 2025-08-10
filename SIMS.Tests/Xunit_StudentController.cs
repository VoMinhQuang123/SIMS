using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Controllers;
using SIMS.Interface;
using SIMS.Service;
using System.Security.Claims;

namespace SIMS.Tests
{
    public class Xunit_StudentController
    {
        private readonly Mock<IStudent> _mockStudentRepository;
        private readonly Mock<IClass> _mockClassRepository;
        private readonly Mock<IType> _mockTypeRepository;
        private readonly SIMSDBContext _context;
        private readonly Service_User _userService;
        private readonly Service_Student _studentService;
        private readonly Service_Class _classService;
        private readonly Service_Type _typeService;
        private readonly StudentController _controller;

        public Xunit_StudentController()
        {
            _mockStudentRepository = new Mock<IStudent>();
            _mockClassRepository = new Mock<IClass>();
            _mockTypeRepository = new Mock<IType>();
            _context = Mock.Of<SIMSDBContext>();
            _userService = Mock.Of<Service_User>();
            
            _studentService = new Service_Student(_mockStudentRepository.Object, _context, _userService);
            _classService = new Service_Class(_mockClassRepository.Object, _context);
            _typeService = new Service_Type(_mockTypeRepository.Object);

            _controller = new StudentController(_studentService, _classService, _typeService);

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
        public async Task Index_ReturnsViewWithStudentsAndViewBagData()
        {
            // Arrange
            var students = new List<Student>
            {
                new Student { StudentID = 1, Name = "Student 1", Email = "student1@test.com" },
                new Student { StudentID = 2, Name = "Student 2", Email = "student2@test.com" }
            };
            var types = new List<SIMS.BDContext.Entity.Type>
            {
                new SIMS.BDContext.Entity.Type { TypeID = 1, TypeName = "Type 1" }
            };
            var classes = new List<Class>
            {
                new Class { ClassID = 1, ClassName = "Class 1" }
            };

            _mockStudentRepository.Setup(x => x.GetAllStudentsAsync()).ReturnsAsync(students);
            _mockTypeRepository.Setup(x => x.GetAllTypesAsync()).ReturnsAsync(types);
            _mockClassRepository.Setup(x => x.GetAllClassesAsync()).ReturnsAsync(classes);

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Student>>(viewResult.Model);
            Assert.Equal(2, model.Count);
            Assert.Equal(types, _controller.ViewBag.Types);
            Assert.Equal(classes, _controller.ViewBag.Classes);
            Assert.Equal(3, _controller.ViewBag.NextID); // students.Count + 1
        }

        [Fact]
        public async Task Create_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var student = new Student 
            { 
                StudentID = 1, 
                Name = "Test Student", 
                Email = "test@student.com" 
            };

            Mock.Get(_userService).Setup(x => x.AddUserAsync(It.IsAny<User>())).ReturnsAsync(1);
            _mockStudentRepository.Setup(x => x.AddStudentAsync(It.IsAny<Student>()))
                                 .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(student);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }

        [Fact]
        public async Task Create_ValidModel_SetsCorrectUserData()
        {
            // Arrange
            var student = new Student 
            { 
                StudentID = 1, 
                Name = "Test Student", 
                Email = "test@student.com" 
            };

            User? capturedUser = null;
            Mock.Get(_userService).Setup(x => x.AddUserAsync(It.IsAny<User>()))
                           .Callback<User>(u => capturedUser = u)
                           .ReturnsAsync(1);
            
            _mockStudentRepository.Setup(x => x.AddStudentAsync(It.IsAny<Student>()))
                                 .Returns(Task.CompletedTask);

            // Act
            await _controller.Create(student);

            // Assert
            Assert.NotNull(capturedUser);
            Assert.Equal(student.Email, capturedUser.Username);
            Assert.Equal("123456", capturedUser.PasswordHash);
            Assert.Equal("Student", capturedUser.Role);
        }

        [Fact]
        public async Task Create_InvalidModel_ReturnsIndexView()
        {
            // Arrange
            var student = new Student();
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var result = await _controller.Create(student);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
        }

        [Fact]
        public async Task GetClassesByType_ReturnsJsonWithClass()
        {
            // Arrange
            var typeId = 1;
            var classEntity = new Class { ClassID = 1, ClassName = "Class 1", TypeID = typeId };

            _mockClassRepository.Setup(x => x.GetClassByIDTypeAsync(typeId)).ReturnsAsync(classEntity);

            // Act
            var result = await _controller.GetClassesByType(typeId);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var data = Assert.IsAssignableFrom<Class>(jsonResult.Value);
            Assert.Equal(typeId, data.TypeID);
        }

        [Fact]
        public void Controller_HasCorrectDependencies()
        {
            // Assert that controller is instantiated properly with services
            Assert.NotNull(_controller);
            Assert.IsType<StudentController>(_controller);
        }
    }
}
