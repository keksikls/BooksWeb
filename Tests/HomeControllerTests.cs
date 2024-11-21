using BooksWeb.Areas.Customer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BooksWeb.Areas.Customer.Controllers;
using Microsoft.AspNetCore.Mvc;
using BooksWeb.Models;

namespace Tests
{
    
    public class HomeControllerTests
    {
        [Fact]
        public void IndexViewResultNotNull() 
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act


            //Assert

        }
    }
}
