using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Fournisseur
    {
        #region Champs
        private int numFournisseur;
        private string nomFournisseur;
        private bool codeLocal;
        #endregion

        #region Propriete
        public int NumFournisseur
        {
            get
            {
                return numFournisseur;
            }

            set
            {
                numFournisseur = value;
            }
        }

        public string NomFournisseur
        {
            get
            {
                return nomFournisseur;
            }

            set
            {
                nomFournisseur = value;
            }
        }

        public bool CodeLocal
        {
            get
            {
                return this.codeLocal;
            }

            set
            {
                this.codeLocal = value;
            }
        }
        #endregion

        #region Constructeur
        public Fournisseur(int numFournisseur, string nomFournisseur, bool codeLocal)
        {
            this.NumFournisseur = numFournisseur;
            this.NomFournisseur = nomFournisseur;
            this.CodeLocal = codeLocal;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Fournisseur fournisseur &&
                   this.NumFournisseur == fournisseur.NumFournisseur &&
                   this.NomFournisseur == fournisseur.NomFournisseur &&
                   this.CodeLocal == fournisseur.CodeLocal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumFournisseur, this.NomFournisseur, this.CodeLocal);
        }

        #endregion

    }
}
