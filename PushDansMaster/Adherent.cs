using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public class Adherent
    {
        public string societeAdherent { get; private set; }

        public string emailAdherent { get; private set; }

        public string nomAdherent { get; private set; }

        public string prenomAdherent { get; private set; }

        public string adresseAdherent { get; private set; }

        public DateTime dateAdhesionAdherent { get; private set; }

        public bool statusAdherent { get; private set; }


        public Adherent(int id, string societe, string email, string nom, string prenom, string adresse, DateTime date_adhesion, bool status)
        {
            societeAdherent = societe;
            emailAdherent= email;
            nomAdherent = nom;
            prenomAdherent = prenom;
            adresseAdherent = adresse;
            dateAdhesionAdherent = DateTime.Now;
            statusAdherent = status;


        }

    }

}
