using Microsoft.AspNetCore.Mvc;
using Refrence.Models;
using Refrence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 * we will use all methods from service class here and we can create view of that or form or list
 * we can create method that get model or int(id) to work with and then we can say in which template we wanto to see it
 * also the first thing we have to use is to initialize or service(DAO) as global and then constructor first and then use methods
 * and the viw method can get template name in String and a method also 
 * and also we have to think how we can use this method 
 * we want to send it somewhere or its just query data from data base we want to update or delete and ... and usually we use forms to post data in in anothr method by call it 
 * in asp-action in template
 */
namespace Refrence.Controllers
{
    public class ProductController : Controller
    {
        public IProductDataService repository { get; set; }
        public ProductController(IProductDataService dataService)
        {
            // we can  easily change data sourse in startup and it will automaticly inject here
            repository = dataService;
        }

        // ProductsDAO repository;
        public IActionResult Index()
        {
            return View(repository.GetAllProducts());
        }
        public IActionResult SearchResults(string searchTerm)
        {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);
            return View("Index", productList);
        }
        public IActionResult ShowDetails(int id)
        {
            ProductModel foundProduct = repository.GetProductByID(id);
            return View(foundProduct);
        }
        public IActionResult Edit(int id)
        {

            ProductModel foundProduct = repository.GetProductByID(id);
            return View("ShowEdit", foundProduct);
        }
        // what we accept is goes to that argument that function will take
        public IActionResult ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            return View("Index", repository.GetAllProducts());

        }
        public IActionResult Delete(int id)
        {
            ProductModel product = repository.GetProductByID(id);
            repository.Delete(product);
            return View("Index", repository.GetAllProducts());

        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult ProcessCreate(ProductModel product)
        {
            repository.Insert(product);
            return View("Index", repository.GetAllProducts());
        }


        public IActionResult SearchForm()
        {
            return View();
        }
        public IActionResult ShowDetailsJson(int id)
        {
            ProductModel foundProduct = repository.GetProductByID(id);
            return Json(foundProduct);
        }
        public IActionResult ProcessEditReturnPartial(ProductModel product)
        {
            repository.Update(product);
            return PartialView("_productCard", product);

        }

    }
}
