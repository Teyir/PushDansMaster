using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public class Fournisseur
    {
        private int ID;
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
            private set { ID = value; }
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
        #endregion

        #region Constructeur
        public Fournisseur(string societe, bool civilite, string nom, string prenom, string email, string adresse)
        {
            this.societeFournisseur = societe;
            this.civiliteFournisseur = civilite;
            this.nomFournisseur = nom;
            this.prenomFournisseur = prenom;
            this.emailFournisseur = email;
            this.adresseFournisseur = adresse;
        }
        #endregion
    }
}
