using Facebook;

namespace MySocial.Services
{
    public interface IFacebookService : IBaseService
    {
        string GetLoginUrl();
        FacebookClient GetFacebookClient();
    }
}