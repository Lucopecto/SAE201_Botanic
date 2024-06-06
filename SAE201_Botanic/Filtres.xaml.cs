using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour Filtres.xaml
    /// </summary>
    public partial class Filtres : Window
    {
        public Filtres()
        {
            InitializeComponent();
            //ApplicationData appData = new ApplicationData();
            //DataRowCollection lesCategories = appData.Read("SELECT nomtype FROM type_produit");
            //foreach (DataRow uneCategorie in lesCategories)
            //{
            //    pageCategorie.Children.Add(pageCategorie);
            //}
        }

        private void ValiderFiltres(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AfficherCategories(object sender, RoutedEventArgs e)
        {
            pageFiltres.Visibility = Visibility.Hidden;
            pageCategorie.Visibility = Visibility.Visible;
        }

        private void RetourFiltre(object sender, RoutedEventArgs e)
        {
            pageCategorie.Visibility = Visibility.Hidden;
            pageCouleur.Visibility = Visibility.Hidden;
            pageFiltres.Visibility = Visibility.Visible;
        }

        private void AfficherCouleur(object sender, RoutedEventArgs e)
        {
            pageFiltres.Visibility = Visibility.Hidden;
            pageCouleur.Visibility = Visibility.Visible;
        }
    }
}
