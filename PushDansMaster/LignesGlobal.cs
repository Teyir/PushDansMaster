namespace PushDansMaster
{
    public class LignesGlobal
    {
        private int ID;
        private int id_panier;
        private int quantite;
        private string reference;
        private int id_reference;

        #region Getters / Setters
        public int getID
        {
            get { return ID; }
            private set { ID = value; }
        }

        /// <summary>
        /// Permet d'obtenir l'id panier
        /// </summary>
        public int getIDPanier
        {
            get { return id_panier; }
            private set { id_panier = value; }
        }

        public int getQuantite
        {
            get { return quantite; }
            private set { quantite = value; }
        }

        public string getReference
        {
            get { return reference; }
            private set { reference = value; }
        }

        public int getIDReference
        {
            get { return id_reference; }
            private set { id_reference = value; }
        }

        #endregion

        #region Constructeurs

        public LignesGlobal(int id_panier, int quantite, string reference, int id_reference)
        {
            this.id_panier = id_panier;
            this.quantite = quantite;
            this.reference = reference;
            this.id_reference = id_reference;
        }

        #endregion
    }
}
