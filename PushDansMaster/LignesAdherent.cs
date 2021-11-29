using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public class LignesAdherent
    {
        private int ID;
        private int id_panier;
        private int id_reference;
        private int Quantite;

        #region Getters / Setters
        public int getID
        {
            get { return ID; }
            private set { ID = value; }
        }
        public int getID_panier
        {
            get { return id_panier; }
            private set { id_panier = value; }
        }

        public int getID_reference
        {
            get { return id_reference; }
            private set { id_reference = value; }
        }

        public int getQuantite
        {
            get { return Quantite; }
            private set { Quantite = value; }
        }

        #endregion

        #region Constructeurs
        public LignesAdherent(int idP, int idR,  int qts)
        {
            this.id_panier = idP;
            this.id_reference = idR;
            this.Quantite = qts;
        }

        #endregion

    }
}
