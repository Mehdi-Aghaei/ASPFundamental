using Refrence.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
/*
 *         // DAO or Data access object
 *         Its kind of service that implement our Interface and we will give it some reall functionality here
 *         to work with data base first we have create a connection string and we can get that from data base 
 *         don't forget @ :) then one by one we have to work with our methods that we define in Interface
 *         if the function type was int or bool we have to take a model to work with
 *         if it was list(is usually with type of our model) we have to init our list in that method
 *         and if the type was our model we usually take id with type of ints as argument
 *         then we have to write our SQLSTATMENT which can be update,delete,Insert,Select
 *         then we will use using method wich we have to define SqlConnection there and assign our connectionStr to that
 *         then we have to define Sqlcommand and we have to assig our statment and connection to that
 *         and the that command have lots of attrbute to work with
 *         then we have to create try catch block for exeption handeling and in try block we have to open a connection and 
 *         the point of using of using method is it will automaticy close that for us
 *         and Don't forget to return a type of method at the end of try catch block
 *         ExecuteReader when return rows usually for find all or search or get by id and we have to define SqlDataReader
 *         ExecuteNonQuery row efected


 */

namespace Refrence.Services
{
    public class ProductsDAO : IProductDataService

    {


        string conncetionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=main;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool Delete(ProductModel product)
        {
            bool isDone = false;
            string SqlStatment = "DELETE FROM [dbo].[Products] WHERE Id = @Id";

            using (SqlConnection connection = new(conncetionStr))
            {
                SqlCommand command = new(SqlStatment, connection);
                command.Parameters.AddWithValue("@Id", product.Id);
                try
                {

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == false)
                    {
                        isDone = true;
                    }
                    // return first col and first row wich is ussually id
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }


            }
            return isDone;



        }
        public List<ProductModel> GetAllProducts()
        {
            // create list to store data
            List<ProductModel> foundProducts = new();
            // sql statment will use it command that get text and connection
            string SqlStatment = "SELECT * FROM [dbo].[Products] ";
            // using to finish task at the end of block and use SqlClient and from that we will create connetion
            using (SqlConnection connection = new(conncetionStr))
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
                        foundProducts.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Info = (string)reader[3] });

                    }
                    // closeing reader always is good :)
                    reader.Close();
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
            ProductModel foundProduct = null;
            // name like name is preped statment
            string SqlStatment = "SELECT * FROM [dbo].[Products] WHERE Id = @Id ";

            using (SqlConnection connection = new(conncetionStr))
            {
                SqlCommand command = new(SqlStatment, connection);
                command.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProduct = new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Info = (string)reader[3] };

                    }
                    reader.Close();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }


            }
            return foundProduct;

        }

        public int Insert(ProductModel product)
        {
            int rowsAffected = -1;
            string SqlStatment = @"INSERT INTO [dbo].[Products] (name, price, info) VALUES (@name, @price, @info)";

            using (SqlConnection connection = new(conncetionStr))
            {
                SqlCommand command = new(SqlStatment, connection);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@info", product.Info);
                //command.Parameters.AddWithValue("@Id", product.Id);
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                    // read comments in update about that
                    //newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                    // return first col and first row wich is ussually id
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }


            }// dont forget to returns
            return rowsAffected;

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
                    reader.Close();
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
            int rowsAffected = -1;
            string SqlStatment = "UPDATE [dbo].[Products] SET name = @name, price = @price, info = @info WHERE Id = @Id";

            using (SqlConnection connection = new(conncetionStr))
            {
                SqlCommand command = new(SqlStatment, connection);
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Id"].Value = product.Id;
                // with Add we have more options to make sure and add with value is simpler
                //command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@info", product.Info);

                try
                {
                    connection.Open();
                    // Executes a Transact-SQL statement against the connection and returns the number of rows affected.
                    rowsAffected = command.ExecuteNonQuery();
                    //newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                    // excuteScalar return first col and first row wich is ussually id old method
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }


            }
            return rowsAffected;

        }
    }
}
