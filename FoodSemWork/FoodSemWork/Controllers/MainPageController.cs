using FoodSemWork.Models;
using FoodSemWork.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Controllers
{


	public class MainPageController : Controller
    {
        private ApplicationContext db;
		private JwtSecurityToken _token;

		private readonly ILogger<MainPageController> _logger;
		private readonly Service service;

		//public User CurrentUser { get => GetUser(); }

		public MainPageController(ILogger<MainPageController> logger, Service service)
        {
			_logger = logger;
			this.service = service;
		}
		[HttpGet]
		public IActionResult SendMail()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SendMail(string name, string email, string phonenumber, string adress, string title, string messagetitle)
		{
			service.SendEmail(name,email,phonenumber,adress,title,messagetitle);

			return RedirectToAction("Main");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new Main { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


		public IActionResult Index()
        {
            return View(/*CurrentUser*/);
        }


		public IActionResult Main(Main model)
		{
			//if (CurrentUser == null)
			//{
			//	return RedirectToAction("Login", "RegistrationLogin");
			//}




			//db.SaveChanges();

			return View(/*CurrentUser*/);
		}


		//public User GetUser()
		//{
		//	var currentUser = HttpContext.User;

		//	if (Request.Cookies["token"] == null || Request.Cookies["token"] == "")
		//	{
		//		return null;
		//	}

		//	var stream = Request.Cookies["token"];
		//	var handler = new JwtSecurityTokenHandler();
		//	var jsonToken = handler.ReadToken(stream);
		//	_token = jsonToken as JwtSecurityToken;

		//	var CurrentId = _token.Claims.First(claim => claim.Type == "nameid").Value;

		//	var user = db.Users.FirstOrDefault(u => u.Id.ToString() == CurrentId);

		//	return user;
		//}
	}
}
