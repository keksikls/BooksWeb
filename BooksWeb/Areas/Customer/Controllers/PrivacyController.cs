using BooksWeb.DataAccess.Repository;
using BooksWeb.DataAccess.Repository.IRepository;
using BooksWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BooksWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Hello!";
            return View("Index");
        }
    }
}
