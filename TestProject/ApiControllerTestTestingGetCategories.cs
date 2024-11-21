using Xunit;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksWeb.DataAccess.Repository.IRepository;
using BooksWeb.DataAccess.Data;
using BooksWeb.Areas.Customer.Controllers;
using Microsoft.EntityFrameworkCore;
using BooksWeb.Areas.Admin.Controllers;
using BooksWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace TestProject
{
    public class ApiControllerTestTestingGetCategories
    {
        private readonly ApiController _controller;
        private readonly Mock<ApplicationDbContext> _mockDbContext;

        public ApiControllerTestTestingGetCategories() 
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            var dbContext = new ApplicationDbContext(options);

            _mockDbContext = new Mock<ApplicationDbContext>(options);
            _controller = new ApiController(dbContext);
        }
        

        [Fact]
        public async Task GetCategories_ReturnsOk_WithCategories()
        {

            // Arrange: добавляем тестовые данные в "базу данных"
            var testCategories = new List<Category>
            {
               new Category { Id = 1, Name = "Category 1" },
               new Category { Id = 2, Name = "Category 2" }
            };

            _mockDbContext.Setup(db => db.Categories.ToListAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(testCategories);


            // Act: вызываем метод GetCategories
            var result = await _controller.GetCategories();

            // Assert: проверяем, что результат - это OK и что содержимое соответствует ожидаемому
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Category>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var categories = Assert.IsAssignableFrom<IEnumerable<Category>>(okResult.Value);

            Assert.Equal(2, categories.Count());
            Assert.Equal("Category 1", categories.First().Name);
        }
   

        [Fact]
        public async Task GetCategories_ReturnsNotFound_WhenNoCategories()
        {
            // Arrange: возвращаем пустой список категорий
            _mockDbContext.Setup(db => db.Categories.ToListAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Category>());

            // Act: вызываем метод GetCategories
            var result = await _controller.GetCategories();

            // Assert: проверяем, что результат - это OK, но без категорий
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Category>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var categories = Assert.IsAssignableFrom<IEnumerable<Category>>(okResult.Value);

            Assert.Empty(categories);
        }
    }
}
