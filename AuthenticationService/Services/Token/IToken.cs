using ChatServerApi.Domain.Entity;

namespace AuthenticationService.Services.Token
{
    public interface IToken
    {
        string Get(Identification user);
    }
}
