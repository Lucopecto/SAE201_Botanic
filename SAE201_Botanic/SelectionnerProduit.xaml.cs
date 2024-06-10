using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public ObservableCollection<Item> Items { get; set; }

        public SelectionnerProduit()
        {
            InitializeComponent();

            Items = new ObservableCollection<Item>

            {
                new Item {  Produit = "Produit 1", Quantity = 15, IsSelected = false },

            };

            this.DataContext = Items;

        }

    }
        public class Item : INotifyPropertyChanged
        {
            private bool _isSelected;
            public string Produit { get; set; }
            public int Quantity { get; set; }

            public bool IsSelected
            {
                get { return _isSelected; }
                set
                {
                    if (_isSelected != value)
                    {
                        _isSelected = value;
                        OnPropertyChanged("IsSelected");
                    }
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }

            private void DecreaseButton_Click(object sender, RoutedEventArgs e)
            {
                var button = (Button)sender;
                var product = (Product)button.DataContext;
                product.Quantity--;
            }

            private void IncreaseButton_Click(object sender, RoutedEventArgs e)
            {
                var button = (Button)sender;
                var product = (Product)button.DataContext;
                product.Quantity++;

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


