using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using tema3.Models.Entities;

namespace tema3.Models.DataAccessLayer
{
    internal class StockDAL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";

        public void InsertStock(int productId, int quantity, string unit, DateTime supplyDate, DateTime expiryDate, decimal purchasePrice)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spStockInsert", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@SupplyDate", supplyDate);
                command.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                command.Parameters.AddWithValue("@PurchasePrice", purchasePrice);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateStock(int stockId, int productId, int quantity, string unit, DateTime supplyDate, DateTime expiryDate, decimal purchasePrice)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spStockUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StockId", stockId);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@SupplyDate", supplyDate);
                command.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                command.Parameters.AddWithValue("@PurchasePrice", purchasePrice);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteStock(int stockId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spStockDelete", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StockId", stockId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
