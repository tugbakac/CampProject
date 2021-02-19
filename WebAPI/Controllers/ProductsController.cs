using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//attribute java da annotation
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //naming convention
        //IoC -- Inversion of Control değişimin kontrolü anlamına geliyor çünkü normalde aşağıda newleyerek kullandım
        IProductService _productService;

        //parametreyi generic verdik ki management değişirse sıkıntı çıkmasın
        public ProductsController(IProductService productService)
        {
            //IProductService service = new ProductManager();
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //dependencychain -- bağımlılık zinciri
            //IProductService productService = new ProductManager(new EfProductDAL());
            var res = _productService.GetAll();
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
            
            //return new List<Product>
            //{
            //    new Product{ProductID=1, ProductName="Elma"},
            //    new Product{ProductID=2, ProductName="Armut"},                
            //};
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var res = _productService.Add(product);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("getcategorybyid")]

        public IActionResult GetCategoryById(int id)
        {
            var res = _productService.GetAllByCategoryID(id);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
