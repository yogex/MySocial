using MySocial.Properties;
using MySocial.Services;
using MySocial.ViewModels;
using MySocial.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MySocial
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IScreen
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Router = new RoutingState();
            var dependencyResolver = (ModernDependencyResolver)RxApp.MutableResolver;

            RegisterParts(dependencyResolver);

            LogHost.Default.Level = LogLevel.Debug;

            var message = RxApp.DependencyResolver.GetService<INotificationViewModel>();
            this.Router.Navigate.Execute(message);
        }

        private void RegisterParts(IMutableDependencyResolver resolver)
        {
            resolver.RegisterConstant(this, typeof(IScreen));
            resolver.RegisterConstant(this.Router, typeof(IRoutingState));

            resolver.RegisterLazySingleton(() => new Settings(), typeof(ISettings));
            resolver.RegisterLazySingleton(() => new FacebookService(resolver.GetService<ISettings>()), typeof(IFacebookService));
            resolver.RegisterLazySingleton(() => new MainWindowViewModel(this), typeof(IMainWindowViewModel));
            resolver.RegisterLazySingleton(() => new NotificationView(), typeof(INotificationView));

            resolver.Register(() => new NotificationViewModel(this), typeof(INotificationViewModel));
        }

        public IRoutingState Router { get; private set; }
    }
}