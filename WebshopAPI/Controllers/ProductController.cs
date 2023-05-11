using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;
        private readonly IMapper mapper;
        public ProductController(ProductService productService, IMapper mapper)
        {
                this.productService = productService;
                this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productService.GetAllProducts();

            var productsDTO = mapper.Map<List<Models.DTOs.ProductDto>>(products);

            return Ok(productsDTO);

        }
    }
}
