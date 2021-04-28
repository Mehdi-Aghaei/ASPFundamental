using Microsoft.AspNetCore.Mvc;
using Refrence.Models;
using Refrence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refrence.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductsDAO products = new();
            return View(products.GetAllProducts());
        }
        public IActionResult SearchResults(string searchTerm)
        {
            ProductsDAO products = new();
            List<ProductModel> productList = products.SearchProducts(searchTerm);
            return View("index",productList);
        }
        public IActionResult SearchForm()
        {
            return View();
        }
    }
}
