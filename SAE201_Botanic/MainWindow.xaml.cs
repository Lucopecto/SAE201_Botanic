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
using System.Windows.Markup;
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
        public ApplicationData data;
        public MainWindow()
        {
            InitializeComponent();
            ApplicationData appData = new ApplicationData();
            DataTable lesCommandes = appData.Read("SELECT * FROM commande_achat");
            //foreach (DataRow uneCommande in lesCommandes.Rows)
            //{
            //    try
            //    {
            //        CommandeAchat commande = new CommandeAchat(int.Parse(uneCommande["numcommande"].ToString()), uneCommande["nummagasin"].ToString(),
            //            uneCommande["modetransport"].ToString(), DateTime.Parse(uneCommande["datecommande"].ToString()), DateTime.Parse(uneCommande["datelivraison"].ToString()), uneCommande["modelivraison"].ToString());
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Erreur : " + ex, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}


        }

        private void textMotClef_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgCommandes.ItemsSource).Refresh();
        }

        private void Deconnexion(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Vous allez être déconnecté", "Déconnexion", MessageBoxButton.OKCancel, MessageBoxImage.Information) is MessageBoxResult.OK)
            {
                login loginWin = new login();
                Close();
                loginWin.ShowDialog();
            }
        }
        private void OuvrirFiltre(object sender, RoutedEventArgs e)
        {
            Filtres filtreWin = new Filtres();
            filtreWin.ShowDialog();
        }

        //private void AjouterCommande_Click(object sender, RoutedEventArgs e)
        //{
        //    CommandeAchat nouvelleCommande = new CommandeAchat();
        //    FicheClient fiche = new FicheClient(Mode.Creation);
        //    fiche.UCPanelClient.DataContext = nouvelleCommande;
        //    fiche.ShowDialog();
        //    if (fiche.DialogResult == true)
        //    {
        //        data.LesClients.Add(nouvelleCommande);
        //        dgClients.SelectedItem = nouvelleCommande;
        //        data.Create(nouvelleCommande);
        //    }
        //}
    }
}
