using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Produit
    {
        #region Champs
        private int numProduit;
        private Couleur uneCouleur;
        private Categorie uneCategorie;
        private Fournisseur unFournisseur;
        private string nomProduit;
        private string tailleProduit;
        private string descriptionProduit;
        private double prixVente;
        private double prixAchat;
        #endregion

        #region Propriete
        public int NumProduit
        {
            get
            {
                return numProduit;
            }

            set
            {
                numProduit = value;
            }
        }

        public Couleur UneCouleur
        {
            get
            {
                return uneCouleur;
            }

            set
            {
                uneCouleur = value;
            }
        }

        public Categorie UneCategorie
        {
            get
            {
                return uneCategorie;
            }

            set
            {
                uneCategorie = value;
            }
        }

        public Fournisseur UnFournisseur
        {
            get
            {
                return unFournisseur;
            }

            set
            {
                unFournisseur = value;
            }
        }

        public string NomProduit
        {
            get
            {
                return nomProduit;
            }

            set
            {
                nomProduit = value;
            }
        }

        public string TailleProduit
        {
            get
            {
                return tailleProduit;
            }

            set
            {
                tailleProduit = value;
            }
        }

        public string DescriptionProduit
        {
            get
            {
                return descriptionProduit;
            }

            set
            {
                descriptionProduit = value;
            }
        }

        public double PrixVente
        {
            get
            {
                return this.prixVente;
            }

            set
            {
                this.prixVente = value;
            }
        }

        public double PrixAchat
        {
            get
            {
                return this.prixAchat;
            }

            set
            {
                this.prixAchat = value;
            }
        }

        #endregion

        #region Constructeur
        public Produit(int numProduit, Couleur uneCouleur, Categorie uneCategorie, Fournisseur unFournisseur, string nomProduit, string tailleProduit, string descriptionProduit, double prixVente, double prixAchat)
        {
            this.NumProduit = numProduit;
            this.UneCouleur = uneCouleur;
            this.UneCategorie = uneCategorie;
            this.UnFournisseur = unFournisseur;
            this.NomProduit = nomProduit;
            this.TailleProduit = tailleProduit;
            this.DescriptionProduit = descriptionProduit;
            this.PrixVente = prixVente;
            this.PrixAchat = prixAchat;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Produit produit &&
                   this.NumProduit == produit.NumProduit &&
                   EqualityComparer<Couleur>.Default.Equals(this.UneCouleur, produit.UneCouleur) &&
                   EqualityComparer<Categorie>.Default.Equals(this.UneCategorie, produit.UneCategorie) &&
                   EqualityComparer<Fournisseur>.Default.Equals(this.UnFournisseur, produit.UnFournisseur) &&
                   this.NomProduit == produit.NomProduit &&
                   this.TailleProduit == produit.TailleProduit &&
                   this.DescriptionProduit == produit.DescriptionProduit &&
                   this.PrixVente == produit.PrixVente;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumProduit, this.UneCouleur, this.UneCategorie, this.UnFournisseur, this.NomProduit, this.TailleProduit, this.DescriptionProduit, this.PrixVente);
        }

        #endregion
    }
}
