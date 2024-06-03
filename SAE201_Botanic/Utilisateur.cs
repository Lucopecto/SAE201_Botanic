using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Utilisateur
    {
        #region Chammps
        private string numUtilisateur;
        private string nomUtilisateur;
        private string loginUtilisateur;
        private string mdpUtilisateur;
        #endregion

        #region Propriete
        public string NumUtilisateur
        {
            get
            {
                return numUtilisateur;
            }

            set
            {
                numUtilisateur = value;
            }
        }

        public string NomUtilisateur
        {
            get
            {
                return nomUtilisateur;
            }

            set
            {
                nomUtilisateur = value;
            }
        }

        public string LoginUtilisateur
        {
            get
            {
                return loginUtilisateur;
            }

            set
            {
                loginUtilisateur = value;
            }
        }

        public string MdpUtilisateur
        {
            get
            {
                return this.mdpUtilisateur;
            }

            set
            {
                this.mdpUtilisateur = value;
            }
        }
        #endregion

        #region Constructeur
        public Utilisateur(string numUtilisateur, string nomUtilisateur, string loginUtilisateur, string mdpUtilisateur)
        {
            this.NumUtilisateur = numUtilisateur;
            this.NomUtilisateur = nomUtilisateur;
            this.LoginUtilisateur = loginUtilisateur;
            this.MdpUtilisateur = mdpUtilisateur;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Utilisateur utilisateur &&
                   this.NomUtilisateur == utilisateur.NomUtilisateur &&
                   this.LoginUtilisateur == utilisateur.LoginUtilisateur &&
                   this.MdpUtilisateur == utilisateur.MdpUtilisateur;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumUtilisateur, this.NomUtilisateur, this.LoginUtilisateur, this.MdpUtilisateur);
        }

        #endregion
    }
}
