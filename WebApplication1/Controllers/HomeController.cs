using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly FlorellaDbContext _context;
        public HomeController(FlorellaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products =  await _context.Products.Include(p=>p.Category).ToListAsync();
            List<Category> categories = await _context.Categories.ToListAsync();

            CategoryProduct categoryProduct = new CategoryProduct
            {
                Product = products,
                Category = categories
            };

            return View(categoryProduct);
        }
    }
}
