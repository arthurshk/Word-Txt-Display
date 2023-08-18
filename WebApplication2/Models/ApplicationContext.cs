using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication2.Models; 
using Microsoft.AspNetCore.Mvc;
namespace WebApplication2.Models
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Word> Words { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}
	}
}
