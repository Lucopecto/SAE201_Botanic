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
        private string nomProduit;
        private string tailleProduit;
        private string descriptionProduit;
        private double prixVente;
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

        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Produit produit &&
                   this.NumProduit == produit.NumProduit &&
                   this.NomProduit == produit.NomProduit &&
                   this.TailleProduit == produit.TailleProduit &&
                   this.DescriptionProduit == produit.DescriptionProduit &&
                   this.PrixVente == produit.PrixVente;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumProduit, this.NomProduit, this.TailleProduit, this.DescriptionProduit, this.PrixVente);
        }

        #endregion
    }
}
