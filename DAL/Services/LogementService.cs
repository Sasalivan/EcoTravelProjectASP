using COMMON.Repository;
using DAL.Entities;
using DAL.Mapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
	class LogementService : IRepository<Logement, int>
	{
		//a enlever apres
		private string connectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog =EcoTravelDB;Integrated Security = True";

		public IEnumerable<Logement>Get()
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SELECT [idLogement], [prix], [nom], [adresseRue], [adresseNumero], [adresseCodePostal], [adressePays], [longitude], [latitude], [desc_courte], [desc_longue], [nb_chambre], [nb_piece], [nb_sdb], [nb_wc], [capacite], [balcon], [airco], [wifi], [minibar], [animaux], [piscine], [voiturier], [roomService], [idProprio], FROM [Logement]";
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToLogement();
						}
					}
				}
			}
		}
		public Logement Get(int id)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SELECT [idLogement], [prix], [nom], [adresseRue], [adresseNumero], [adresseCodePostal], [adressePays], [longitude], [latitude], [desc_courte], [desc_longue], [nb_chambre], [nb_piece], [nb_sdb], [nb_wc], [capacite], [balcon], [airco], [wifi], [minibar], [animaux], [piscine], [voiturier], [roomService], [idProprio], FROM [Logement] WHERE [idLogement] = @id";
					command.Parameters.AddWithValue("id", id);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read()) return reader.ToLogement();
						return null;
					}
				}
			}
		}


		public int Insert(Logement entity)
		{
			throw new NotImplementedException();
		}

		public bool Update(int id, Logement entity)
		{
			throw new NotImplementedException();
		}


	}
}
