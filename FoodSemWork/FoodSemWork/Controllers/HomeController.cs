﻿using FoodSemWork.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Controllers
{
    public class HomeController : Controller
    {
		public IActionResult Index()
		{
			
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}
	}
}
