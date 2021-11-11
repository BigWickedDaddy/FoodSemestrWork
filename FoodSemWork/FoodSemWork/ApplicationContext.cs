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
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
		}
	}
}
