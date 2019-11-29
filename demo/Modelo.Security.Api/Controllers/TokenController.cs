using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Modelo.Security.Business.Service;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System;
using Modelo.Security.Api.viewObject;
using Modelo.Security.Api.Authorization;

namespace Modelo.Security.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public TokenController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }


        [HttpPost]
        [BasicAuthorize("ivancuadrosaltamirano.com")]
        public IActionResult Post ([FromBody] UserVO userVO)
        {
            try
            {
                bool authorize = _userService.ValidateUser(userVO.username, userVO.password);
                if (!authorize)
                {
                    throw new UnauthorizedAccessException();
                }

                var token = new JsonWebTokenVO
                {
                    Expires_in = (_configuration["Auth:Jwt:TokenExpirationInMinutes"]),
                    Refresh_Token = "30 Minutes"
                };

                Response.Headers.Add("access-control-expose-headers", "Authorizarion");
                Response.Headers.Add("Authorizarion", "Bearer " + CreateToken());

                return Ok(token);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        private string CreateToken()
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[key: "Auth:Jwt:Key"]));
            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Auth:Jwt:Issuer"],
                _configuration["Auth:Jwt:Audience"],
                expires:DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Auth:Jwt:TokenExpirationInMinutes"])),
                signingCredentials:creds
                );

            var _token = new JwtSecurityTokenHandler().WriteToken(token);

            return _token;
        }

    }
}