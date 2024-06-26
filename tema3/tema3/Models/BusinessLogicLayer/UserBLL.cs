﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using tema3.Models.Entities;

namespace tema3.Models.BusinessLogicLayer
{
    public class UserBLL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";

        public ObservableCollection<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spUserSelectAll", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = (int)reader["UserId"],
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        UserType = (bool)(reader["UserType"]),
                        IsActive = (bool)reader["IsActive"]
                    };
                    users.Add(user);
                }

                reader.Close();
            }

            return new ObservableCollection<User>(users);
        }
        public bool CheckUserCredentials(string username, string password)
        {
            int userCount = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spCheckUserCredentials", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlParameter userCountParam = new SqlParameter("@UserCount", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(userCountParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    userCount = (int)userCountParam.Value;

                    return userCount > 0;
                }
            }
        }

        public bool CheckUserType(string username, string password, out bool isAdmin)
        {
            isAdmin = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spCheckUserType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlParameter isAdminParam = new SqlParameter("@IsAdmin", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(isAdminParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    isAdmin = (bool)isAdminParam.Value;
                    conn.Close();

                    return true; // Procedura stocată a fost executată cu succes
                }
            }
        }
    }
}
