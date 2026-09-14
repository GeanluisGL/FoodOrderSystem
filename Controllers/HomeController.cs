using FoodOrderSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FoodOrderSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            var categories = _context.Categories.ToList();
            ViewBag.categories = categories; 
            
            var featuredItems = _context.FoodItems
                .Where(f => f.IsCategory)
                .Take(6)
                .ToList();

            return View(featuredItems);
        }

        
    }
}