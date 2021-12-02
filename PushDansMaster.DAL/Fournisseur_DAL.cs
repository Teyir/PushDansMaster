using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class Fournisseur_DAL
    {
        public int ID;
        private string societeFournisseur;
        private bool civiliteFournisseur;
        private string nomFournisseur;
        private string prenomFournisseur;
        private string emailFournisseur;
        private string adresseFournisseur;

        #region Getters / Setters
        public int getID
        {
            get { return ID; }
            set { ID = value; }
        }

        public bool getCiviliteFournisseur
        {
            get { return civiliteFournisseur; }
            private set { civiliteFournisseur = value; }
        }

        public string getSocieteFournisseur
        {
            get { return societeFournisseur; }
            private set { societeFournisseur = value; }
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
        #endregion

        #region Constructeur
        public Fournisseur_DAL(string societe, bool civilite, string nom, string prenom, string email, string adresse)
           => (societeFournisseur, civiliteFournisseur, nomFournisseur, prenomFournisseur, emailFournisseur, adresseFournisseur)
           = (societe, civilite, nom, prenom, email, adresse);

        public Fournisseur_DAL(int id,string societe, bool civilite, string nom, string prenom, string email, string adresse)
            => (ID, societeFournisseur, civiliteFournisseur, nomFournisseur, prenomFournisseur, emailFournisseur, adresseFournisseur)
            = (id,societe, civilite, nom, prenom, email, adresse);
        #endregion

        #region Methodes
        internal void addFournisseur(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO fournisseur(societe, civilite, nom, prenom, email, adresse)"
                                       +  " VALUES (@societe, @civilite, @nom, @prenom, @email, @adresse)";
                command.Parameters.Add(new SqlParameter("@societe", societeFournisseur));
                command.Parameters.Add(new SqlParameter("@civilite", civiliteFournisseur));
                command.Parameters.Add(new SqlParameter("@nom", nomFournisseur));
                command.Parameters.Add(new SqlParameter("@prenom", prenomFournisseur));
                command.Parameters.Add(new SqlParameter("@email", emailFournisseur));
                command.Parameters.Add(new SqlParameter("@adresse", adresseFournisseur));

                command.ExecuteNonQuery();
            }
           
        }
        #endregion
    }
}
