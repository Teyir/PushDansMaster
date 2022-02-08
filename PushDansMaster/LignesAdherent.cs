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
            get => ID;
            private set => ID = value;
        }
        public int getID_panier
        {
            get => id_panier;
            private set => id_panier = value;
        }

        public int getID_reference
        {
            get => id_reference;
            private set => id_reference = value;
        }

        public int getQuantite
        {
            get => Quantite;
            private set => Quantite = value;
        }

        #endregion

        #region Constructeurs
        public LignesAdherent(int idP, int idR, int qts)
        {
            id_panier = idP;
            id_reference = idR;
            Quantite = qts;
        }

        public LignesAdherent(int id, int idP, int idR, int qts)
            : this(idP, idR, qts)
        {
            ID = id;
        }

        public LignesAdherent()
        {

        }

        #endregion

    }
}
