using D_Core_Layer.Services.Abstract;
using D_Infrastructure_Layer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory([FromBody] SubCategoryDTO subCategoryDTO)
        {
            if (subCategoryDTO == null)
            {
                return BadRequest("SubCategory data is null");
            }

            var result = await _subCategoryService.CreateSubCategory(subCategoryDTO);

            if(result != null && result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
