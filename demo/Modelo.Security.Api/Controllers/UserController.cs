using Microsoft.AspNetCore.Mvc;
using Modelo.Security.Business.Service;

namespace Modelo.Security.Api.Controllers
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

        [HttpGet]
        [Route("ValidateUser/{username}/{password}")]
        public ActionResult ValitateUser(string username, string password)
        {
            bool authorize = _userService.ValidateUser(username, password);

            if (!authorize)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}