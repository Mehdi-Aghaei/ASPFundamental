using Refrence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 * Usully for make staff easy and clean in MVC applications we will use Interface these are functions that
 * they will tell us what we suppose to do with our data and then we can implement and use it easily
 * also in crud app the getAll method is a list to show all data
 * the serarch function have to have term to define our search rule
 * and also update,delete,Insert should get   our model to work with
 * we can use int type for delete and update because we will work with Id In DAO and for insert bool should be fine because 
 * we want to create new thing and id is auto increment
 * and for getbyId we the typeis our model because we need to get id of that
 */
namespace Refrence.Services
{
    interface IProductDataService
    {
        List<ProductModel> GetAllProducts();

        List<ProductModel> SearchProducts(string searchTerm);

        ProductModel GetProductByID(int id);

        bool Insert(ProductModel product);

        int Delete(ProductModel product);

        int Update(ProductModel product);

    }
}
