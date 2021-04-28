using Refrence.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Refrence.Services
{
    public class UsersDAO

    {
        string conncetionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=main;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool FindUserByUserNameAndPassword(UserModel user)
        {
            bool success = false;
            // always check sql statment with database
            string SqlStatment = "SELECT * FROM [dbo].[User] WHERE username=@username AND password=@password";
            // we use using because it will close automaticly at the enf of block
            using (SqlConnection connection = new(conncetionStr))
            {
                SqlCommand command = new(SqlStatment, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        success = true;
                    }

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                return success;
            }

        }
    }
}
