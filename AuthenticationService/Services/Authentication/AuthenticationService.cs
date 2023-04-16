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

        public Identification IsValidUserInformation(LoginModel data)
        {
            return ApplicationDbContext.Identification.FirstOrDefault(x => x.Login == data.UserName && x.Password == data.Password);
        }

        public Identification CreateUser(CreateModel data)
        {
            Guid id = Guid.NewGuid();
            User user = new User()
            {
                Id = id,
                Email = data.Email,
                CreatedDate = DateTime.UtcNow
            };

            Identification identification = new Identification()
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
