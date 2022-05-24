using FoodSemWork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork
{
	public class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<Posts> Posts { get; set; }

		public DbSet<TypesOfFood> TypesOfFoods { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
		}
	}
}
