using Facebook;
using MySocial.Models;

namespace MySocial.Services
{
    public interface IFacebookService : IBaseService
    {
        string GetLoginUrl();
        FacebookClient GetFacebookClient();
        string GetAccessToken(FacebookOAuthResult oauthResult);
        FacebookUser GetUser(string token);
    }
}