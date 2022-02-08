using System;

namespace PushDansMaster
{
    public class Adherent
    {
        private int idAdherent;
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
            get { return idAdherent; }
            private set { idAdherent = value; }
        }
        public string getSocieteAdherent
        {
            get { return societeAdherent; }
            private set { societeAdherent = value; }
        }
        public string getEmailAdherent
        {
            get { return emailAdherent; }
            private set { emailAdherent = value; }
        }
        public string getNomAdherent
        {
            get { return nomAdherent; }
            private set { nomAdherent = value; }
        }
        public string getPrenomAdherent
        {
            get { return prenomAdherent; }
            private set { prenomAdherent = value; }
        }
        public string getAdresseAdherent
        {
            get { return adresseAdherent; }
            private set { adresseAdherent = value; }
        }
        public DateTime getDateAdhesionAdherent
        {
            get { return dateAdhesionAdherent; }
            private set { dateAdhesionAdherent = value; }
        }
        public int getStatusAdherent
        {
            get { return statusAdherent; }
            private set { statusAdherent = value; }
        }

        #endregion

        #region Constructeurs
        public Adherent(string societe, string email, string nom, string prenom, string adresse, int status)
        {
            this.societeAdherent = societe;
            this.emailAdherent = email;
            this.nomAdherent = nom;
            this.prenomAdherent = prenom;
            this.adresseAdherent = adresse;
            this.statusAdherent = status;
        }

        public Adherent(int id, string societe, string email, string nom, string prenom, string adresse, DateTime date_adhesion, int status)
        : this(societe, email, nom, prenom, adresse, date_adhesion, status)
        {
            this.idAdherent = id;
        }

        public Adherent(int id, string societe, string email, string nom, string prenom, string adresse, int status)
        : this(societe, email, nom, prenom, adresse, status)
        {
            this.idAdherent = id;
        }

        public Adherent(string societe, string email, string nom, string prenom, string adresse, DateTime date_adhesion, int status)
        : this(societe, email, nom, prenom, adresse, status)
        {
            this.dateAdhesionAdherent = DateTime.Now;
        }



        #endregion
    }
}
