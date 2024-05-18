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
    public class ReceiptBLL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";
        public ObservableCollection<Receipt> GetAllReceipts()
        {
            List<Receipt> receipts = new List<Receipt>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spReceiptSelectAll", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Receipt receipt = new Receipt
                    {
                        ReceiptId = (int)reader["ReceiptId"],
                        UserId = (int)reader["UserId"],
                        IssueDate = (DateTime)reader["IssueDate"],
                        AmountReceived = (int)reader["AmountReceived"],
                        IsActive = (bool)reader["IsActive"]
                    };
                    receipts.Add(receipt);
                }

                reader.Close();
            }

            return new ObservableCollection<Receipt>(receipts);
        }
    }
}
