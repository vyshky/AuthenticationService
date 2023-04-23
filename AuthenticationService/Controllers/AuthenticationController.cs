using AuthenticationService.Domain.Model;
using AuthenticationService.Model;
using AuthenticationService.Services.Authentication;
using AuthenticationService.Services.Token;
using ChatServerApi.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        IAuthenticationService authService;
        IToken token;
        public AuthenticationController(IAuthenticationService authService, IToken token)
        {
            this.authService = authService;
            this.token = token;
        }

        [HttpPost(nameof(CreateUser))]
        public IActionResult CreateUser([FromBody] CreateModel data)
        {
            IdentificationEntity ident = authService.CreateUser(data);
            if (ident != null)
            {
                return Ok(new { User = ident, Message = "Created User" });
            }
            return BadRequest("Please pass the valid Username and Password");
        }

        [HttpPost(nameof(GetToken))]
        public IActionResult GetToken([FromBody] LoginModel data)
        {
            IdentificationEntity ident = authService.IsValidUserInformation(data);
            if (ident != null)
            {
                var tokenString = token.Get(ident);
                return Ok(new { Token = tokenString, Message = "Success" });
            }
            return BadRequest("Please pass the valid Username and Password");
        }


        [HttpPost(nameof(TestBearer))]
        [Authorize(Roles = "admin,user")]
        public IActionResult TestBearer()
        {
            return Ok("Success");
        }


    }
}
