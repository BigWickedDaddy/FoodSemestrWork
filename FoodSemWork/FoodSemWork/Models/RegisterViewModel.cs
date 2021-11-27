using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Models
{
    public class RegisterViewModel
    {
		[Required]
		[DataType(DataType.Text)]
		public string Login { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
		[Required]
		[DataType(DataType.Text)]
		public string Username { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}
