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
            FiltreType.Visibility = Visibility.Collapsed;
            FiltreCategorie.Visibility = Visibility.Visible;
            ComboBox plante = new ComboBox
            {
                Text = "Plznte",
                FontSize = 24
            };
            FiltreCategorie.Children.Add(plante);
        }
    }
}