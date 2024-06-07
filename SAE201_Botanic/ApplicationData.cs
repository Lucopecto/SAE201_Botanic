using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAE201_Botanic
{
    public class ApplicationData
    {
        private ObservableCollection<Produit> lesProduits;
        private NpgsqlConnection connexion;

        public ObservableCollection<Produit> LesProduits
        {
            get
            {
                return this.lesProduits;
            }

            set
            {
                this.lesProduits = value;
            }
        }

        public NpgsqlConnection Connexion
        {
            get
            {
                return this.connexion;
            }

            set
            {
                this.connexion = value;
            }
        }

        public ApplicationData()
        {
            //LesProduits = new ObservableCollection<Produit>();
            ConnexionBD();
            //Read();
        }

        public void ConnexionBD()
        {
            try
            {
                Connexion = new NpgsqlConnection
                {
                    ConnectionString = "Server=srv-peda-new;" +
                    "port=5433;" +
                    "Database=sae_botanic;" +
                    "Search Path = sae_botanic_s;" +
                    "uid=tasdemis;" +
                    "password=r9H2lI;"
                };
                Connexion.Open();
                Console.WriteLine("Connexion réussie !");
            }
            catch (Exception e)
            {
                MessageBox.Show("Problème de connexion : " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DeconnexionBD()
        {
            try
            {
                Connexion.Close();
            }
            catch (Exception e)
            { Console.WriteLine("Problème à la déconnexion : " + e); }
        }

        public DataTable Read(string commandeSql)
        {
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(commandeSql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Erreur : " + e  + "  " + commandeSql, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return new DataTable();
            }
        }  



        private int MethodeGenerique(string sql)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb; // nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                MessageBox.Show("Problème de requête : " + sqlE.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }

        public int Create(Produit c)
        {
            //string sql = $"INSERT INTO wpfProduits.Produit (nom, prenom, email, genre, telephone, dateNaissance) " +
            //             $"VALUES ('{c.Nom}', '{c.Prenom}', '{c.Email}', '{(char)c.Genre}', '{c.Telephone}', " +
            //             $"'{c.DateNaissance:yyyy-MM-dd}');";
            string sql = $"";
            MethodeGenerique(sql);

            return 0;
        }

        public int UpdateCommande(CommandeAchat c)
        {
            string sql = $"UPDATE sae_botanic_s.commandeachat SET numcommande = '{c.NumCommande}', nummagasin = '{c.UnMagasin}', modetransport = '{c.UnModeTransport}', " +
                         $"datecommande = '{c.DateComande:dd-MM-yyyy}', datelivraison= '{c.DateLivraison:dd-MM-yyyy}', modelivraison= '{c.ModeLivraison}' " +
                         $"WHERE id = {c.NumCommande};";
            MethodeGenerique(sql);

            return 0;

        }

        public int Delete(Produit c)
        {
            //string sql = $"DELETE FROM wpfProduits.Produit WHERE id = {c.Id};";
            string sql = $"";
            MethodeGenerique(sql);

            return 0;
        }
    }
}
