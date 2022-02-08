using PushDansMaster.DAL;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster
{
    public class PanierAdherentService : IPanierAdherentService
    {
        private PanierAdherentDepot_DAL depot = new PanierAdherentDepot_DAL();

        public List<PanierAdherent> getAll()
        {
            var panier = depot.getAll()
                .Select(f => new PanierAdherent(f.getID, f.getStatus, f.getSemaine, f.getId_adherent, f.getId_panierGlobal))

                .ToList();
            return panier;
        }

        public PanierAdherent getByID(int ID)
        {
            var f = depot.getByID(ID);


            return new PanierAdherent(f.getID, f.getStatus, f.getSemaine, f.getId_adherent, f.getId_panierGlobal);

        }

        public PanierAdherent insert(PanierAdherent f)
        {
            var panier = new PanierAdherent_DAL(f.getID, f.getStatus, f.getSemaine, f.getID_adherent, f.getID_panierGlobal);
            depot.insert(panier);


            return f;
        }

        public void deleteByID(int ID)
        {
            depot.deleteByID(ID);
        }
    }
}
