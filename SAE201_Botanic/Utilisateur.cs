using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Utilisateur /*: Magasin*/
    {
        #region Chammps
        private int numUtilisateur;
        //private Magasin unMagazin;
        private string loginUtilisateur;
        private string mdpUtilisateur;
        #endregion

        #region Propriete
        public int NumUtilisateur
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

        //public Magasin UnMagazin
        //{
        //    get
        //    {
        //        return unMagazin;
        //    }

        //    set
        //    {
        //        unMagazin = value;
        //    }
        //}

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
        public Utilisateur(int numUtilisateur, Magasin unMagazin, string loginUtilisateur, string mdpUtilisateur)
        {
            this.NumUtilisateur = numUtilisateur;
            //this.UnMagazin = unMagazin;
            this.LoginUtilisateur = loginUtilisateur;
            this.MdpUtilisateur = mdpUtilisateur;
        }

        //public Utilisateur(string numMagasin, int nomMagasin, string rueMagasin, string cPMagasin1, string villeMagasin, DateTime horaire) : base(numMagasin, nomMagasin, rueMagasin, cPMagasin1, villeMagasin, horaire)
        //{
        //}

        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Utilisateur utilisateur &&
                   //this.NomUtilisateur == utilisateur.NomUtilisateur &&
                   this.LoginUtilisateur == utilisateur.LoginUtilisateur &&
                   this.MdpUtilisateur == utilisateur.MdpUtilisateur;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumUtilisateur, /*this.NomUtilisateur,*/ this.LoginUtilisateur, this.MdpUtilisateur);
        }

        #endregion
    }
}
