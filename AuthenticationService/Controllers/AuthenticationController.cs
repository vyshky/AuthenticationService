using AuthenticationService.Domain.Model;
using AuthenticationService.Model;
using AuthenticationService.Services.Authentication;
using ChatServerApi.Domain.Entity;
using Microsoft.AspNetCore.Cors;
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
            if(!data.IsValid()) return BadRequest("Please pass the valid Username and Password");
            IdentificationEntity ident = authService.FindUserOrDefault(data);
            return ident != null ?
                Ok(new { Token = authService.GetToken(ident), Message = "Success" }) :
                BadRequest("Please pass the valid Username and Password");
        }
        

        [HttpGet(nameof(GetToken2))]
        public IActionResult GetToken2()
        {
            return Ok(new { Token = "12312412", Message = "Success" });
        }
    }
}
