using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using tema3.Models.Entities;

namespace tema3.Models.DataAccessLayer
{
    internal class ReceiptProductDAL
    {
        private string connectionString = "Server=Vlazz;Database=Supermarket;Trusted_Connection=True;";

        public List<ReceiptProducts> GetAllReceiptProducts()
        {
            List<ReceiptProducts> receiptProducts = new List<ReceiptProducts>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProductReceiptSelectAll", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReceiptProducts receiptProduct = new ReceiptProducts
                    {
                        ReceiptId = reader["ReceiptId"].ToString(),
                        ProductId = reader["ProductId"].ToString(),
                        Quantity = reader["Quantity"].ToString(),
                        Unit = reader["Unit"].ToString(),
                        SubTotal = reader["SubTotal"].ToString(),
                        IsActive = (bool)reader["IsActive"]
                    };
                    receiptProducts.Add(receiptProduct);
                }

                reader.Close();
            }

            return receiptProducts;
        }

        public void InsertReceiptProduct(string receiptId, string productId, int quantity, int unit, decimal subTotal)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProductReceiptInsert", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ReceiptId", receiptId);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@SubTotal", subTotal);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateReceiptProduct(string receiptId, string productId, int quantity, int unit, decimal subTotal)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spProductReceiptUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ReceiptId", receiptId);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@SubTotal", subTotal);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteReceiptProduct(string receiptId, string productId)
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
