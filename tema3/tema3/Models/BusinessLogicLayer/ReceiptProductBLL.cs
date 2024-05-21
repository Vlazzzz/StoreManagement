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
    public class ReceiptProductBLL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";

        public ObservableCollection<ReceiptProduct> GetAllReceiptProducts()
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
                        IsActive = (bool)reader["IsActive"],
                        ProductName = GetProductNameById((int)reader["ProductId"])
                    };
                    receiptProducts.Add(receiptProduct);
                }

                reader.Close();
            }

            return new ObservableCollection<ReceiptProduct>(receiptProducts);
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
