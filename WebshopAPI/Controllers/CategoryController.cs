using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Repositories;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers
{
    [ApiController]
    //[Route("Regions")]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;
        private readonly IMapper mapper;
        
        public CategoryController(IMapper mapper, CategoryService categoryService)
        {
            this.categoryService = categoryService;

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

            await categoryService.UploadCategory(category);

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
            var categories=await categoryService.GetAllCategories();

            var categoriesDTO = mapper.Map<List<Models.DTOs.CategoryDto>>(categories);

            return Ok(categoriesDTO);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCatAsync([FromRoute] Guid id)
        {
            var toDelete = await categoryService.DeleteCategory(id);
            if (toDelete == null)
            {
                return BadRequest();
            }

            var toDeleteDTO = mapper.Map<Models.DTOs.CategoryDto>(toDelete);

            return Ok(toDeleteDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid id, Models.DTOs.CategoryDto catToUpdate)
        {
            var cat = new Models.Category
            {
                Id = id,
                Name= catToUpdate.Name,
                Description= catToUpdate.Description,

            };
            await categoryService.UpdateCategory(id, cat);

            var catDTO = mapper.Map<Models.DTOs.CategoryDto>(cat);
            return Ok(catDTO);
        }
    }
}
