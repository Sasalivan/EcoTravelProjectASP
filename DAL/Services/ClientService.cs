using COMMON.Repository;
using DAL.Entities;
using DAL.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
	public class ClientService : IClientRepository<Client, int>
	{
		//a enlever apres
		private string connectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog =EcoTravelDB;Integrated Security = True";
		public IEnumerable<Client> Get()
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SELECT [idClient], [nom], [prenom], [mail], [pays], [telephone], [password] FROM [Client]";
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToClient();
						}
					}
				}
			}
		}

		public Client Get(int id)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SELECT [idClient], [nom], [prenom], [mail], [pays], [telephone], [password] FROM [Client] WHERE [idClient] = @id";
					command.Parameters.AddWithValue("id", id);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read()) return reader.ToClient();
						return null;
					}
				}
			}
		}

		public int Insert(Client entity) 
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "sp_AddClient";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("nom", entity.nom);
					command.Parameters.AddWithValue("prenom", entity.prenom);
					command.Parameters.AddWithValue("mail", entity.mail);
					command.Parameters.AddWithValue("pays", entity.pays);
					command.Parameters.AddWithValue("telephone", entity.telephone);
					command.Parameters.AddWithValue("password", entity.password);
					connection.Open();
					return (int)command.ExecuteScalar();
				}
			}
		}

		public bool Update(int id, Client entity)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = @"UPDATE [Client]
											SET [nom] = @nom,
												[prenom] = @prenom,
												[mail] = @mail,
												[pays] = @pays,
												[telephone] = @telephone,
												[password] = @password
											WHERE [idClient] = @id";
					command.Parameters.AddWithValue("nom", entity.nom);
					command.Parameters.AddWithValue("prenom", entity.prenom);
					command.Parameters.AddWithValue("mail", entity.mail);
					command.Parameters.AddWithValue("pays", entity.pays);
					command.Parameters.AddWithValue("telephone", entity.telephone);
					command.Parameters.AddWithValue("password", entity.password);
					connection.Open();
					return command.ExecuteNonQuery() > 0;
				}
			}
		}
	}
}
