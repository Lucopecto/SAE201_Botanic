using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Couleur
    {
        #region Champs
        private string nomCouleur;
        #endregion

        #region Propriete
        public string NomCouleur
        {
            get
            {
                return this.nomCouleur;
            }

            set
            {
                this.nomCouleur = value;
            }
        }
        #endregion

        #region Constructeur
        public Couleur(string nomCouleur)
        {
            this.NomCouleur = nomCouleur;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Couleur couleur &&
                   this.NomCouleur == couleur.NomCouleur;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NomCouleur);
        }

        #endregion
    }
}
