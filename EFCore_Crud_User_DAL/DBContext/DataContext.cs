using EFCore_Crud_User_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Crud_User_DAL.DBContext
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get { return Set<User>(); } }
		public DbSet<Salt> Salts { get { return Set<Salt>(); } }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
		}
	}
}
