namespace PushDansMaster
{
    public class Reference
    {
        private int ID;
        private string libelle;
        private string reference;
        private string marque;
        private int quantite;

        #region Getters / Setters
        public int getID
        {
            get => ID;
            private set => ID = value;
        }
        public string getLibelle
        {
            get => libelle;
            private set => libelle = value;
        }
        public string getReference
        {
            get => reference;
            private set => reference = value;
        }
        public string getMarque
        {
            get => marque;
            private set => marque = value;
        }
        public int getQuantite
        {
            get => quantite;
            private set => quantite = value;
        }
        #endregion

        #region Constructeur
        public Reference(string libelle, string reference, string marque, int quantite)
        {
            this.libelle = libelle;
            this.reference = reference;
            this.marque = marque;
            this.quantite = quantite;

        }

        public Reference(int id, string libelle, string reference, string marque, int quantite)
            : this(libelle, reference, marque, quantite)
        {
            ID = id;
        }

        public Reference()
        {

        }
        #endregion
    }
}
