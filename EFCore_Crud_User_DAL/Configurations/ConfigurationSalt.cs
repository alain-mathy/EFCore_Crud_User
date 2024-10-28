using EFCore_Crud_User_DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Crud_User_DAL.Configurations
{
	internal class ConfigurationSalt : IEntityTypeConfiguration<Salt>
	{
		public void Configure(EntityTypeBuilder<Salt> builder)
		{
			builder.ToTable("T_Salt");

			builder.Property(b => b.PreSalt)
				.HasColumnType("NVARCHAR(100)");

			builder.Property(b => b.PostSalt)
				.HasColumnType("NVARCHAR(100)");

			builder.HasOne(u => u.User)
				.WithOne(s => s.Salt)
				.HasForeignKey<User>(u => u.SaltId);
		}

	}
}