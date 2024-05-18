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
    public class StockBLL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";

        public ObservableCollection<Stock> GetAllStocks()
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
                        IsActive = (bool)reader["IsActive"],
                        // Obtinem numele produsului folosind metoda sincrona
                        ProductName = GetProductNameById((int)reader["ProductId"])
                    };
                    stocks.Add(stock);
                }

                reader.Close();
            }

            return new ObservableCollection<Stock>(stocks);
        }

        public string GetProductNameById(int productId)
        {
            string productName = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetProductNameById", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductId", productId);

                    connection.Open();
                    productName = (string)command.ExecuteScalar();
                }
            }

            return productName;
        }

    }
}
