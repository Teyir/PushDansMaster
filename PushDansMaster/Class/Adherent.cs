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
        public int getStatusAdherent
        {
            get => statusAdherent;
            private set => statusAdherent = value;
        }

        #endregion

        #region Constructeurs
        public Adherent(string societe, string email, string nom, string prenom, string adresse, int status)
        {
            societeAdherent = societe;
            emailAdherent = email;
            nomAdherent = nom;
            prenomAdherent = prenom;
            adresseAdherent = adresse;
            statusAdherent = status;
        }

        public Adherent(int id, string societe, string email, string nom, string prenom, string adresse, DateTime date_adhesion, int status)
        : this(societe, email, nom, prenom, adresse, date_adhesion, status)
        {
            idAdherent = id;
        }

        public Adherent(int id, string societe, string email, string nom, string prenom, string adresse, int status)
        : this(societe, email, nom, prenom, adresse, status)
        {
            idAdherent = id;
        }

        public Adherent(string societe, string email, string nom, string prenom, string adresse, DateTime date_adhesion, int status)
        : this(societe, email, nom, prenom, adresse, status)
        {
            dateAdhesionAdherent = DateTime.Now;
        }



        #endregion
    }
}
