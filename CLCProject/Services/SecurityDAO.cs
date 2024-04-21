using CLCProject.Models;
using System;
using Microsoft.Data.SqlClient; // Change from System.Data.SqlClient

namespace CLCProject.Services
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;MultiSubnetFailover=False";

        public bool FindUserByNameAndPassword(UserModel user)
        {
            bool success = false;

            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username and password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 50).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        success = true;

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }
    }
}
