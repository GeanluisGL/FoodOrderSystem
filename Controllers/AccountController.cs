using Azure.Identity;
using FoodOrderSystem.Models;
using FoodOrderSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystem.Controllers
{
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

                var user = new User
                {
                    Username = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    FullName = model.FullName,
                    Address = model.Address,
                    Phone = model.PhoneNumber
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("#");
            }

            return View();
        }
    }
}