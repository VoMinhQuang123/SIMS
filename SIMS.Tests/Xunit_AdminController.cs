using Xunit;
using Microsoft.AspNetCore.Mvc;
using SIMS.Controllers;

namespace SIMS.Tests
{
    public class Xunit_AdminController
    {
        [Fact]
        public void AdminController_ShouldBeInstantiable()
        {
            // Arrange & Act
            var controller = new AdminController();

            // Assert
            Assert.NotNull(controller);
            Assert.IsType<AdminController>(controller);
        }

        [Fact]
        public void AdminController_ShouldInheritFromController()
        {
            // Arrange
            var controller = new AdminController();

            // Act & Assert
            Assert.IsAssignableFrom<Controller>(controller);
        }
    }
}