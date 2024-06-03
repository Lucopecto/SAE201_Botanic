using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Magasin
    {
        #region Champs
        private string numMagasin;
        private int nomMagasin;
        private string rueMagasin;
        private string CPMagasin;
        private string villeMagasin;
        private DateTime horaire;
        #endregion

        #region Propriete
        public string NumMagasin
        {
            get
            {
                return numMagasin;
            }

            set
            {
                numMagasin = value;
            }
        }

        public int NomMagasin
        {
            get
            {
                return nomMagasin;
            }

            set
            {
                nomMagasin = value;
            }
        }

        public string RueMagasin
        {
            get
            {
                return rueMagasin;
            }

            set
            {
                rueMagasin = value;
            }
        }

        public string CPMagasin1
        {
            get
            {
                return CPMagasin;
            }

            set
            {
                CPMagasin = value;
            }
        }

        public string VilleMagasin
        {
            get
            {
                return villeMagasin;
            }

            set
            {
                villeMagasin = value;
            }
        }

        public DateTime Horaire
        {
            get
            {
                return this.horaire;
            }

            set
            {
                this.horaire = value;
            }
        }


        #endregion

        #region Constructeur
        public Magasin(string numMagasin, int nomMagasin, string rueMagasin, string cPMagasin1, string villeMagasin, DateTime horaire)
        {
            this.NumMagasin = numMagasin;
            this.NomMagasin = nomMagasin;
            this.RueMagasin = rueMagasin;
            this.CPMagasin1 = cPMagasin1;
            this.VilleMagasin = villeMagasin;
            this.Horaire = horaire;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Magasin magasin &&
                   this.NumMagasin == magasin.NumMagasin &&
                   this.NomMagasin == magasin.NomMagasin &&
                   this.RueMagasin == magasin.RueMagasin &&
                   this.CPMagasin1 == magasin.CPMagasin1 &&
                   this.VilleMagasin == magasin.VilleMagasin &&
                   this.Horaire == magasin.Horaire;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumMagasin, this.NomMagasin, this.RueMagasin, this.CPMagasin1, this.VilleMagasin, this.Horaire);
        }

        #endregion
    }
}
