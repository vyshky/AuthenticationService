using AuthenticationService.Domain.Model;
using AuthenticationService.Model;
using ChatServerApi.Domain;
using ChatServerApi.Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationService.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        ApplicationDbContext ApplicationDbContext { get; init; }
        public AuthenticationService(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public IdentificationEntity IsValidUserInformation(LoginModel data)
        {
            return ApplicationDbContext.Identification.FirstOrDefault(x => x.Login == data.UserName && x.Password == data.Password);
        }

        public IdentificationEntity CreateUser(CreateModel data)
        {
            Guid id = Guid.NewGuid();
            UserEntity user = new UserEntity()
            {
                Id = id,
                Email = data.Email,
                CreatedDate = DateTime.UtcNow
            };

            IdentificationEntity identification = new IdentificationEntity()
            {
                UserId = id,
                Login = data.UserName,
                Password = data.Password,
                Roles = data.Roles
            };

            ApplicationDbContext.User.Add(user);
            ApplicationDbContext.Identification.Add(identification);
            ApplicationDbContext.SaveChanges();
            return identification;
        }
    }
}
