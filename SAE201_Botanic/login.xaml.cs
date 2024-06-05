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
using System.Windows.Shapes;

namespace SAE201_Botanic
{
    /// <summary>
    /// Logique d'interaction pour login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void Goto_MdpOublie(object sender, RoutedEventArgs e)
        {
            spConnexion.Visibility = Visibility.Hidden;
            spMdpOublie.Visibility = Visibility.Visible;
        }

        private void Goto_Connexion(object sender, RoutedEventArgs e)
        {
            spMdpOublie.Visibility = Visibility.Hidden;
            spDemandeEnvoyee.Visibility = Visibility.Hidden;
            spConnexion.Visibility = Visibility.Visible;
        }

        private void Goto_DemandeEnvoye(object sender, RoutedEventArgs e)
        {
            spMdpOublie.Visibility = Visibility.Hidden;
            spDemandeEnvoyee.Visibility = Visibility.Visible;
        }

        private void ValiderConnexion(object sender, RoutedEventArgs e)
        {
            var mainWin = new MainWindow();
            Close();
            mainWin.Show();
        }

    }
}
