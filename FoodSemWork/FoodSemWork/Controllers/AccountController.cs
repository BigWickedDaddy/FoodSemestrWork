using FoodSemWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Controllers
{
    public class RegistrationLoginController : Controller
    {
        ApplicationContext db;

        public RegistrationLoginController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    var currentUser = new User
                    {
                        Id = Guid.NewGuid(),
                        Email = model.Email,
                        Password = model.Password,

                    };
                    db.Users.Add(currentUser);
                    await db.SaveChangesAsync();


                    return RedirectToAction("Check", "Home");
                }
                else
                    ModelState.AddModelError("", "User already exists");
            }
            return View(model);
        }
    }
}
