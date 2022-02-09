namespace PushDansMaster
{
    public class Prix
    {
        private int prix;
        private int idFournisseur;
        private int idLignesGlobal;

        #region Getters / Setters

        public int getPrix
        {
            get => prix;
            private set => prix = value;
        }

        public int getIDFournisseur
        {
            get => idFournisseur;
            private set => idFournisseur = value;
        }

        public int getIDLignesGlobal
        {
            get => idLignesGlobal;
            private set => idLignesGlobal = value;
        }
        #endregion

        #region Constructeurs

        public Prix(int prix, int idFournisseur, int idLignesGlobal)
        {
            this.prix = prix;
            this.idFournisseur = idFournisseur;
            this.idLignesGlobal = idLignesGlobal;
        }

        #endregion
    }
}
