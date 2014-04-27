using MySocial.Services;
using ReactiveUI;

namespace MySocial.ViewModels
{
    public interface IMainWindowViewModel
    {
        IFacebookService FacebookService { get; set; }

        ITwitterService TwitterService { get; set; }
    }
}