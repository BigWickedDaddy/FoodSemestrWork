using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Models
{
	public class User
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public string Birthday { get; set; }

		public byte[] Avatar { get; set; }


	}
}
