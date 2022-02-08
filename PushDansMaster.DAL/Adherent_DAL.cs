using System;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class Adherent_DAL
    {

        public int idAdherent;
        private string societeAdherent;
        private string emailAdherent;
        private string nomAdherent;
        private string prenomAdherent;
        private string adresseAdherent;
        private DateTime dateAdhesionAdherent;
        private int statusAdherent;

        #region Getters / Setters

        public int getIdAdherent
        {
            get => idAdherent;
            private set => idAdherent = value;
        }

        public string getSocieteAdherent
        {
            get => societeAdherent;
            private set => societeAdherent = value;
        }
        public string getEmailAdherent
        {
            get => emailAdherent;
            private set => emailAdherent = value;
        }
        public string getNomAdherent
        {
            get => nomAdherent;
            private set => nomAdherent = value;
        }
        public string getPrenomAdherent
        {
            get => prenomAdherent;
            private set => prenomAdherent = value;
        }
        public string getAdresseAdherent
        {
            get => adresseAdherent;
            private set => adresseAdherent = value;
        }
        public DateTime getDateAdhesionAdherent
        {
            get => dateAdhesionAdherent;
            private set => dateAdhesionAdherent = value;
        }
        public int getStatus
        {
            get => statusAdherent;
            private set => statusAdherent = value;
        }

        #endregion

        #region Constructeurs
        public Adherent_DAL(string societe, string email, string nom, string prenom, string adresse, DateTime dateAdhesion, int status)
        {
            (societeAdherent, emailAdherent, nomAdherent, prenomAdherent, adresseAdherent, dateAdhesionAdherent, statusAdherent)
                   = (societe, email, nom, prenom, adresse, dateAdhesion, status);
        }

        public Adherent_DAL(int id, string societe, string email, string nom, string prenom, string adresse, DateTime dateAdhesion, int status)
        {
            (idAdherent, societeAdherent, emailAdherent, nomAdherent, prenomAdherent, adresseAdherent, dateAdhesionAdherent, statusAdherent)
                   = (id, societe, email, nom, prenom, adresse, dateAdhesion, status);
        }

        #endregion


        #region Methodes
        internal void Insert(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO adherent(societe, email, nom, prenom, adresse, date_adhesion, status"
                        + " VALUES (@societe, @email, @nom, @prenom, @adresse, @date_adhesion, @status)";
                command.Parameters.Add(new SqlParameter("@societe", societeAdherent));
                command.Parameters.Add(new SqlParameter("@email", emailAdherent));
                command.Parameters.Add(new SqlParameter("@nom", nomAdherent));
                command.Parameters.Add(new SqlParameter("@prenom", prenomAdherent));
                command.Parameters.Add(new SqlParameter("@adresse", adresseAdherent));
                command.Parameters.Add(new SqlParameter("@date_adhesion", dateAdhesionAdherent));
                command.Parameters.Add(new SqlParameter("@status", statusAdherent));

                command.ExecuteNonQuery();

                connection.Close();

            }
        }
        #endregion
    }
}
