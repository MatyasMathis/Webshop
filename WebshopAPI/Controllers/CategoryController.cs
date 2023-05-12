using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Models.DTOs;
using WebshopAPI.Services;

namespace WebshopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        #region Fields
        private readonly ICategoryService _categoryService;
        #endregion

        #region Constructors
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #endregion

        #region Public members
        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddCategoryAsync(AddCategoryDto categoryDto)
        {
            return Ok(await _categoryService.AddAsync(categoryDto));
        }

        [HttpDelete]
        [Route("delete/{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] Guid id)
        {
            var hasBeenDeleted = await _categoryService.DeleteAsync(id);
            if (!hasBeenDeleted)
                return BadRequest("No entry found with the given id");
            return Ok();
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            return Ok(await _categoryService.GetAllAsync<CategoryDto>());
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateCategoryAsync(CategoryDto payload)
        {
            var hasBeenUpdated = await _categoryService.UpdateAsync(payload.Id, payload);
            if (!hasBeenUpdated)
                return BadRequest("No entry found with the given id");
            return Ok();
        }
        #endregion
    }
}
