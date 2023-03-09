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
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "INSERT INTO [Logement] ( [prix], [nom], [adresseRue], [adresseNumero], [adresseCodePostal], [adressePays], [longitude], [latitude], [desc_courte], [desc_longue], [nb_chambre], [nb_piece], [nb_sdb], [nb_wc], [capacite], [balcon], [airco], [wifi], [minibar], [animaux], [piscine], [voiturier], [roomService], [idProprio]) OUTPUT [inserted].[idLogement] VALUES (@prix, @nom, @adresseRue, @adresseNumero, @adresseCodePostal, @adressePays, @longitude, @latitude, @desc_courte, @desc_longue, @nb_chambre, @nb_piece, @nb_sdb, @nb_wc, @capacite, @balcon, @airco, @wifi, @minibar, @animaux, @piscine, @voiturier, @roomService, @idProprio)";
					//command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("prix", entity.prix);
					command.Parameters.AddWithValue("nom", entity.nom);
					command.Parameters.AddWithValue("adresseRue", entity.adresseRue);
					command.Parameters.AddWithValue("adresseNumero", entity.adresseNumero);
					command.Parameters.AddWithValue("adresseCodePostal", entity.adresseCodePostal);
					command.Parameters.AddWithValue("adressePays", entity.adressePays);
					command.Parameters.AddWithValue("longitude", entity.longitude); 
					command.Parameters.AddWithValue("latitude", entity.latitude); 
					command.Parameters.AddWithValue("desc_courte", entity.desc_courte); 
					command.Parameters.AddWithValue("desc_longue", entity.desc_longue); 
					command.Parameters.AddWithValue("nb_chambre", entity.nb_chambre); 
					command.Parameters.AddWithValue("nb_piece", entity.nb_piece); 
					command.Parameters.AddWithValue("nb_sdb", entity.nb_sdb); 
					command.Parameters.AddWithValue("nb_wc", entity.nb_wc); 
					command.Parameters.AddWithValue("capacite", entity.capacite); 
					command.Parameters.AddWithValue("balcon", entity.balcon); 
					command.Parameters.AddWithValue("airco", entity.airco); 
					command.Parameters.AddWithValue("wifi", entity.wifi);
					command.Parameters.AddWithValue("minibar", entity.minibar);
					command.Parameters.AddWithValue("animaux", entity.animaux);
					command.Parameters.AddWithValue("piscine", entity.piscine);
					command.Parameters.AddWithValue("voiturier", entity.voiturier);
					command.Parameters.AddWithValue("roomService", entity.roomService);
					command.Parameters.AddWithValue("idProprio", entity.idProprio);
					connection.Open();
					return (int)command.ExecuteScalar();
				}
			}
		}

		public bool Update(int id, Logement entity)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = @"UPDATE [Logement]
											SET [prix] = @prix,
												[nom] = @nom,
												[adresseRue] = @adresseRue,
												[adresseNumero] = @adresseNumero,
												[adresseCodePostal] = @adresseCodePostal,
												[adressePays] = @adressePays,
												[longitude] = @longitude,
												[latitude] = @latitude, 
												[desc_courte] = @desc_courte,
												[desc_longue] = @desc_longue,
												[nb_chambre] = @nb_chambre,
												[nb_piece] = @nb_piece,
												[nb_sdb] = @nb_sdb,
												[nb_wc] = @nb_wc, 
												[capacite] = @capacite,
												[balcon] = @balcon,
												[airco] = @airco,
												[wifi] = @wifi,
												[minibar] = @minibar,
												[animaux] = @animaux,
												[piscine] = @piscine,
												[voiturier] = @voiturier,
												[roomService] = @roomService,
												[idProprio] = @idProprio
											WHERE [idLogement] = @id";
					command.Parameters.AddWithValue("prix", entity.prix);
					command.Parameters.AddWithValue("nom", entity.nom);
					command.Parameters.AddWithValue("adresseRue", entity.adresseRue);
					command.Parameters.AddWithValue("adresseNumero", entity.adresseNumero);
					command.Parameters.AddWithValue("adresseCodePostal", entity.adresseCodePostal);
					command.Parameters.AddWithValue("adressePays", entity.adressePays);
					command.Parameters.AddWithValue("longitude", entity.longitude);
					command.Parameters.AddWithValue("latitude", entity.latitude);
					command.Parameters.AddWithValue("desc_courte", entity.desc_courte);
					command.Parameters.AddWithValue("desc_longue", entity.desc_longue);
					command.Parameters.AddWithValue("nb_chambre", entity.nb_chambre);
					command.Parameters.AddWithValue("nb_piece", entity.nb_piece);
					command.Parameters.AddWithValue("nb_sdb", entity.nb_sdb);
					command.Parameters.AddWithValue("nb_wc", entity.nb_wc);
					command.Parameters.AddWithValue("capacite", entity.capacite);
					command.Parameters.AddWithValue("balcon", entity.balcon);
					command.Parameters.AddWithValue("airco", entity.airco);
					command.Parameters.AddWithValue("wifi", entity.wifi);
					command.Parameters.AddWithValue("minibar", entity.minibar);
					command.Parameters.AddWithValue("animaux", entity.animaux);
					command.Parameters.AddWithValue("piscine", entity.piscine);
					command.Parameters.AddWithValue("voiturier", entity.voiturier);
					command.Parameters.AddWithValue("roomService", entity.roomService);
					command.Parameters.AddWithValue("idProprio", entity.idProprio);
					connection.Open();
					return command.ExecuteNonQuery() > 0;
				}
			}
		}


	}
}
