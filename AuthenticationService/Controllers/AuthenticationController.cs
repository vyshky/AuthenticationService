using AuthenticationService.Domain.Model;
using AuthenticationService.Model;
using AuthenticationService.Services.Authentication;
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
        public AuthenticationController(IAuthenticationService authService)
        {
            this.authService = authService;
        }

        [HttpPost(nameof(CreateUser))]
        public IActionResult CreateUser([FromBody] CreateModel data)
        {
            IdentificationEntity ident = authService.CreateUser(data);
            return
                ident != null ?
                Ok(new { User = ident, Message = "Success" }) :
                BadRequest("Please pass the valid Username and Password");
        }

        [HttpPost(nameof(GetToken))]
        public IActionResult GetToken([FromBody] LoginModel data)
        {
            IdentificationEntity ident = authService.FindUserOrDefault(data);
            return ident != null ?
                Ok(new { Token = authService.GetToken(ident), Message = "Success" }) :
                BadRequest("Please pass the valid Username and Password");
        }


        [HttpPost(nameof(TestBearer))]
        [Authorize(Roles = "admin,user")]
        public IActionResult TestBearer()
        {
            return Ok("Success");
        }


    }
}
