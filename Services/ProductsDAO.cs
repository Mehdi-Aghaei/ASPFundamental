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
            List<ProductModel> foundProducts = new();
            string SqlStatment = "SELECT * FROM [dbo].[Products] ";
            using(SqlConnection connection = new(conncetionStr))
            {
                SqlCommand command = new(SqlStatment, connection);
         
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
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
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
