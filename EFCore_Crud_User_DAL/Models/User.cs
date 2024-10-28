using EFCore_Crud_User_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Crud_User_DAL.Models
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public byte[] Pwd { get; set; }
		public string Street { get; set; }
		public string HouseNumber { get; set; }
		public int ZipCode { get; set; }
		public string City { get; set; }
		public Role Role { get; set; }
		public int IsActif { get; set; }
		public int SaltId { get; set; }
		public virtual Salt Salt { get; set; } = default!;

		public User()
		{

		}

		public User(string firstname, string lastname, string email, string street, string housenumber, int zipcode, string city)
		{
			FirstName = firstname;
			LastName = lastname;
			Email = email;
			Street = street;
			HouseNumber = housenumber;
			ZipCode = zipcode;
			City = city;
			Role = Role.User;
			IsActif = 1;
		}

		public User(string email, byte[] pwd)
		{
			Email = email;
			Pwd = pwd;
		}

		public User(string firstname, string lastname, string email, byte[] pwd, string street, string housenumber, int zipcode, string city)
		{
			FirstName = firstname;
			LastName = lastname;
			Email = email;
			Pwd = pwd;
			Street = street;
			HouseNumber = housenumber;
			ZipCode = zipcode;
			City = city;
		}
	}
}
