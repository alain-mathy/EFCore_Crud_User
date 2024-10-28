using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Crud_User_DAL.Models
{
	public class Salt
	{
		public int Id { get; set; }
		public string PreSalt { get; set; }
		public string PostSalt { get; set; }
		public User User { get; set; }
	}
}
