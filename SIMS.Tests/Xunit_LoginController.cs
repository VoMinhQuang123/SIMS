using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SIMS.BDContext.Entity;
using SIMS.Controllers;
using SIMS.Interface;
using SIMS.Models;
using SIMS.Service;
using System.Security.Claims;

namespace SIMS.Tests
{
    public class Xunit_LoginController
    {
        private readonly Mock<ILogin> _mockLoginRepository;
        private readonly Service_Login _loginService;
        private readonly LoginController _controller;

        public Xunit_LoginController()
        {
            _mockLoginRepository = new Mock<ILogin>();
            _loginService = new Service_Login(_mockLoginRepository.Object);

            _controller = new LoginController(_loginService);

            // Setup basic HttpContext
            var mockHttpContext = new Mock<HttpContext>();
            var mockRequest = new Mock<HttpRequest>();
            var mockResponse = new Mock<HttpResponse>();
            var mockCookies = new Mock<IRequestCookieCollection>();
            var mockResponseCookies = new Mock<IResponseCookies>();
            var mockServiceProvider = new Mock<IServiceProvider>();
            var mockAuthService = new Mock<IAuthenticationService>();
            var mockTempDataDictionary = new Mock<ITempDataDictionary>();
            var mockUrlHelperFactory = new Mock<IUrlHelperFactory>();
            var mockTempDataFactory = new Mock<ITempDataDictionaryFactory>();

            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);
            mockHttpContext.Setup(x => x.Response).Returns(mockResponse.Object);
            mockRequest.Setup(x => x.Cookies).Returns(mockCookies.Object);
            mockResponse.Setup(x => x.Cookies).Returns(mockResponseCookies.Object);
            mockCookies.Setup(x => x.Keys).Returns(new List<string>());

            // Setup Services
            mockServiceProvider.Setup(x => x.GetService(typeof(IAuthenticationService))).Returns(mockAuthService.Object);
            mockServiceProvider.Setup(x => x.GetService(typeof(ITempDataDictionaryFactory))).Returns(mockTempDataFactory.Object);
            mockServiceProvider.Setup(x => x.GetService(typeof(IUrlHelperFactory))).Returns(mockUrlHelperFactory.Object);
            
            mockHttpContext.Setup(x => x.RequestServices).Returns(mockServiceProvider.Object);

            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockHttpContext.Object
            };
            
            // Set default user to avoid null reference
            var defaultClaims = new List<Claim>();
            var defaultIdentity = new ClaimsIdentity(defaultClaims);
            var defaultPrincipal = new ClaimsPrincipal(defaultIdentity);
            mockHttpContext.Setup(x => x.User).Returns(defaultPrincipal);
            
            _controller.TempData = mockTempDataDictionary.Object;
        }

        [Fact]
        public async Task Index_Get_WhenUserNotAuthenticated_ReturnsView()
        {
            var claims = new List<Claim>();
            var identity = new ClaimsIdentity(claims, null);  // null authentication type => not authenticated
            var principal = new ClaimsPrincipal(identity);
            _controller.ControllerContext.HttpContext.User = principal;

            var result = await _controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Index_Get_WhenUserAuthenticated_RedirectsToDashboard()
        {
            // Create an authenticated identity
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, "testuser") };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var principal = new ClaimsPrincipal(identity);
            
            // Set up HttpContext.User
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(x => x.User).Returns(principal);
            
            _controller.ControllerContext.HttpContext = mockHttpContext.Object;

            var result = await _controller.Index();

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Equal("DashBroad", redirect.ControllerName);
        }

        [Fact]
        public async Task Index_Post_InvalidModel_ReturnsSameView()
        {
            var model = new LoginViewModel();
            _controller.ModelState.AddModelError("Username", "Required");

            var result = await _controller.Index(model);

            var view = Assert.IsType<ViewResult>(result);
            Assert.Equal(model, view.Model);
        }

        [Fact]
        public async Task Index_Post_InvalidUser_ReturnsErrorMessage()
        {
            var model = new LoginViewModel { Username = "test", Password = "123" };
            _mockLoginRepository
                .Setup(x => x.GetUsersByUsername("test"))
                .ReturnsAsync((User?)null);

            var result = await _controller.Index(model);

            var view = Assert.IsType<ViewResult>(result);
            Assert.Equal("Account is invalid", _controller.ViewData["MessageLogin"]);
        }

        [Fact]
        public async Task Index_Post_WrongPassword_ReturnsErrorMessage()
        {
            var model = new LoginViewModel { Username = "test", Password = "wrongpassword" };
            var user = new User { Username = "test", PasswordHash = "correctpassword", Role = "Admin" };
            _mockLoginRepository
                .Setup(x => x.GetUsersByUsername("test"))
                .ReturnsAsync(user);

            var result = await _controller.Index(model);

            var view = Assert.IsType<ViewResult>(result);
            Assert.Equal("Account is invalid", _controller.ViewData["MessageLogin"]);
        }

        [Theory]
        [InlineData("Admin", "Dashboard_Admin")]
        [InlineData("Teacher", "Dashboard_Teacher")]
        [InlineData("Student", "Dashboard_Student")]
        public async Task Index_Post_ValidUserRole_Redirects(string role, string dashboard)
        {
            var model = new LoginViewModel { Username = "u", Password = "p" };
            var user = new User { Username = "u", PasswordHash = "p", Role = role };
            _mockLoginRepository
                .Setup(x => x.GetUsersByUsername("u"))
                .ReturnsAsync(user);

            var result = await _controller.Index(model);

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Equal(dashboard, redirect.ControllerName);
        }

        [Fact]
        public async Task Index_Post_InvalidRole_ReturnsError()
        {
            var model = new LoginViewModel { Username = "u", Password = "p" };
            var user = new User { Username = "u", PasswordHash = "p", Role = "WrongRole" };
            _mockLoginRepository
                .Setup(x => x.GetUsersByUsername("u"))
                .ReturnsAsync(user);

            var result = await _controller.Index(model);

            var view = Assert.IsType<ViewResult>(result);
            Assert.Equal("Role is invalid", _controller.ViewData["MessageLogin"]);
        }

        [Fact]
        public async Task Logout_Always_RedirectsToLogin()
        {
            var result = await _controller.Logout();

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Equal("Login", redirect.ControllerName);
        }

        [Fact]
        public void LoginService_Property_ReturnsInjectedService()
        {
            Assert.Equal(_loginService, _controller.LoginService);
        }
    }
}
