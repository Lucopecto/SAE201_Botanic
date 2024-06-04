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
        private string modedeTransport;
        #endregion

        #region Propriete
        public string ModedeTransport
        {
            get
            {
                return this.modedeTransport;
            }

            set
            {
                this.modedeTransport = value;
            }
        }
        #endregion

        #region Constructeur
        public ModeTransport(string modeTransport)
        {
            this.ModedeTransport = modeTransport;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is ModeTransport transport &&
                   this.ModedeTransport == transport.ModedeTransport;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.ModedeTransport);
        }
        #endregion
    }
}
