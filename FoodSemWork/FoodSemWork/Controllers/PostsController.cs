using FoodSemWork.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationContext db;


        public PostsController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
