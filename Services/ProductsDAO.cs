using Refrence.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Refrence.Services
{
    public class ProductsDAO : IProductDataService
        
        // DAO Data access object
    {
        

        string conncetionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=main;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }
        public List<ProductModel> GetAllProducts()
        {
            // create list to store data
            List<ProductModel> foundProducts = new();
            // sql statment will use it command that get text and connection
            string SqlStatment = "SELECT * FROM [dbo].[Products] ";
            // using to finish task at the end of block and use SqlClient and from that we will create connetion
            using(SqlConnection connection = new(conncetionStr))
            {
                SqlCommand command = new(SqlStatment, connection);
         // try catch block for eror handeling and  clean
         // we have to open connection and then create reader 
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    // we will read from data base and then add it to list
                    // we will cast input because we will get object 
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Info= (string)reader[3] });
                            
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }


            }
            return foundProducts;
        }

        public ProductModel GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {

            List<ProductModel> foundProducts = new();
            // name like name is preped statment
            string SqlStatment = "SELECT * FROM [dbo].[Products] WHERE name LIKE @name ";

            using (SqlConnection connection = new(conncetionStr))
            {
                SqlCommand command = new(SqlStatment, connection);
                command.Parameters.AddWithValue("@name", '%' + searchTerm + '%');
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Info = (string)reader[3] });

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }


            }
            return foundProducts;
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
