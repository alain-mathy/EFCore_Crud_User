﻿// <auto-generated />
using EFCore_Crud_User_DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore_Crud_User_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241028101424_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCore_Crud_User_DAL.Models.Salt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PostSalt")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("PreSalt")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("T_Salt", (string)null);
                });

            modelBuilder.Entity("EFCore_Crud_User_DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(100)")
                        .HasDefaultValue("admin@admin.be");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(50)")
                        .HasDefaultValue("admin");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<int>("IsActif")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasDefaultValue(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(50)")
                        .HasDefaultValue("admin");

                    b.Property<byte[]>("Pwd")
                        .IsRequired()
                        .HasColumnType("VARBINARY(64)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasDefaultValue(1);

                    b.Property<int>("SaltId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("SaltId")
                        .IsUnique();

                    b.ToTable("T_User", (string)null);
                });

            modelBuilder.Entity("EFCore_Crud_User_DAL.Models.User", b =>
                {
                    b.HasOne("EFCore_Crud_User_DAL.Models.Salt", "Salt")
                        .WithOne("User")
                        .HasForeignKey("EFCore_Crud_User_DAL.Models.User", "SaltId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salt");
                });

            modelBuilder.Entity("EFCore_Crud_User_DAL.Models.Salt", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
