using D_Core_Layer.Services.Abstract;
using D_Persistence_Layer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D_API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("(SignUp)")]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid user data.");
            }

            var result = await _userService.Register(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("SgniIn")]
        public async Task<IActionResult> SignIn([FromBody] LoginModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid user data.");
            }

            var result = await _userService.Login(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
