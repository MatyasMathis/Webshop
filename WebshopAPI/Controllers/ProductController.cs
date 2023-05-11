using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Repositories;

namespace WebshopAPI.Controllers
{
    [ApiController]
    //[Route("Regions")]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(Models.DTOs.AddCategoryDto categoryDto)
        {
            //Request to domain model
            var category = new Models.Category
            {
                Name= categoryDto.Name,
                Description= categoryDto.Description,
            };


            //Pass deatails to Repository

            await categoryRepository.Uploadcategory(category);

            //Convert back to DTO

            var newCategoryDto = new Models.DTOs.CategoryDto
            {
                Id = category.Id,
               Name= category.Name,
               Description= categoryDto.Description,
            };
            return Ok(newCategoryDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories=await categoryRepository.GetAllCategories();



            var categoriesDTO = mapper.Map<List<Models.DTOs.CategoryDto>>(categories);

            return Ok(categoriesDTO);

        }
    }
}
