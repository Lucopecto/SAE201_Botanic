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
using System.Windows.Media.Animation;
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
            ApplicationData appData = new ApplicationData();
            DataTable lesTypes = appData.Read("SELECT * FROM type_produit");
            foreach (DataRow unType in lesTypes.Rows)
            {
                try
                {
                    TypeProduit type = new TypeProduit(int.Parse(unType["numtype"].ToString()), unType["nomType"].ToString());
                    Button btnType = CreerBoutonFiltre();
                    btnType.Click += new RoutedEventHandler(this.AfficherSousCategorie);
                    btnType.Content = type.NomType;
                    pageCategorie.Children.Add(btnType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public Button CreerBoutonFiltre()
        {
            Button btnType = new Button();
            btnType.Height = 30;
            btnType.Padding = new Thickness(10, 0, 0, 0);
            btnType.HorizontalAlignment = HorizontalAlignment.Stretch;
            btnType.HorizontalContentAlignment = HorizontalAlignment.Left;
            btnType.Background = Brushes.White;
            btnType.Foreground = Brushes.Gray;
            btnType.BorderThickness = new Thickness(0);
            return btnType;
        }

        private void ValiderFiltres(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AfficherCategories(object sender, RoutedEventArgs e)
        {
            pageFiltres.Visibility = Visibility.Hidden;
            pageSousCategorie.Visibility = Visibility.Hidden;
            pageCategorie.Visibility = Visibility.Visible;
        }

        private void RetourFiltre(object sender, RoutedEventArgs e)
        {
            pageCategorie.Visibility = Visibility.Hidden;
            pageSousCategorie.Visibility = Visibility.Hidden;
            pageCouleur.Visibility = Visibility.Hidden;
            pageFiltres.Visibility = Visibility.Visible;
        }

        private void AfficherCouleur(object sender, RoutedEventArgs e)
        {
            pageFiltres.Visibility = Visibility.Hidden;
            pageCouleur.Visibility = Visibility.Visible;
        }

        private void AfficherSousCategorie(object sender, RoutedEventArgs e)
        {
            Button btn;
            if (sender is Button)
            {
                btn = (Button)sender;
                lbPageSousCategorie.Content = btn.Content;
            pageCategorie.Visibility = Visibility.Hidden;
            pageSousCategorie.Visibility = Visibility.Visible;
            }
        }
    }
}
