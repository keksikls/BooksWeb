using Microsoft.AspNetCore.Mvc;
using BooksWeb.Areas.Customer.Controllers;
using Xunit;
using NuGet.ContentModel;

namespace Test
{
    public class PrivacyControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            // Arrange
            PrivacyController controller = new PrivacyController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("Hello world!", result?.ViewData["Message"]);
            Assert.NotNull(result);
            Assert.Equal("Index", result?.ViewName);
        }
    }
}
