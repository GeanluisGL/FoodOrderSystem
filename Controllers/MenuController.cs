using Microsoft.AspNetCore.Mvc;
using FoodOrderSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystem.Controllers
{
    public class MenuController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context) 
        { 
                _context = context;

        }
        public IActionResult Index(int? categoryId)
        {

            var categories = _context.Categories.ToList();
            ViewBag.categories = categories;

            var foodItems = _context.FoodItems
                .Include(f => f.Category)
                .Where(f => f.IsCategory && (categoryId == null || f.CategoryId == categoryId))
                .ToList();

            return View(foodItems);

        }

    }
}
