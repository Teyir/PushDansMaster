using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    class Prix
    {
        private int prix;
        private int idFournisseur;
        private int idLignesGlobal;

        #region Getters / Setters

        /// <summary>
        /// Permet d'obtenir le prix d'un objet grâce à l'ID d'un fournisseur et l'ID de sa ligne
        /// </summary>
        public int getPrix
        {
            get { return prix; }
            private set { prix = value; }
        }

        public int getIDFournisseur
        {
            get { return idFournisseur; }
            private set { idFournisseur = value; }
        }

        public int getIDLignesGlobal
        {
            get { return idLignesGlobal; }
            private set { idLignesGlobal = value; }
        }
        #endregion

        #region Constructeurs

        public Prix (int prix, int idFournisseur, int idLignesGlobal)
        {
            this.prix = prix;
            this.idFournisseur = idFournisseur;
            this.idLignesGlobal = idLignesGlobal;
        }

        #endregion
    }
}
