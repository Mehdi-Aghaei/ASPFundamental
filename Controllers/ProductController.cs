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
            return View("Index",productList);
        }
        public IActionResult ShowDetails(int id)
        {
            ProductsDAO products = new();
            ProductModel foundProduct = products.GetProductByID(id);
            return View(foundProduct);
        }
        public IActionResult Edit(int id)
        {
            ProductsDAO products = new();
            ProductModel foundProduct = products.GetProductByID(id);
            return View("ShowEdit",foundProduct);
        }
        // what we accept is goes to that argument that function will take
        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new();
            products.Update(product);
            return View("Index",products.GetAllProducts());

        }
        public IActionResult Delete(int id)
        {
            ProductsDAO products = new();
            ProductModel product = products.GetProductByID(id);
            products.Delete(product);
            return View("Index",products.GetAllProducts());

        }
        public IActionResult Create() 
        {
            return View();
        }
        public IActionResult ProcessCreate(ProductModel product)
        {
            ProductsDAO products = new();
            products.Insert(product);
            return View("Index", products.GetAllProducts());
        }


        public IActionResult SearchForm()
        {
            return View();
        }
    }
}
