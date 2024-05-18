using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using tema3.Models.Entities;

namespace tema3.Models.DataAccessLayer
{
    internal class ProducerDAL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";
        public void InsertProducer(string name, string originCountry)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProducerInsert", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@OriginCountry", originCountry);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateProducer(int producerId, string name, string originCountry)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProducerUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProducerId", producerId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@OriginCountry", originCountry);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProducer(int producerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProducerDelete", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProducerId", producerId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
