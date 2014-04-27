using System;
using Facebook;
using MySocial.Models;
using MySocial.Services;
using ReactiveUI;

namespace MySocial.ViewModels
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private readonly IScreen screen;

        public MainWindowViewModel(IScreen screen, IFacebookService facebookService)
        {
            this.screen = screen ?? RxApp.DependencyResolver.GetService<IScreen>();
            this.FacebookService = facebookService ?? RxApp.DependencyResolver.GetService<IFacebookService>()
        }

        public MainWindowViewModel()
        {
        }

        public IFacebookService FacebookService { get; set; }

        public ITwitterService TwitterService { get; set; }

        public string Token { get; set; }

        

        public void FacebookLoginSucceeded(FacebookOAuthResult oauthResult)
        {
            var token = FacebookService.GetAccessToken(oauthResult);
            Token = token;
            var user = FacebookService.GetUser(token);
        }

        public void FacebookLoginFailed(FacebookOAuthResult oauthResult)
        {
            throw new System.NotImplementedException();
        }
    }
}