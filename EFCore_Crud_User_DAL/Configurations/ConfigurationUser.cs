using EFCore_Crud_User_DAL.Enums;
using EFCore_Crud_User_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Crud_User_DAL.Configurations
{
	internal class ConfigurationUser : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("T_User");

			builder.Property(b => b.FirstName)
				.HasColumnType("NVARCHAR(50)")
				.HasDefaultValue("admin");

			builder.Property(b => b.LastName)
				.HasColumnType("NVARCHAR(50)")
				.HasDefaultValue("admin");

			builder.Property(b => b.Email)
				.HasColumnType("NVARCHAR(100)")
				.HasDefaultValue("admin@admin.be");

			builder.Property(b => b.Pwd)
				.HasColumnType("VARBINARY(64)");

			builder.Property(b => b.Street)
				.HasColumnType("NVARCHAR(100)");

			builder.Property(b => b.HouseNumber)
				.HasColumnType("NVARCHAR(10)");

			builder.Property(b => b.ZipCode)
				.HasColumnType("INT");

			builder.Property(b => b.City)
				.HasColumnType("NVARCHAR(50)");

			builder.Property(b => b.Role)
				.HasColumnType("INT")
				.HasDefaultValue(Role.User);

			builder.Property(b => b.IsActif)
				.HasColumnType("INT")
				.HasDefaultValue(1);

			builder.HasIndex(b => b.Email)
				.IsUnique();




		}
	}
}
