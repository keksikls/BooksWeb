using BooksWeb.DataAccess.Data;
using BooksWeb.DataAccess.Repository;
using BooksWeb.DataAccess.Repository.IRepository;
using BooksWeb.Models;
using BooksWeb.Models.ViewModels;
using BooksWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace BooksWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [ApiController]
    [Route("api/Category")]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _unitOfWork;

        public ApiController(ApplicationDbContext context)
        {
            _unitOfWork = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _unitOfWork.Categories.ToListAsync();
            return Ok(categories);
        }
     
    }
}
