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

namespace MetroMobiliteUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {
            MetroMobiliteUI.ViewModel.StopViewModel StopViewModelObject =
               new MetroMobiliteUI.ViewModel.StopViewModel();
            StopViewModelObject.LoadStops();

            UserControl1Control.DataContext = StopViewModelObject;
        }

        public void DisplayData(object sender, RoutedEventArgs e)
        {
            UserControl1Control.Visibility = Visibility.Visible;


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
