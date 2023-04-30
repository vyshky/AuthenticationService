using ChatServerApi.Domain.Entity;

namespace AuthenticationService.Security.Token
{
    public interface IToken
    {
        string Get(IdentificationEntity user);
    }
}
