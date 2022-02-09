using PushDansMaster.DAL;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster
{
    public class PanierAdherentService : IPanierAdherentService
    {
        private readonly PanierAdherentDepot_DAL depot = new PanierAdherentDepot_DAL();

        public List<PanierAdherent> getAll()
        {
            List<PanierAdherent> panier = depot.getAll()
                .Select(f => new PanierAdherent(f.getID, f.getStatus, f.getSemaine, f.getId_adherent, f.getId_panierGlobal))

                .ToList();
            return panier;
        }

        public PanierAdherent getByID(int ID)
        {
            PanierAdherent_DAL f = depot.getByID(ID);


            return new PanierAdherent(f.getID, f.getStatus, f.getSemaine, f.getId_adherent, f.getId_panierGlobal);

        }

        public PanierAdherent insert(PanierAdherent f)
        {
            PanierAdherent_DAL panier = new PanierAdherent_DAL(f.getID, f.getStatus, f.getSemaine, f.getID_adherent, f.getID_panierGlobal);
            depot.insert(panier);


            return f;
        }

        public void deleteByID(int ID)
        {
            depot.deleteByID(ID);
        }
    }
}
