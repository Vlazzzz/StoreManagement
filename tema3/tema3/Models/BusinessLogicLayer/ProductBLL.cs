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
    public class ProductBLL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";

        public ObservableCollection<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProductSelectAll", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = (int)reader["ProductId"],
                        Name = reader["Name"].ToString(),
                        Barcode = reader["Barcode"].ToString(),
                        CategoryId = (int)reader["CategoryId"],
                        ProducerId = (int)reader["ProducerId"],
                        IsActive = (bool)reader["IsActive"],
                        CategoryName = GetCategoryNameById((int)reader["CategoryId"]),
                        ProducerName = GetProducerNameById((int)reader["ProducerId"])
                    };
                    products.Add(product);
                }

                reader.Close();
            }

            return new ObservableCollection<Product>(products);
        }

        public string GetProducerNameById(int producerId)
        {
            string producerName = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetProducerNameById", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProducerId", producerId);

                    connection.Open();
                    producerName = (string)command.ExecuteScalar();
                }
            }

            return producerName;
        }

        public string GetCategoryNameById(int categoryId)
        {
            string categoryName = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCategoryNameById", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    connection.Open();
                    categoryName = (string)command.ExecuteScalar();
                }
            }

            return categoryName;
        }

    }
}
