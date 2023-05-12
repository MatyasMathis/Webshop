using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;
        private readonly CategoryService categoryService;
        private readonly IMapper mapper;
        public ProductController(ProductService productService, IMapper mapper, CategoryService categoryService)
        {
                this.productService = productService;
                this.mapper = mapper;
                this.categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productService.GetAllProducts();

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var productsJson = JsonSerializer.Serialize(products, jsonOptions);

            return Content(productsJson, "application/json");

        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(Models.DTOs.UploadProductDto productDto)
        {
            //Request to domain model
            var product = new Models.Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price= productDto.Price,
                CategoryId= productDto.CategoryId,
            };
           
            //Pass deatails to Repository

            await productService.UploadProduct(product);

            //Convert back to DTO

            var newProductDto = new Models.DTOs.ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId=product.CategoryId
                
            };
            return Ok(newProductDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var product = await productService.GetProductById(id);
            if (product == null)
            {
                return BadRequest();
            }
            var productDto = new Models.DTOs.ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Category=product.Category

            };
            return Ok(productDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
        {
            var toDelete = await productService.DeleteProduct(id);
            if (toDelete == null)
            {
                return BadRequest();
            }

            var toDeleteDTO = mapper.Map<Models.DTOs.ProductDto>(toDelete);

            return Ok(toDeleteDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, Models.DTOs.ProductDto prodToUpdate)
        {
            var prod = new Models.Product
            {
                Id = id,
                Name = prodToUpdate.Name,
                Description = prodToUpdate.Description,
                CategoryId= prodToUpdate.CategoryId

            };
            await productService.UpdateProduct(id, prod);

            var prodDTO = mapper.Map<Models.DTOs.ProductDto>(prod);
            return Ok(prodDTO);
        }
    }
}
