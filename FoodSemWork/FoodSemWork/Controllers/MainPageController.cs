using FoodSemWork.Models;
using FoodSemWork.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

		public MainPageController(ILogger<MainPageController> logger, Service service, ApplicationContext context)
		{
			_logger = logger;
			this.service = service;
			db = context;

		}
		[HttpGet]
		public IActionResult SendMail()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SendMail(string name, string email, string phonenumber, string adress, string title, string messagetitle)
		{
			service.SendEmail(name, email, phonenumber, adress, title, messagetitle);

			//return RedirectToAction("Main");
			return Redirect("/mainpage/main");
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
			var posts = db.Posts.ToList();
			return View(posts);

			//return View(/*CurrentUser*/);
		}

		public IActionResult AboutUs(Main model)
		{
			return View();
		}
		public IActionResult Privacy(Main model)
		{
			return View();
		}
		public IActionResult Privacysecond(Main model)
		{
			return View();
		}
		public IActionResult Gallery(Main model)
		{
			var posts = db.Posts.ToList();
			return View(posts);
		}

		public IActionResult ContactUs(Main model)
		{
			return View();
		}

		public IActionResult Blog(Main model)
		{
			var posts = db.TypesOfFoods.ToList();
			return View(posts);
		}

		public IActionResult Post()
		{
			var posts = db.Posts.ToList();
			return View(posts);
		}


		public ActionResult GetMessage()
		{
			return PartialView("_GetMessage");
		}



		[HttpGet]
		public IActionResult SearchEngine()
		{
			var genres = db.TypesOfFoods.ToList();
			return View(genres);
		}

		[HttpPost]
		public async Task<IActionResult> SearchEngine(string searchString)
		{
			var genre = from m in db.TypesOfFoods
						select m;

			if (!string.IsNullOrEmpty(searchString))
			{
				genre = genre.Where(s => s.TypeOfFood!.Contains(searchString));
			}

			return View(await genre.ToListAsync());
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
