using CourseLibrary.API.Entities;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PracticeProductsAPI.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeProductsAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    [EnableCors("AllowOrigin")]

    public class ProductController : ControllerBase
    {
        private readonly IPracticeProductsRepository _practiceProductsRepository;
        public ProductController(IPracticeProductsRepository practiceProductsRepository)
        {
            _practiceProductsRepository = practiceProductsRepository ??
                throw new ArgumentNullException(nameof(practiceProductsRepository));

        }

        //[HttpGet()]
        //public IActionResult GetProducts()

        //{
        //    var products = _practiceProductsRepository.GetProducts();
        //    return Ok(products);
        //}


        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var product = _practiceProductsRepository.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpGet()]
        public ActionResult<IEnumerable<Product>> GetProducts(
                     [FromQuery] ProductsResourceParameters productsResourceParameters)
        {
            var products = _practiceProductsRepository.GetProducts(productsResourceParameters);
            return Ok(products);
        }


        [HttpPost]
        public ActionResult<IEnumerable<Product>> CreateProductCollection(IEnumerable<Product> productCollection)
        {
            foreach (var product in productCollection)
            {
                _practiceProductsRepository.AddProduct(product);
            }

            _practiceProductsRepository.Save();

            return Ok();

        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId, Product productToUpdate)
        {
            productToUpdate.Id = productId;
            if (!_practiceProductsRepository.UpdateProduct(productToUpdate))
            {
                return NotFound();
            }
                _practiceProductsRepository.Save();
                return Ok();
        }

        [HttpDelete("{productId}")]
        public ActionResult DeleteProduct(int productId)
        {
            var product = _practiceProductsRepository.GetProduct(productId);

            if (product == null)
            {
                return NotFound();
            }
            _practiceProductsRepository.DeleteProduct(productId);
            _practiceProductsRepository.Save();
            return Ok();
        }
    }
}
