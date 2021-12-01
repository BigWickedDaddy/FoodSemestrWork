using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        //public bool isToken { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public IFormFile Avatar { get; set;}


    }
}
