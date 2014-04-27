using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;
using FluentAssertions;
using NUnit.Framework;

namespace MySocial.Test.Facebook
{
    public class FacebookApiTest : BaseTest
    {
        private static FacebookClient _facebookClient;

        [TestFixtureSetUp]
        public void Setup()
        {
            _facebookClient = new FacebookClient();
        }
        
        [Test]
        public void GetLoginUrlTest()
        {
            Uri fbLoginUri = null;

            var execute = new Action(() =>
            {
                fbLoginUri = _facebookClient.GetLoginUrl(new
                {
                    client_id = Settings.FacebookAppKey,
                    redirect_uri = "https://www.facebook.com/connect/login_success.html",
                    response_type = "code",
                    display = "popup",
                    scope = "email,publish_stream"
                });
            });

            execute.ShouldNotThrow();

            fbLoginUri.Should().NotBeNull();
            fbLoginUri.ToString().Should().NotBeNullOrEmpty();
        }

        [Test]
        public void LoginTest()
        {
            var fbLoginUri = _facebookClient.GetLoginUrl(new
            {
                client_id = Settings.FacebookAppKey,
                redirect_uri = "https://www.facebook.com/connect/login_success.html",
                response_type = "code",
                display = "popup",
                scope = "email,publish_stream"
            });
            
                        
        }

        public string GetAccessToken(FacebookOAuthResult oauthResult)
        {


            var client = new FacebookClient();
            dynamic result = null;


            result = client.Get("/oauth/access_token",
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
            var client = new FacebookClient();
            dynamic user = client.Get("/me", new { fields = "first_name,last_name,email,picture,gender", access_token = token });
            return user;
        }
    }
}
