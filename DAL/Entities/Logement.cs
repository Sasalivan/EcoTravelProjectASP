using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Logement
	{
		//int
		public int idLogement { get; set; }

		//money
		public decimal prix { get; set; }

		//nvarchar(50)
		public string nom { get; set; }

		//nvarchar(255)
		public string adresseRue { get; set; }

		//nvarchar(15)
		public string adresseNumero { get; set; }

		//nvarchar(8)
		public string adresseCodePostal { get; set; }

		//nvarchar(50)
		public string adressePays { get; set; }

		//decimal(10,7)
		public decimal longitude { get; set; }

		//deciaml(10,7)
		public decimal latitude { get; set; }

		//NVARCHAR(100)
		public string desc_courte { get; set; }

		//NVARCHAR(MAX)
		public string desc_longue { get; set; }

		//TINYINT
		public byte nb_chambre { get; set; }

		//TINYINT
		public byte nb_piece { get; set; }

		//TINYINT
		public byte nb_sdb { get; set; }

		//TINYINT
		public byte nb_wc { get; set; }

		//TINYINT
		public byte capacite { get; set; }

		//BIT
		public bool balcon { get; set; }

		//BIT
		public bool airco { get; set; }

		//BIT
		public bool wifi { get; set; }

		//BIT
		public bool minibar { get; set; }

		//BIT
		public bool animaux { get; set; }

		//BIT
		public bool piscine { get; set; }

		//BIT
		public bool voiturier { get; set; }

		//BIT
		public bool roomService { get; set; }

		//INT
		public int idProprio { get; set; }

		}
}
