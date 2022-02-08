using PushDansMaster.DAL;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster
{
    public class PanierGlobalService : IPanierGlobalService
    {
        private PanierGlobalDepot_DAL depot = new PanierGlobalDepot_DAL();

        public List<PanierGlobal> getAll()
        {
            var panier = depot.getAll()
                .Select(f => new PanierGlobal(f.getID, f.getStatus, f.getSemaine))

                .ToList();
            return panier;
        }

        public PanierGlobal getByID(int ID)
        {
            var f = depot.getByID(ID);


            return new PanierGlobal(f.getID, f.getStatus, f.getSemaine);

        }

        public PanierGlobal insert(PanierGlobal f)
        {
            var panier = new PanierGlobal_DAL(f.getID, f.getStatus, f.getSemaine);
            depot.insert(panier);


            return f;
        }

        public void deleteByID(int ID)
        {
            depot.deleteByID(ID);
        }
    }
}
