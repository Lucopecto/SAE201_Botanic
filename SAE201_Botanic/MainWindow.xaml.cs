using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SAE201_Botanic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationData data;
        public ObservableCollection<CommandeAchat> LesCommandes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LesCommandes = new ObservableCollection<CommandeAchat>();
            DataContext = this; // Setting DataContext for data binding

            ApplicationData appData = new ApplicationData();
            DataTable lesCommandes = appData.Read(
                "SELECT ca.numcommande, mp.modetransport, m.nummagasin, m.nommagasin, m.ruemagasin, m.cpmagasin, m.villemagasin, m.horaire, " +
                "ca.datecommande, ca.datelivraison, ca.modelivraison " +
                "FROM commande_achat ca " +
                "JOIN mode_de_transport mp ON ca.modetransport = mp.modetransport " +
                "JOIN magasin m ON ca.nummagasin = m.nummagasin");

            foreach (DataRow uneCommande in lesCommandes.Rows)
            {
                try
                {
                    Magasin magasin = new Magasin(
                        int.Parse(uneCommande["nummagasin"].ToString()),
                        uneCommande["nommagasin"].ToString(),
                        uneCommande["ruemagasin"].ToString(),
                        uneCommande["cpmagasin"].ToString(),
                        uneCommande["villemagasin"].ToString(),
                        uneCommande["horaire"].ToString());

                    ModeTransport modeTransport = new ModeTransport(uneCommande["modetransport"].ToString());

                    CommandeAchat commande = new CommandeAchat(
                        int.Parse(uneCommande["numcommande"].ToString()),
                        magasin,
                        modeTransport,
                        DateTime.Parse(uneCommande["datecommande"].ToString()),
                        DateTime.Parse(uneCommande["datelivraison"].ToString()),
                        uneCommande["modelivraison"].ToString());

                    LesCommandes.Add(commande); // Add the commande to the collection
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void textMotClef_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgCommandes.ItemsSource).Refresh();
        }

        private void Deconnexion(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Vous allez être déconnecté", "Déconnexion", MessageBoxButton.OKCancel, MessageBoxImage.Information) is MessageBoxResult.OK)
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
