using Refrence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
