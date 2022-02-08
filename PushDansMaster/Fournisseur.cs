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
            get => idFournisseur;
            private set => idFournisseur = value;
        }
        public string getSocieteFournisseur
        {
            get => societeFournisseur;
            private set => societeFournisseur = value;
        }
        public bool getCiviliteFournisseur
        {
            get => civiliteFournisseur;
            private set => civiliteFournisseur = value;
        }
        public string getNomFournisseur
        {
            get => nomFournisseur;
            private set => nomFournisseur = value;
        }
        public string getPrenomFournisseur
        {
            get => prenomFournisseur;
            private set => prenomFournisseur = value;
        }
        public string getEmailFournisseur
        {
            get => emailFournisseur;
            private set => emailFournisseur = value;
        }
        public string getAdresseFournisseur
        {
            get => adresseFournisseur;
            private set => adresseFournisseur = value;
        }

        public int getStatusFournisseur
        {
            get => statusFournisseur;
            private set => statusFournisseur = value;
        }
        #endregion

        #region Constructeur
        public Fournisseur(string societe, bool civilite, string nom, string prenom, string email, string adresse, int status)
        {
            societeFournisseur = societe;
            civiliteFournisseur = civilite;
            nomFournisseur = nom;
            prenomFournisseur = prenom;
            emailFournisseur = email;
            adresseFournisseur = adresse;
            statusFournisseur = status;
        }
        public Fournisseur(int id, string societe, bool civilite, string nom, string prenom, string email, string adresse, int status)
            : this(societe, civilite, nom, prenom, email, adresse, status)
        {
            idFournisseur = id;
        }
        #endregion
    }
}
