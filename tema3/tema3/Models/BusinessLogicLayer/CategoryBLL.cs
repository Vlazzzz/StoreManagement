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
    public class CategoryBLL
    {
        private string connectionString = "Server=Vlazz;Database=dbSupermarket2;Trusted_Connection=True;TrustServerCertificate=True";

        public ObservableCollection<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spCategorySelectAll", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Category category = new Category
                    {
                        CategoryId = (int)reader["CategoryId"],
                        Name = reader["Name"].ToString(),
                        IsActive = (bool)reader["IsActive"]
                    };
                    categories.Add(category);
                }

                reader.Close();
            }

            return new ObservableCollection<Category>(categories);
        }
    }
}
