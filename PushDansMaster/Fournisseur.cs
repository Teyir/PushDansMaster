namespace PushDansMaster
{
    public class Fournisseur
    {
        private int idFournisseur;
        private string societeFournisseur;
        private bool civiliteFournisseur;
        private string nomFournisseur;
        private string prenomFournisseur;
        private string emailFournisseur;
        private string adresseFournisseur;
        private int statusFournisseur;

        #region Getters / Setters
        public int getIdFournisseur
        {
            get { return idFournisseur; }
            private set { idFournisseur = value; }
        }
        public string getSocieteFournisseur
        {
            get { return societeFournisseur; }
            private set { societeFournisseur = value; }
        }
        public bool getCiviliteFournisseur
        {
            get { return civiliteFournisseur; }
            private set { civiliteFournisseur = value; }
        }
        public string getNomFournisseur
        {
            get { return nomFournisseur; }
            private set { nomFournisseur = value; }
        }
        public string getPrenomFournisseur
        {
            get { return prenomFournisseur; }
            private set { prenomFournisseur = value; }
        }
        public string getEmailFournisseur
        {
            get { return emailFournisseur; }
            private set { emailFournisseur = value; }
        }
        public string getAdresseFournisseur
        {
            get { return adresseFournisseur; }
            private set { adresseFournisseur = value; }
        }

        public int getStatusFournisseur
        {
            get { return statusFournisseur; }
            private set { statusFournisseur = value; }
        }
        #endregion

        #region Constructeur
        public Fournisseur(string societe, bool civilite, string nom, string prenom, string email, string adresse, int status)
        {
            this.societeFournisseur = societe;
            this.civiliteFournisseur = civilite;
            this.nomFournisseur = nom;
            this.prenomFournisseur = prenom;
            this.emailFournisseur = email;
            this.adresseFournisseur = adresse;
            this.statusFournisseur = status;
        }
        public Fournisseur(int id,string societe, bool civilite, string nom, string prenom, string email, string adresse, int status)
            :this(societe,civilite,nom,prenom,email,adresse, status)
        {
            this.idFournisseur = id;
        }
        #endregion
    }
}
