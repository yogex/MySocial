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
using MySocial.Extensions;
using MySocial.ViewModels;
using ReactiveUI;

namespace MySocial.Views
{
    /// <summary>
    /// Interaction logic for NotificationView.xaml
    /// </summary>
    public partial class NotificationView : UserControl, INotificationView
    {
        public NotificationView()
        {
            InitializeComponent();

            this.WhenNavigatedTo(ViewModel, () =>
            {
                // Make XAML Bindings be relative to our ViewModel
                DataContext = ViewModel;

                return ViewModel.Hide.Subscribe(param => this.Visibility = System.Windows.Visibility.Collapsed);
            });
        }

        public INotificationViewModel ViewModel
        {
            get { return (INotificationViewModel)DataContext; }
            set { DataContext = value; }
        }

        object IViewFor.ViewModel
        {
            get
            {
                return ViewModel;
            }
            set
            {
                this.ViewModel = (INotificationViewModel)value;
            }
        }
    }
}
