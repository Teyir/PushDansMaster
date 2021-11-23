using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public class Fournisseur
    {
        public int idFournisseur { get; private set; }
        public string societeFournisseur { get; private set; }
        public bool civiliteFournisseur { get; private set; }
        public string nomFournisseur { get; private set; }
        public string prenomFournisseur { get; private set; }
        public string emailFournisseur { get; private set; }
        public string adresseFournisseur { get; private set; }


        public Fournisseur(string societe, bool civilite, string nom, string prenom, string email, string adresse)
        {
            societeFournisseur = societe;
            civiliteFournisseur = civilite;
            nomFournisseur = nom;
            prenomFournisseur = prenom;
            emailFournisseur = email;
            adresseFournisseur = adresse;
        }

       /* public override string ToString()
        {
            return $"()";
        }*/

    }

}
