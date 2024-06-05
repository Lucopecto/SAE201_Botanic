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
    /// Logique d'interaction pour Filtre.xaml
    /// </summary>
    public partial class Filtre : Window
    {
        public Filtre()
        {
            InitializeComponent();
            AfficherCategories();
        }

        private void jardin_Click(object sender, RoutedEventArgs e)
        {
            spType.Visibility = Visibility.Collapsed;
            FiltreCategorie.Visibility = Visibility.Visible;
            Button plante = new Button();
            plante.Content = "Plante";
            plante.FontSize = 24;
            Button plante1 = new Button();
            plante1.Content = "Plante";
            plante1.FontSize = 24;
            Button plante2 = new Button();
            plante2.Content = "Plante";
            plante2.FontSize = 24;
            Button plante3 = new Button();
            plante3.Content = "Plante";
            plante3.FontSize = 24;
            FiltreCategorie.Children.Add(plante);
            FiltreCategorie.Children.Add(plante1);
            FiltreCategorie.Children.Add(plante2);
            FiltreCategorie.Children.Add(plante3);
        }

        private void AfficherCategories()
        {
            
        }
    }
}
