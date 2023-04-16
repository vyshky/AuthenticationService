using AuthenticationService.Domain.Model;
using AuthenticationService.Model;
using ChatServerApi.Domain.Entity;

namespace AuthenticationService.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Identification IsValidUserInformation(LoginModel data);
        public Identification CreateUser(CreateModel data);
    }
}