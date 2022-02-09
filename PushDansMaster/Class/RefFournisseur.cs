namespace PushDansMaster
{
    public class RefFournisseur
    {
        private int id_fournisseur;
        private int id_reference;

        #region Getters / Setters

        public int getIDfournisseur
        {
            get => id_fournisseur;
            private set => id_fournisseur = value;
        }

        public int getIDreference
        {
            get => id_reference;
            private set => id_reference = value;
        }

        #endregion

        #region Constructeurs

        public RefFournisseur(int id_fournisseur, int id_reference)
        {
            this.id_fournisseur = id_fournisseur;
            this.id_reference = id_reference;
        }

        #endregion
    }
}
