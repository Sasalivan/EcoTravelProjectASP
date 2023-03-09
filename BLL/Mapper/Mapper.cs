using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLe = BLL.Entities;
using DALe = DAL.Entities;

namespace BLL
{
	static class Mapper
	{
		public static BLLe.Client ToBLL(this DALe.Client entity)
		{
			if (entity is null) return null;
			return new BLLe.Client()
			{
				idClient = entity.idClient,
				nom = entity.nom,
				prenom = entity.prenom,
				mail = entity.mail,
				pays = entity.pays,
				telephone = entity.telephone,
				password = entity.password
			};
		}

		public static DALe.Client ToDAL(this BLLe.Client entity)
		{
			if (entity is null) return null;
			return new DALe.Client()
			{
				idClient = entity.idClient,
				nom = entity.nom,
				prenom = entity.prenom,
				mail = entity.mail,
				pays = entity.pays,
				telephone = entity.telephone,
				password = entity.password
			};
		}
	}
}
