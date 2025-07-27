using D_Core_Layer.Services.Abstract;
using D_Infrastructure_Layer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoryController : ControllerBase
    {
        private readonly IMainCategoryService _mainCategoryService;

        public MainCategoryController(IMainCategoryService mainCategoryService)
        {
            _mainCategoryService = mainCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMainCategory([FromBody] MainCategoryDTO categoryDTO)
        {
            var response= await _mainCategoryService.CreateMainCategory(categoryDTO);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Failed to create main category.");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _mainCategoryService.GetMainCategories();
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("No main categories found.");
            }
        }
    }
}
