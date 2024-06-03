using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class TypeProduit
    {
        #region Champs
        private int numType;
        private string nomType;
        #endregion

        #region Propriete
        public int NumType
        {
            get
            {
                return numType;
            }

            set
            {
                numType = value;
            }
        }

        public string NomType
        {
            get
            {
                return this.nomType;
            }

            set
            {
                this.nomType = value;
            }
        }

        #endregion

        #region Constructeur
        public TypeProduit(int numType, string nomType)
        {
            this.NumType = numType;
            this.NomType = nomType;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is TypeProduit produit &&
                   this.NumType == produit.NumType &&
                   this.NomType == produit.NomType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumType, this.NomType);
        }

        #endregion
    }
}
