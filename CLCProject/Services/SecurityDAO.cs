using CLCProject.Models;
using System;
using Microsoft.Data.SqlClient;

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

        public void InsertUser(RegistrationModel model)
        {
            string sqlStatement = "INSERT INTO dbo.RegisteredUsers (FirstName, LastName, Sex, Age, State, Email, UserName, Password) " +
                                  "VALUES (@FirstName, @LastName, @Sex, @Age, @State, @Email, @UserName, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@Sex", model.Sex);
                command.Parameters.AddWithValue("@Age", model.Age);
                command.Parameters.AddWithValue("@State", model.State);
                command.Parameters.AddWithValue("@Email", model.Email);
                command.Parameters.AddWithValue("@UserName", model.UserName);
                command.Parameters.AddWithValue("@Password", model.Password);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
