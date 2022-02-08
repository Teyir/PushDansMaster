using PushDansMaster.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public class LigneAdherentService : ILigneAdherentService
    {
        private LignesAdherentDepot_DAL depot = new LignesAdherentDepot_DAL();

        public LignesAdherent insert(LignesAdherent f)
        {
            var line = new LignesAdherent_DAL(f.getID, f.getID_panier, f.getID_reference, f.getQuantite);
            depot.insert(line);

            return f;
        }
    }
}
