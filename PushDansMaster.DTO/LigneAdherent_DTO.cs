using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DTO
{
    public class LigneGlobal_DTO
    {
        public int ID { get; set; }
        public int id_panier { get; set; }
        public int quantite { get; set; }
        public string reference { get; set; }
        public int id_reference { get; set; }
    }
}
