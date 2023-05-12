using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Models;
using WebshopAPI.Models.DTOs;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Fields
        private readonly CategoryService categoryService;
        private readonly IMapper mapper;
        private readonly ProductService productService;
        #endregion

        #region Constructors
        public ProductController(ProductService productService, IMapper mapper, CategoryService categoryService)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.categoryService = categoryService;
        }
        #endregion

        #region Public members
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(UploadProductDto productDto)
        {
            //Request to domain model
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
            };

            //Pass deatails to Repository

            await productService.UploadProduct(product);

            //Convert back to DTO

            var newProductDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
            return Ok(newProductDto);
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

            var toDeleteDTO = mapper.Map<ProductDto>(toDelete);

            return Ok(toDeleteDTO);
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

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var product = await productService.GetProductById(id);
            if (product == null)
            {
                return BadRequest();
            }
            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Category = product.Category
            };
            return Ok(productDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductDto prodToUpdate)
        {
            var prod = new Product
            {
                Id = id,
                Name = prodToUpdate.Name,
                Description = prodToUpdate.Description,
                CategoryId = prodToUpdate.CategoryId
            };
            await productService.UpdateProduct(id, prod);

            var prodDTO = mapper.Map<ProductDto>(prod);
            return Ok(prodDTO);
        }
        #endregion
    }
}
