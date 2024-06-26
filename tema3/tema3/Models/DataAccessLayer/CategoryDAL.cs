﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using tema3.Models.Entities;

namespace tema3.Models.DataAccessLayer
{
    internal class CategoryDAL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";

        public void InsertCategory(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spCategoryInsert", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCategory(int categoryId, string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spCategoryUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@Name", name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spCategoryDelete", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CategoryId", categoryId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
