using PushDansMaster.DAL;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster
{
    public class AdherentService : IAdherentService
    {
        private AdherentDepot_DAL depot = new AdherentDepot_DAL();

        public List<Adherent> getAll()
        {
            var adherents = depot.getAll()
                .Select(f => new Adherent(f.getIdAdherent,f.getSocieteAdherent, f.getEmailAdherent, f.getNomAdherent, f.getPrenomAdherent, f.getAdresseAdherent, f.getDateAdhesionAdherent,f.getStatus))
                .ToList();
            return adherents;
        }

        public Adherent getByID(int ID)
        {
            var f = depot.getByID(ID);


            return new Adherent(f.getIdAdherent, f.getSocieteAdherent, f.getEmailAdherent, f.getNomAdherent, f.getPrenomAdherent, f.getAdresseAdherent, f.getDateAdhesionAdherent, f.getStatus);

        }

        public Adherent insert(Adherent f)
        {
            var adherent = new Adherent_DAL(f.getIdAdherent, f.getSocieteAdherent, f.getEmailAdherent, f.getNomAdherent, f.getPrenomAdherent, f.getAdresseAdherent, f.getDateAdhesionAdherent, f.getStatusAdherent);
            depot.insert(adherent);


            return f;
        }

        public Adherent update(Adherent f)
        {
            var adherent = new Adherent_DAL(f.getIdAdherent, f.getSocieteAdherent, f.getEmailAdherent, f.getNomAdherent, f.getPrenomAdherent, f.getAdresseAdherent, f.getDateAdhesionAdherent, f.getStatusAdherent);
            depot.update(adherent);

            return f;
        }

        public void delete(Adherent f)
        {
            var adherent = new Adherent_DAL(f.getIdAdherent, f.getSocieteAdherent, f.getEmailAdherent, f.getNomAdherent, f.getPrenomAdherent, f.getAdresseAdherent, f.getDateAdhesionAdherent, f.getStatusAdherent);
            depot.delete(adherent);
        }

        public void deleteByID(int ID)
        {
            depot.deleteByID(ID);
        }

    }
}
