using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Domain.Models;
using Shop.API.Domain.Services;
using Shop.API.Extensions;
using Shop.API.Resources;

namespace Shop.API.Controllers
{

    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
        {
            var products = await productService.ListAsync();
            var resources = mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var product = mapper.Map<SaveProductResource, Product>(resource);
            var result = await productService.SaveAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var productResource = mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = mapper.Map<SaveProductResource, Product>(resource);
            var result = await productService.UpdateAsync(id, product);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await productService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }
    }
}