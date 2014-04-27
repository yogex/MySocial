﻿using System;
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
using MySocial.ViewModels;
using ReactiveUI;

namespace MySocial.Views
{
    /// <summary>
    /// Interaction logic for FacebookUserView.xaml
    /// </summary>
    public partial class FacebookUserView : UserControl, IFacebookUserView
    {
        public FacebookUserView()
        {
            InitializeComponent();
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = value as IFacebookUserViewModel; }
        }

        public IFacebookUserViewModel ViewModel { get; set; }
    }
}
