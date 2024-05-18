using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using tema3.Models.Entities;

namespace tema3.Models.DataAccessLayer
{
    public class ProductDAL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";

        public void InsertProduct(string name, string barcode, int categoryId, int producerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProductInsert", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Barcode", barcode);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@ProducerId", producerId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(string productId, string name, string barcode, int categoryId, int producerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProductUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Barcode", barcode);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@ProducerId", producerId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProductDelete", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
