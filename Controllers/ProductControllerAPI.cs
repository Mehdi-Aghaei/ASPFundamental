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
    [ApiController]
    [Route("api/")]
    // in route also you can write controller but we just  have one
    public class ProductControllerAPI : ControllerBase
    // controllerBase is one level before controller
    {
        ProductsDAO repository;
        public ProductControllerAPI()
        {
            repository = new();
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Index()
        // IEnumerable is better than list and 
        // but also we can use List
        {
            return repository.GetAllProducts();
        }

        [HttpGet("SearchResults/{searchTerm}")]
        // we can also set route for our request and brace is that means is optional
        public ActionResult<IEnumerable<ProductModel>> SearchResults(string searchTerm)
        {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);
            return productList;
        }

        [HttpGet("ShowDetails/{Id}")]
        // it will return one object and we just use Product model as type
        public ActionResult<ProductModel> ShowDetails(int Id)
        {
            ProductModel foundProduct = repository.GetProductByID(Id);
            return foundProduct;
        }
        [HttpPost("ProcessCreate")]
        // post action
        // expecting a product in json format in the body of the request
        public ActionResult<bool> ProcessCreate(ProductModel product)
        {
            // we have to write type in <> when we use Action result
            bool status = repository.Insert(product);
            return status;
        }
        [HttpPut("ProcessEdit")]
        // put Request
        // expect a json formattet object in the bodt of request, id  number must match the item being modified.
        public ActionResult<ProductModel> ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            // to double check
            return repository.GetProductByID(product.Id);

        }
        [HttpDelete("Delete/{id}")]
        public ActionResult<int> Delete(int id)
        {
            ProductModel product = repository.GetProductByID(id);
            int IdNumber = repository.Delete(product);
            return IdNumber;

        }

    }
}
