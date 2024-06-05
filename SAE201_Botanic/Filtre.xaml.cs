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
using System.Windows.Shapes;

namespace SAE201_Botanic
{
    /// <summary>
    /// Logique d'interaction pour Filtre.xaml
    /// </summary>
    public partial class Filtre : Window
    {
        public Filtre()
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
