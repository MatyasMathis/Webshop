using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Models;
using WebshopAPI.Models.DTOs;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers
{
    [ApiController]
    //[Route("Regions")]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        #region Fields
        private readonly CategoryService categoryService;
        private readonly IMapper mapper;
        #endregion

        #region Constructors
        public CategoryController(IMapper mapper, CategoryService categoryService)
        {
            this.categoryService = categoryService;

            this.mapper = mapper;
        }
        #endregion

        #region Public members
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(AddCategoryDto categoryDto)
        {
            //Request to domain model
            var category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
            };

            //Pass deatails to Repository

            await categoryService.UploadCategory(category);

            //Convert back to DTO

            var newCategoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = categoryDto.Description,
            };
            return Ok(newCategoryDto);
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

            var toDeleteDTO = mapper.Map<CategoryDto>(toDelete);

            return Ok(toDeleteDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryService.GetAllCategories();

            var categoriesDTO = mapper.Map<List<CategoryDto>>(categories);

            return Ok(categoriesDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryDto catToUpdate)
        {
            var cat = new Category
            {
                Id = id,
                Name = catToUpdate.Name,
                Description = catToUpdate.Description,
            };
            await categoryService.UpdateCategory(id, cat);

            var catDTO = mapper.Map<CategoryDto>(cat);
            return Ok(catDTO);
        }
        #endregion
    }
}
