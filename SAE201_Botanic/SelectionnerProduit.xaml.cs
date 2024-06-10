using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Logique d'interaction pour SelectionnerProduit.xaml
    /// </summary>
    public partial class SelectionnerProduit : Window
    {
        public CommandeAchat CommandeSelect;
        public ApplicationData data;
        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<Produit> LesProduits { get; set; }

        public SelectionnerProduit()
        {
            InitializeComponent();
            LesProduits = new ObservableCollection<Produit>();
            this.DataContext = this;

            ApplicationData appData = new ApplicationData();
            string sql = "SELECT p.numProduit, c.nomCouleur, cat.numCategorie, p.descriptionProduit, cat.libellecategorie, tp.numtype, tp.nomtype, f.numFournisseur, f.nomfournisseur, f.codelocal, p.nomProduit, p.tailleProduit,  p.prixVente, p.prixAchat " +
                         "FROM produit p " +
                         "JOIN couleur c ON p.nomCouleur = c.nomcouleur " +
                         "JOIN categorie cat ON p.numCategorie = cat.numCategorie " +
                         "JOIN fournisseur f ON p.numFournisseur = f.numFournisseur " +
                         "JOIN type_produit tp ON cat.numtype = tp.numtype";

            DataTable lesProduits = appData.Read(sql);

            foreach (DataRow unProduit in lesProduits.Rows)
            {
                try
                {
                    bool codeLocal = unProduit["codelocal"].ToString() == "True";
                    Couleur couleur = new Couleur(unProduit["nomCouleur"].ToString());
                    TypeProduit typeProduit = new TypeProduit(int.Parse(unProduit["numType"].ToString()), unProduit["nomType"].ToString());
                    Categorie categorie = new Categorie(int.Parse(unProduit["numCategorie"].ToString()), typeProduit, unProduit["libelleCategorie"].ToString());
                    Fournisseur fournisseur = new Fournisseur(int.Parse(unProduit["numFournisseur"].ToString()), unProduit["nomFournisseur"].ToString(), codeLocal);
                    Produit produit = new Produit(
                        int.Parse(unProduit["numProduit"].ToString()), couleur, categorie, fournisseur,
                        unProduit["nomProduit"].ToString(), unProduit["tailleProduit"].ToString(),
                        unProduit["descriptionProduit"].ToString(), double.Parse(unProduit["prixVente"].ToString()),
                        double.Parse(unProduit["prixAchat"].ToString()));

                    LesProduits.Add(produit);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message + " " + sql, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void toutSelectionner_Click(object sender, RoutedEventArgs e)
        {
            foreach (var produit in LesProduits)
            {
                produit.IsSelected = !produit.IsSelected;
            }
        }
    }
    public class Item : INotifyPropertyChanged
        {
            private bool estChoisi;
            public string Produit { get; set; }
            public int Quantity { get; set; }
            public bool EstChoisi
            {
                get { return estChoisi; }
                set
                {
                    if (estChoisi != value)
                    {
                        estChoisi = value;
                        OnPropertyChanged("EstChoisi");
                    }
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }

            public class Product
            {
                public string Name { get; set; }
                public int Quantity { get; set; }
            }
            //private void ValidateButton_Click(object sender, RoutedEventArgs e)
            //{
            //    var selectedItems = Items.Where(item => item.IsSelected).ToList();
            //    if (selectedItems.Any())
            //    {
            //        CommandWindow commandWindow = new CommandWindow(selectedItems);
            //        commandWindow.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Aucun élément sélectionné.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
        }
    }


