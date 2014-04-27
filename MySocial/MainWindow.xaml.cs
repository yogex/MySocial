using Facebook;
using MySocial.ViewModels;
using ReactiveUI;
using ReactiveUI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MySocial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowView
    {
        public MainWindowViewModel ViewModel { get; protected set; }

        public MainWindow()
        {
            InitializeComponent();

            var viewHost = new RoutedViewHost();
            this.Presenter.Content = viewHost;

            var screen = RxApp.DependencyResolver.GetService<IScreen>();
            viewHost.Router = screen.Router;

            DataContext = RxApp.DependencyResolver.GetService<IMainWindowViewModel>();

            Browser.Navigated += Browser_Navigated;
        }

        void Browser_Navigated(object sender, NavigationEventArgs e)
        {
            var client = ViewModel.FacebookService.GetFacebookClient();
            
            FacebookOAuthResult oauthResult;
            if (!client.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
                return;
            if (oauthResult.IsSuccess)
                ViewModel.FacebookLoginSucceeded(oauthResult);
            else
                ViewModel.FacebookLoginFailed(oauthResult);
        }

        
        IMainWindowViewModel IViewFor<IMainWindowViewModel>.ViewModel
        {
            get
            {
                return (IMainWindowViewModel) DataContext;
            }
            set
            {
                DataContext = value;
            }
        }

        object IViewFor.ViewModel
        {
            get
            {
                return ViewModel;
            }
            set
            {
                this.ViewModel = (IMainWindowViewModel) value;
            }
        }
    }

    public interface IMainWindowView : IViewFor<IMainWindowViewModel>
    {

    }
}