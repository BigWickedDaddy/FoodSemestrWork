using FoodSemWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Controllers
{
	//public class AccountController : Controller
	//{
	//	private ApplicationContext db;

	//	private readonly IJWTAuthenticationManager jWTAuthenticationManager;

	//	public AccountController(ApplicationContext context, IJWTAuthenticationManager jWTAuthenticationManager)
	//	{
	//		db = context;
	//		this.jWTAuthenticationManager = jWTAuthenticationManager;
	//	}
	//	[HttpGet]
	//	public IActionResult Login()
	//	{
	//		if (Request.Cookies["token"] != null)
	//			return RedirectToAction("Index", "Home");
	//		return View();
	//	}
	//	[AllowAnonymous]
	//	[HttpPost]
	//	//public async Task<IActionResult> Login(LoginViewModel model)
	//	//{
	//		//User user = await db.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == Encryption.EncryptString(model.Password));
	//		//if (user == null)
	//		//{
	//		//	return RedirectToAction("Register", "Account");
	//		//}
	//		//var token = jWTAuthenticationManager.Authenticate(user);

	//		//if (token == null)
	//		//	return RedirectToAction("Login", "Account");
	//		//else
	//		//{
	//		//	Response.Cookies.Append("token", token);
	//		//	return RedirectToAction("Index", "Home");
	//		//}
	//	//}
	//	[HttpGet]
	//	public IActionResult Logout()
	//	{
	//		var token = Request.Cookies["token"];
	//		if (token == null)
	//			return RedirectToAction("Login", "Account");
	//		Response.Cookies.Delete("token");
	//		return RedirectToAction("Index", "Home");
	//	}

	//	[HttpGet]
	//	public IActionResult Register()
	//	{
	//		return View();
	//	}
	//	[HttpPost]
	//	[ValidateAntiForgeryToken]
	//	public async Task<IActionResult> Register(RegisterViewModel model)
	//	{
	//		if (ModelState.IsValid && model.Password == model.ConfirmPassword)
	//		{
	//			if (ModelState.IsValid)
	//			{
	//				User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email || u.Username == model.Username);
	//				if (user == null)
	//				{
	//					var currentUser = new User
	//					{
	//						//Id = Guid.NewGuid(),
	//						Email = model.Email,
	//						Password = Encryption.EncryptString(model.Password),
	//						Username = model.Username,
	//						//Login = model.Login
	//					};
	//					db.Users.Add(currentUser);
	//					await db.SaveChangesAsync();

	//					//await Authentificate(currentUser);

	//					return RedirectToAction("Index", "Home");
	//				}
	//				else
	//					ModelState.AddModelError("", $"Пользователь {model.Login} уже зарегистрирован.");
	//			}
	//		}
	//		else
	//			ModelState.AddModelError("", $"Не все поля заполнены.");
	//		return View(model);
	//	}








		//    public class AccountController : Controller
		//    {
		//        ApplicationContext db;

		//        public AccountController(ApplicationContext context)
		//        {
		//            db = context;
		//        }

		//        [HttpGet]
		//        public IActionResult Registration()
		//        {
		//            return View();
		//        }

		//        [HttpPost]
		//        [ValidateAntiForgeryToken]
		//        public async Task<IActionResult> Registration(UserViewModel model)
		//        {
		//            if (ModelState.IsValid)
		//            {
		//                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

		//                if (user == null)
		//                {
		//                    var currentUser = new User
		//                    {
		//                       Id = model.Id,
		//                        Email = model.Email,
		//                        Password = model.Password,

		//                    };
		//                    db.Users.Add(currentUser);
		//                    await db.SaveChangesAsync();


		//                    return RedirectToAction("Index", "Home");
		//                }
		//                else
		//                    ModelState.AddModelError("", "User already exists");
		//            }
		//            return View(model);
		//        }
		//    }
	//}
}
