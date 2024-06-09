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
        public ObservableCollection<Produit> LesProduits { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            dgCommandes.Items.Filter = ContientMotClefCommande;
            dgProduit.Items.Filter = ContientMotClefProduit;
            //dpDateLivraison.DisplayDateStart = DateTime.Now;
            //dpDateLivraison.SelectedDate = DateTime.Now;


            LesCommandes = new ObservableCollection<CommandeAchat>();
            DataContext = this;

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

                    LesCommandes.Add(commande);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            LesProduits = new ObservableCollection<Produit>();

            string sql = "SELECT p.numProduit, c.nomCouleur, cat.numCategorie, p.descriptionProduit, cat.libellecategorie, tp.numtype, tp.nomtype, f.numFournisseur, f.nomfournisseur, f.codelocal, p.nomProduit, p.tailleProduit,  p.prixVente, p.prixAchat " +
                "FROM produit p " +
                "JOIN couleur c ON p.nomCouleur = c.nomcouleur " +
                "JOIN categorie cat ON p.numCategorie = cat.numCategorie " +
                "JOIN fournisseur f ON p.numFournisseur = f.numFournisseur " +
                "JOIN type_produit tp ON cat.numtype = tp.numtype";
            Console.WriteLine(sql);
            DataTable lesProduits = appData.Read(sql);
            foreach (DataRow unProduit in lesProduits.Rows)
            {
                try
                {
                    bool codeLocal;
                    Couleur couleur = new Couleur(unProduit["nomCouleur"].ToString());
                    TypeProduit typeProduit = new TypeProduit(int.Parse(unProduit["numType"].ToString()), unProduit["nomType"].ToString());
                    Categorie categorie = new Categorie(int.Parse(unProduit["numCategorie"].ToString()), typeProduit, unProduit["libelleCategorie"].ToString());
                    if (unProduit["codelocal"].ToString() == "True")
                        codeLocal = true;
                    else
                        codeLocal = false;
                    Fournisseur fournisseur = new Fournisseur(int.Parse(unProduit["numFournisseur"].ToString()), unProduit["nomFournisseur"].ToString(), codeLocal);
                    Produit produit = new Produit(
                                            int.Parse(unProduit["numProduit"].ToString()), couleur, categorie, fournisseur, unProduit["nomProduit"].ToString(), unProduit["tailleProduit"].ToString(), unProduit["descriptionProduit"].ToString(), double.Parse(unProduit["prixVente"].ToString()), double.Parse(unProduit["prixAchat"].ToString()));
                    LesProduits.Add(produit);

                    Console.WriteLine("Chargement de la couleur : " + unProduit["nomCouleur"].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message + " " + sql, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

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


        private void butModifierCommande_Click(object sender, RoutedEventArgs e)
        {
            if (dgCommandes.SelectedItem != null)
            {
                CommandeAchat commandeSelectionne = (CommandeAchat)dgCommandes.SelectedItem;
                FicheCommande fiche = new FicheCommande(Mode.Modification);
                fiche.UCPannelCommande.DataContext = (CommandeAchat)dgCommandes.SelectedItem;
                fiche.ShowDialog();
                data?.UpdateCommande(commandeSelectionne);
            }
            else MessageBox.Show(this, "Veuillez selectionner une commande");
        }

        private void butSupprimerCommande_Click(object sender, RoutedEventArgs e)
        {
            if (dgCommandes.SelectedItem != null)
            {
                CommandeAchat commandeSelectionne = (CommandeAchat)dgCommandes.SelectedItem;
                MessageBoxResult res = MessageBox.Show(this, $"Êtes-vous sûr de vouloir supprimer cette commande ?", "Confirmation",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    data.LesCommandes.Remove(commandeSelectionne);
                    data.DeleteCommande(commandeSelectionne);
                }
            }
            else MessageBox.Show(this, "Veuillez selectionner un client");


            //foreach (DataRow row in LesCommandes.Rows)
            //{
            //    Console.WriteLine(string.Join(", ", row.ItemArray));
            //}
        }

        private void AjouterCommandeCommande_Click(object sender, RoutedEventArgs e)
        {
            CommandeAchat nouvelleCommande = new CommandeAchat();
            FicheCommande fiche = new FicheCommande(Mode.Creation);
            fiche.UCPannelCommande.DataContext = nouvelleCommande;
            fiche.ShowDialog();
            if (fiche.DialogResult == true)
            {
                data.LesCommandes.Add(nouvelleCommande);
                dgCommandes.SelectedItem = nouvelleCommande;
                data.CreateCommande(nouvelleCommande);
            }
        }

        #region Methode de filtre
        private void OuvrirFiltre(object sender, RoutedEventArgs e)
        {
            Filtres filtreWin = new Filtres();
            filtreWin.ShowDialog();
            string filtreSql = "SELECT * FROM";
            //if (!(filtreWin.typeProduitSelect is null)) 
        }

        private void SupprimerFiltre(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Parent is StackPanel sp) sp.Children.Remove(btn);
        }
        #endregion

        #region Methode de recherche
        private bool ContientMotClefCommande(object obj)
        {
            CommandeAchat? uneCommande = obj as CommandeAchat;
            if (String.IsNullOrEmpty(txtCommandeRecherche.Text))
                return true;
            else
                return uneCommande.ModeLivraison.StartsWith(txtCommandeRecherche.Text, StringComparison.OrdinalIgnoreCase) ||
                    uneCommande.UnModeTransport.ModedeTransport.StartsWith(txtCommandeRecherche.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool ContientMotClefProduit(object obj)
        {
            Produit? unProduit= obj as Produit;
            if (String.IsNullOrEmpty(txtRechercheProduit.Text))
                return true;
            else
                return unProduit.NomProduit.StartsWith(txtCommandeRecherche.Text, StringComparison.OrdinalIgnoreCase) ||
                    unProduit.DescriptionProduit.StartsWith(txtCommandeRecherche.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void txtCommandeRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgCommandes.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(dgProduit.ItemsSource).Refresh();
        }

        private void txtRechercheProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgCommandes.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(dgProduit.ItemsSource).Refresh();
        }
        #endregion
    }
}
