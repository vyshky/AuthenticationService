using AuthenticationService.Domain.Model;
using AuthenticationService.Model;
using AuthenticationService.Security.PasswordCrypt;
using AuthenticationService.Security.Token;
using ChatServerApi.Domain;
using ChatServerApi.Domain.Entity;
using System.Collections.Generic;

namespace AuthenticationService.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        ApplicationDbContext ApplicationDbContext { get; init; }
        IPasswordCrypt PasswordCrypt { get; set; }
        IToken Token { get; set; }
        public AuthenticationService(ApplicationDbContext applicationDbContext, IToken token, IPasswordCrypt passwordCrypt)
        {
            ApplicationDbContext = applicationDbContext;
            Token = token;
            PasswordCrypt = passwordCrypt;
        }
        // updatedatabase
        public IdentificationEntity? FindUserOrDefault(LoginModel data)
        {
            var result = ApplicationDbContext.Identification
                .FirstOrDefault(x => x.Login == data.UserName);
            return result != null && PasswordCrypt.Verify(data.Password, result.Password) ? result : null;
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
                Password = PasswordCrypt.HashPassword(data.Password),
                Roles = data.Roles
            };

            ApplicationDbContext.User.Add(user);
            var ident = ApplicationDbContext.Identification.Add(identification);
            ApplicationDbContext.SaveChanges();
            return ident.Entity;
        }

        public string GetToken(IdentificationEntity identificationEntity)
        {
            return Token.Get(identificationEntity);
        }
    }
}
