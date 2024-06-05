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

namespace SAE201_Botanic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void jardin_Click(object sender, RoutedEventArgs e)
        {
            jardinAfficheProduit.Visibility = Visibility.Visible;
            MobilierAfficheProduit.Visibility = Visibility.Collapsed;
        }

        private void Mobilier_Click(object sender, RoutedEventArgs e)
        {
            MobilierAfficheProduit.Visibility = Visibility.Visible;
            jardinAfficheProduit.Visibility = Visibility.Collapsed;
        }
    }
}
