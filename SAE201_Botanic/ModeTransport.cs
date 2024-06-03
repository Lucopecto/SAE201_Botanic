using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class ModeTransport
    {
        #region Champs
        private string modeTransport;
        #endregion

        #region Propriete
        public string ModeTransport
        {
            get
            {
                return this.modeTransport;
            }

            set
            {
                this.modeTransport = value;
            }
        }
        #endregion

        #region Constructeur
        public ModeTransport(string modeTransport)
        {
            this.ModeTransport = modeTransport;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is ModeTransport transport &&
                   this.ModeTransport == transport.ModeTransport;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.ModeTransport);
        }
        #endregion
    }
}
