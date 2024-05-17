using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using tema3.Models.Entities;

namespace tema3.Models.DataAccessLayer
{
    internal class ReceiptDAL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";

        public List<Receipt> GetAllReceipts()
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

            return receipts;
        }

        public void InsertReceipt(int userId, DateTime issueDate, decimal amountReceived)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spReceiptInsert", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@IssueDate", issueDate);
                command.Parameters.AddWithValue("@AmountReceived", amountReceived);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateReceipt(int receiptId, int userId, DateTime issueDate, decimal amountReceived)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spReceiptUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ReceiptId", receiptId);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@IssueDate", issueDate);
                command.Parameters.AddWithValue("@AmountReceived", amountReceived);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteReceipt(int receiptId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spReceiptDelete", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ReceiptId", receiptId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
