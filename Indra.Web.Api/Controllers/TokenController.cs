using Indra.Application.Services.Jwt.Helpers;
using Indra.Application.Services.Jwt.Models;
using Indra.Web.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using Indra.Application.Services.Interfaces;

namespace Indra.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtSettings jwtSettings;
        private readonly IUserService userService;

        public TokenController(JwtSettings jwtSettings, IUserService userService)
        {
            this.jwtSettings = jwtSettings;
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken(UserLoginsDto userLogin)
        {
            try
            {
                var Token = new UserTokens();
                var user = await userService.GetUser(userLogin.UserName, userLogin.Password);
                if (user != null)
                {
                    Token = JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        EmailId = user.EmailId,
                        GuidId = Guid.NewGuid(),
                        UserName = user.UserName

                    }, jwtSettings);
                }
                else
                {
                    return BadRequest($"wrong password");
                }
                return Ok(Token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
