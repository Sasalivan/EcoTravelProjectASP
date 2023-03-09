using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	 public class Client
	{
		//int
		public int idClient { get; set; }

		//nvarchar(50)
		public string nom { get; set; }

		//nvarchar(50)
		public string prenom { get; set; }

		//nvarchar(250)
		public string mail { get; set; }

		//nvarchar(50)
		public string pays { get; set; }

		//nvarchar(50)
		public string telephone { get; set; }

		//varbinary(64)
		public string password { get; set; }
	}
}
