using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class CommandeAchat
    {
        #region Champs
        private int numCommande;
        private Magasin unMagasin;
        private ModeTransport unModeTransport;
        private DateOnly dateComande;
        private DateOnly dateLivraison;
        private string modeLivraison;
        #endregion

        #region Propriete
        public int NumCommande
        {
            get
            {
                return numCommande;
            }

            set
            {
                numCommande = value;
            }
        }

        public Magasin UnMagasin
        {
            get
            {
                return unMagasin;
            }

            set
            {
                unMagasin = value;
            }
        }

        public ModeTransport UnModeTransport
        {
            get
            {
                return unModeTransport;
            }

            set
            {
                unModeTransport = value;
            }
        }

        public DateOnly DateComande
        {
            get
            {
                return dateComande;
            }

            set
            {
                dateComande = value;
            }
        }

        public DateOnly DateLivraison
        {
            get
            {
                return dateLivraison;
            }

            set
            {
                dateLivraison = value;
            }
        }

        public string ModeLivraison
        {
            get
            {
                return this.modeLivraison;
            }

            set
            {
                this.modeLivraison = value;
            }
        }

        #endregion

        #region Constructeur
        public CommandeAchat(int numCommande, Magasin unMagasin, ModeTransport unModeTransport, DateOnly dateComande, DateOnly dateLivraison, string modeLivraison)
        {
            this.NumCommande = numCommande;
            this.UnMagasin = unMagasin;
            this.UnModeTransport = unModeTransport;
            this.DateComande = dateComande;
            this.DateLivraison = dateLivraison;
            this.ModeLivraison = modeLivraison;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is CommandeAchat achat &&
                   this.NumCommande == achat.NumCommande &&
                   EqualityComparer<Magasin>.Default.Equals(this.UnMagasin, achat.UnMagasin) &&
                   EqualityComparer<ModeTransport>.Default.Equals(this.UnModeTransport, achat.UnModeTransport) &&
                   this.DateComande.Equals(achat.DateComande) &&
                   this.DateLivraison.Equals(achat.DateLivraison) &&
                   this.ModeLivraison == achat.ModeLivraison;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumCommande, this.UnMagasin, this.UnModeTransport, this.DateComande, this.DateLivraison, this.ModeLivraison);
        }


        #endregion
    }
}
