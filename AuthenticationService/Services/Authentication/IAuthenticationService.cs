using AuthenticationService.Domain.Model;
using AuthenticationService.Model;
using ChatServerApi.Domain.Entity;

namespace AuthenticationService.Services.Authentication
{
    public interface IAuthenticationService
    {
        public IdentificationEntity? FindUserOrDefault(LoginModel data);
        public IdentificationEntity CreateUser(CreateModel data);
        public string GetToken(IdentificationEntity identificationEntity);
    }
}