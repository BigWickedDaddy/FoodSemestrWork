using FoodSemWork.Models;
using FoodSemWork.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Controllers
{

	public class AccountController : Controller
	{
		private ApplicationContext db;
		private JwtSecurityToken _token;
		public User CurrentUser { get => GetUser(); }

		public AccountController(ApplicationContext context)
		{
			db = context;
		}

		public IActionResult Index()
		{

			return View(CurrentUser);
		}

		public IActionResult Profile(UserViewModel model)
		{
			if (CurrentUser == null)
			{
				//return RedirectToAction("Login", "RegistrationLogin");
				return Redirect("/RegistrationLogin/Login");

			}

			return View(CurrentUser);
		}

		public IActionResult Settings(UserViewModel model)
		{

			if (model.Birthday != null)
			{
				CurrentUser.Birthday = model.Birthday;
			}

			if (CurrentUser == null)
			{
				//return RedirectToAction("Login", "RegistrationLogin");
				return Redirect("/RegistrationLogin/Login");

			}

			if (model.Avatar != null)
			{
				byte[] imageData = null;
				using (var binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
				{
					imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
				}
				CurrentUser.Avatar = imageData;
			}

			if (model.Username != null)
			{
				CurrentUser.Username = model.Username;
			}

			if (model.CurrentPassword != null && model.NewPassword != null)
			{
				if (CurrentUser.Password == Encryption.EncryptString(model.CurrentPassword))
				{
					CurrentUser.Password = Encryption.EncryptString(model.NewPassword);
				}
			}


			db.SaveChanges();

			return View(CurrentUser);
		}


		public User GetUser()
		{
			var currentUser = HttpContext.User;

			if (Request.Cookies["token"] == null || Request.Cookies["token"] == "")
			{
				return null;
			}

			var stream = Request.Cookies["token"];
			var handler = new JwtSecurityTokenHandler();
			var jsonToken = handler.ReadToken(stream);
			_token = jsonToken as JwtSecurityToken;

			var CurrentId = _token.Claims.First(claim => claim.Type == "nameid").Value;

			var user = db.Users.FirstOrDefault(u => u.Id.ToString() == CurrentId);

			return user;
		}
	}
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
