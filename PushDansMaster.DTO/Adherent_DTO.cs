using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DTO
{
    public class Adherent_DTO
    {
        public int idAdherent { get; set; }
        public string societeAdherent { get; set; }
        public string emailAdherent { get; set; }
        public string nomAdherent { get; set; }
        public string prenomAdherent { get; set; }
        public string adresseAdherent { get; set; }
        public DateTime dateAdhesionAdherent { get; set; }
        public int statusAdherent { get; set; }

    }
}
