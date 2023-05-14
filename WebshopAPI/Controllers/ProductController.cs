using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Models.DTOs;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        #region Fields
        private readonly IProductService _productService;
        #endregion

        #region Constructors
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        #region Public members
        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddProductAsync(UploadProductDto payload)
        {
            return Ok(await _productService.AddAsync(payload));
        }

        [HttpPost]
        [Route("buy")]
        [Authorize(Roles = "user,admin")]
        public async Task<IActionResult> BuyProductAsync([FromBody] BuyProductDto payload)
        {
            var userEmail = User.Claims.First(i => i.Type == ClaimTypes.Email).Value;
            var result = await _productService.BuyProductAsync(userEmail, payload);
            if (result == false)
                return BadRequest("Invalid user or product id.");
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
        {
            var result = await _productService.DeleteAsync(id);
            if (result == false)
                return BadRequest("Missing entity with given id.");
            return Ok();
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            return Ok(await _productService.GetAllAsync<ProductDto>());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] Guid id)
        {
            var product = await _productService.GetByIdAsync<ProductDto>(id);
            if (product == null)
                return BadRequest();
            return Ok(product);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchProductsAsync(string searchString)
        {
            return Ok(await _productService.SearchProductsAsync(searchString));
        }

        [HttpPut]
        [Route("update/{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductDto prodToUpdate)
        {
            var result = await _productService.UpdateAsync(id, prodToUpdate);
            if (result == false)
                return BadRequest("Missing entity with given id.");
            return Ok();
        }
        #endregion
    }
}
