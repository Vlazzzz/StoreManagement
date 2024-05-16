using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using tema3.Models.Entities;

namespace tema3.Models.DataAccessLayer
{
    internal class StockDAL
    {
        private string connectionString = "Server=Vlazz;Database=Supermarket;Trusted_Connection=True;";

        public List<Stock> GetAllStocks()
        {
            List<Stock> stocks = new List<Stock>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spStockSelectAll", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Stock stock = new Stock
                    {
                        StockId = (int)reader["StockId"],
                        ProductId = (int)reader["ProductId"],
                        Quantity = (int)(reader["Quantity"]),
                        Unit = (string)(reader["Unit"]),
                        SupplyDate = (DateTime)(reader["SupplyDate"]),
                        ExpiryDate = (DateTime)(reader["ExpiryDate"]),
                        PurchasePrice = (decimal)(reader["PurchasePrice"]),
                        IsActive = (bool)reader["IsActive"]
                    };
                    stocks.Add(stock);
                }

                reader.Close();
            }

            return stocks;
        }

        public void InsertStock(string productId, int quantity, int unit, DateTime supplyDate, DateTime expiryDate, decimal purchasePrice)
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

        public void UpdateStock(int stockId, string productId, int quantity, int unit, DateTime supplyDate, DateTime expiryDate, decimal purchasePrice)
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
