using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tema3.Models.Entities;

namespace tema3.Models.BusinessLogicLayer
{
    public class ProducerBLL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";

        public ObservableCollection<Producer> GetAllProducers()
        {
            List<Producer> producers = new List<Producer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProducerSelectAll", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Producer producer = new Producer
                    {
                        ProducerId = (int)reader["ProducerId"],
                        Name = reader["Name"].ToString(),
                        OriginCountry = reader["OriginCountry"].ToString(),
                        IsActive = (bool)reader["IsActive"]
                    };
                    producers.Add(producer);
                }

                reader.Close();
            }

            return new ObservableCollection<Producer>(producers);
        }
    }
}
