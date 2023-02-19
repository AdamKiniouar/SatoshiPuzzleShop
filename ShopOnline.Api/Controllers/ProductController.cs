using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;
using System.Net;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            try
            {
                var products = await productRepository.GetProducts();

                if (products == null)
                { 
                   return NotFound();
                }
                else
                {
                    var productDtos = products.ConvertToDto();

                    return Ok(productDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
               
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            try
            {
                var product = await productRepository.GetProductById(id);
               
                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    
                    var productDto = product.ConvertToDto();

                    return Ok(productDto);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }

        [HttpGet]
        [Route(nameof(GetProductCategories))]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategories()
        {
            try
            {
                var productCategories = await productRepository.GetCategories();
                
                var productCategoryDtos = productCategories.ConvertToDto();

                return Ok(productCategoryDtos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }

        }

        [HttpGet]
        [Route("{categoryId}/GetItemsByCategory")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategory(int categoryId)
        {
            try
            {
                var products = await productRepository.GetProductsByCategory(categoryId);

                var productDtos = products.ConvertToDto();

                return Ok(productDtos);
            
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }


        [HttpPut("{id:int}/activate")]
        public async Task<ActionResult> ActivateProduct(int id)
        {
            var response = await productRepository.ActivateProductById(id);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id:int}/deactivate")]
        public async Task<ActionResult> DeActivateProduct(int id)
        {
            var response = await productRepository.DeActivateProductById(id);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
