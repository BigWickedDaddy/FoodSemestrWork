using FoodSemWork.Interfaces;
using FoodSemWork.Models;
using FoodSemWork.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodSemWork.Controllers
{
    public class RegistrationLoginController : Controller
    {
        ApplicationContext db;

        private readonly IJWTAuthManager _jWTAuthManager;

        public bool a = false;

        public RegistrationLoginController(ApplicationContext context, IJWTAuthManager jWTAuthManager)
        {
            db = context;
            _jWTAuthManager = jWTAuthManager;
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
            if (Request.Cookies["token"] != null)
                return RedirectToAction("Login", "RegistrationLogin");

            if (ModelState.IsValid && model.ConfirmPassword == model.Password)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    if (RegexUtilities.IsValidEmail(model.Email) && RegexUtilities.IsValidPassword(model.Password))
                    {
                        var currentUser = new User
                        {
                            Id = Guid.NewGuid(),
                            Email = model.Email,
                            Username = model.Email,
                            Password = Encryption.EncryptString(model.Password),
                        };
                        db.Users.Add(currentUser);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Profile", "Account");
                    }
                    return RedirectToAction("Registration", "Registrationlogin");
                }
                else
                    ModelState.AddModelError("", "User already exists");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (Request.Cookies["token"] != null)
                return RedirectToAction("RegistrationLogin", "Login");

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == Encryption.EncryptString(model.Password));
            if (user == null)
            {
                return RedirectToAction("Registration", "RegistrationLogin");
            }
            var token = _jWTAuthManager.Authenticate(user);

            if (token == null)
                return RedirectToAction("Login", "RegistrationLogin");
            else
            {
                Response.Cookies.Append("token", token);
                return RedirectToAction("Index", "Home");
            }


            //if (Request.Cookies["token"] != null)
            //{
            //    Response.Cookies["token"].Expires = DateTime.Now.AddDays(-1);
            //}

        }

        [HttpGet]
        public IActionResult Logout()
        {
            var token = Request.Cookies["token"];
            if (token == null)
                return RedirectToAction("Index", "Home");
            Response.Cookies.Delete("token");
            return RedirectToAction("Index", "Home");
        }


    }
}
