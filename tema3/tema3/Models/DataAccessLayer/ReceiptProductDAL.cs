using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using tema3.Models.Entities;

namespace tema3.Models.DataAccessLayer
{
    internal class ReceiptProductDAL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";

        public List<ReceiptProduct> GetAllReceiptProducts()
        {
            List<ReceiptProduct> receiptProducts = new List<ReceiptProduct>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProductReceiptSelectAll", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReceiptProduct receiptProduct = new ReceiptProduct
                    {
                        ReceiptId = (int)reader["ReceiptId"],
                        ProductId = (int)reader["ProductId"],
                        Quantity = (int)reader["Quantity"],
                        Unit = (string)reader["Unit"],
                        Subtotal = (decimal)reader["Subtotal"],
                        IsActive = (bool)reader["IsActive"]
                    };
                    receiptProducts.Add(receiptProduct);
                }

                reader.Close();
            }

            return receiptProducts;
        }

        public void InsertReceiptProduct(int receiptId, int productId, int quantity, string unit, decimal subTotal)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProductReceiptInsert", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ReceiptId", receiptId);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Subtotal", subTotal);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateReceiptProduct(int receiptId, int productId, int quantity, string unit, decimal subTotal)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProductReceiptUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ReceiptId", receiptId);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Subtotal", subTotal);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteReceiptProduct(int receiptId, int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProductReceiptDelete", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ReceiptId", receiptId);
                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
