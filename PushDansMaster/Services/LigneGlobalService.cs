using PushDansMaster.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public class LigneGlobalService : ILigneGlobalService
    {
        private LignesGlobalDepot_DAL depot = new LignesGlobalDepot_DAL();

        public LignesGlobal insert(LignesGlobal f)
        {
            var line = new LignesGlobal_DAL(f.getIDPanier, f.getQuantite, f.getReference, f.getIDReference);
            depot.insert(line);

            return f;
        }
    }
}
