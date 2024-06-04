using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Caracteristique
    {
        #region Champs
        private int numCaracteristique;
        private string nomCaracteristique;
        #endregion

        #region Propriete
        public int NumCaracteristique
        {
            get
            {
                return numCaracteristique;
            }

            set
            {
                numCaracteristique = value;
            }
        }

        public string NomCaracteristique
        {
            get
            {
                return this.nomCaracteristique;
            }

            set
            {
                this.nomCaracteristique = value;
            }
        }
        #endregion

        #region Constructeur
        public Caracteristique(int numCaracteristique, string nomCaracteristique)
        {
            this.NumCaracteristique = numCaracteristique;
            this.NomCaracteristique = nomCaracteristique;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Caracteristique caracteristique &&
                   this.NumCaracteristique == caracteristique.NumCaracteristique &&
                   this.NomCaracteristique == caracteristique.NomCaracteristique;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumCaracteristique, this.NomCaracteristique);
        }


        #endregion

    }
}
