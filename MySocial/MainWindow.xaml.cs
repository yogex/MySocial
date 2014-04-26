﻿using MySocial.ViewModels;
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
    public partial class MainWindow : Window
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
        }
    }
}