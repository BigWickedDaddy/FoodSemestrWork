using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodSemWork.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace FoodSemWork.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var currentUser = HttpContext.User;

            if (Request.Cookies["token"] == null || Request.Cookies["token"] == "")
            {
                return View(null);
            }

            var stream = Request.Cookies["token"];
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;

            var id = tokenS.Claims.First(claim => claim.Type == "nameid").Value;

            var user = db.Users.FirstOrDefault(u => u.Id.ToString() == id);

            return View(user);
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }





    //public class HomeController : Controller
    //{
    //    private ApplicationContext db;

    //    public HomeController(ApplicationContext context)
    //    {
    //        db = context;
    //    }

    //    [HttpGet]
    //    public IActionResult Index()
    //    {
    //        var currentUser = HttpContext.User;

    //        if (Request.Cookies["token"] == null || Request.Cookies["token"] == "")
    //        {
    //            return View(null);
    //        }
    //        var stream = Request.Cookies["token"];
    //        var handler = new JwtSecurityTokenHandler();
    //        var jsonToken = handler.ReadToken(stream);
    //        var tokenS = jsonToken as JwtSecurityToken;

    //        var id = tokenS.Claims.First(claim => claim.Type == "nameid").Value;

    //        var user = db.Users.FirstOrDefault(u => u.Id.ToString() == id);

    //        return View(user);
    //    }
    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }
    //}






    //public class HomeController : Controller
    //{
    //    ApplicationContext db;

    //    public HomeController(ApplicationContext options)
    //    {
    //        db = options;
    //    }

    //    public IActionResult Index()
    //    {
    //        //User user = db.Users.FirstOrDefault<User>(X => X.Id == 0);
    //        db.SaveChanges();
    //        return View();
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [HttpGet]
    //    public IActionResult Registration()
    //    {
    //        return View();
    //    }

    //    [HttpGet]
    //    public IActionResult Profile()
    //    {
    //        return View();
    //    }


    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Registration([FromBody] UserViewModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

    //            if (user == null)
    //            {
    //                var currentUser = new User
    //                {
    //                    Id = model.Id,
    //                    Password = model.Password,
    //                    Email = model.Email,
    //                };
    //                db.Users.Add(currentUser);
    //                await db.SaveChangesAsync();

    //                return RedirectToAction("Index", "Home");
    //            }
    //            else
    //                ModelState.AddModelError("", "user already exists");

    //        }
    //        return View(model);
    //    }
    //}
}
