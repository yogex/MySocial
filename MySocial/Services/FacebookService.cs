using Facebook;
using MySocial.Properties;

namespace MySocial.Services
{
    public class FacebookService : BaseService, IFacebookService
    {
        private static FacebookClient _facebookClient;

        public FacebookService(ISettings settings)
            : base(settings)
        {
            Settings = settings;
        }

        public FacebookClient GetFacebookClient()
        {
            return _facebookClient ?? (_facebookClient = new FacebookClient());
        }

        public string GetLoginUrl()
        {
            var client = GetFacebookClient();
            var fbLoginUri = client.GetLoginUrl(new
               {
                   client_id = Settings.FacebookAppKey,
                   redirect_uri = "https://www.facebook.com/connect/login_success.html",
                   response_type = "code",
                   display = "popup",
                   scope = "email,publish_stream"
               });

            return fbLoginUri.ToString();
        }

        public string GetAccessToken(FacebookOAuthResult oauthResult)
        {
            var client = GetFacebookClient();
            dynamic result = client.Get("/oauth/access_token",
                                        new
                                        {
                                            client_id = Settings.FacebookAppKey,
                                            client_secret = Settings.FacebookAppSecret,
                                            redirect_uri = "https://www.facebook.com/connect/login_success.html",
                                            code = oauthResult.Code,
                                        });

            return result.access_token;
        }

        public dynamic GetUser(string token)
        {
            var client = GetFacebookClient();
            dynamic user = client.Get("/me", new { fields = "first_name,last_name,email,picture,gender", access_token = token });
            return user;
        }
    }
}