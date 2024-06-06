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
            LesProduits = new ObservableCollection<Produit>();
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

        public DataRowCollection Read(string commandeSql)
        {
            string sql = "SELECT numcommande, nummagasin, modetransport, datecommande, datelivraison, modelivraison FROM commande_achat";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(commandeSql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                //foreach (DataRow res in dataTable.Rows)
                //{
                //    CommandeAchat nouveau = new CommandeAchat(int.Parse(res["numCommande"].ToString()),
                //    res["nom"].ToString(), res["prenom"].ToString(),
                //    res["email"].ToString(), DateTime.Parse(res["dateNaissance"].ToString()),
                //    res["telephone"].ToString(),
                //    (GenreClient)char.Parse(res["genre"].ToString()));
                //    LesClients.Add(nouveau);
                //}
                return dataTable.Rows;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Erreur : " + e, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return new DataTable().Rows;
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

        public int Update(Produit c)
        {
            //string sql = $"UPDATE wpfProduits.Produit SET nom = '{c.Nom}', prenom = '{c.Prenom}', email = '{c.Email}', " +
            //             $"genre = '{(char)c.Genre}', telephone = '{c.Telephone}', dateNaissance = '{c.DateNaissance:yyyy-MM-dd}' " +
            //             $"WHERE id = {c.Id};";
            string sql = $"";
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
