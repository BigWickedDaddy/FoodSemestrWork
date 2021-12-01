using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Controllers
{
    public class MainPageController : Controller
    {
        private ApplicationContext db;

        public IActionResult Main()
        {
            return View();
        }
    }
}
