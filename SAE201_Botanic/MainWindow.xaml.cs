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
            //data = new ApplicationData();
            //dgCommandes.Items.Filter = ContientMotClef;
        }

        //private bool ContientMotClef(object obj)
        //{
        //    CommandeAchat unClient = obj as CommandeAchat;
        //    if (String.IsNullOrEmpty(textMotClef.Text))
        //        return true;
        //    else
        //        return (unClient.Nom.StartsWith(textMotClef.Text, StringComparison.OrdinalIgnoreCase) ||
        //            unClient.Prenom.StartsWith(textMotClef.Text, StringComparison.OrdinalIgnoreCase));
        //}

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
