using ReactiveUI;

namespace MySocial.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IScreen screen;

        public MainWindowViewModel(IScreen screen)
        {
            this.screen = screen ?? RxApp.DependencyResolver.GetService<IScreen>();
        }

        public MainWindowViewModel()
        {
        }
    }
}