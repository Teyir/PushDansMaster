using PushDansMaster.DAL;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster
{
    public class AdherentService : IAdherentService
    {
        private readonly AdherentDepot_DAL depot = new AdherentDepot_DAL();

        public List<Adherent> getAll()
        {
            List<Adherent> adherents = depot.getAll()
                .Select(f => new Adherent(f.getIdAdherent, f.getSocieteAdherent, f.getEmailAdherent, f.getNomAdherent, f.getPrenomAdherent, f.getAdresseAdherent, f.getDateAdhesionAdherent, f.getStatus))

                .ToList();
            return adherents;
        }

        public Adherent getByID(int ID)
        {
            Adherent_DAL f = depot.getByID(ID);


            return new Adherent(f.getIdAdherent, f.getSocieteAdherent, f.getEmailAdherent, f.getNomAdherent, f.getPrenomAdherent, f.getAdresseAdherent, f.getDateAdhesionAdherent, f.getStatus);

        }

        public Adherent insert(Adherent f)
        {
            Adherent_DAL adherent = new Adherent_DAL(f.getIdAdherent, f.getSocieteAdherent, f.getEmailAdherent, f.getNomAdherent, f.getPrenomAdherent, f.getAdresseAdherent, f.getDateAdhesionAdherent, f.getStatusAdherent);
            depot.insert(adherent);


            return f;
        }

        public Adherent update(Adherent f)
        {
            Adherent_DAL adherent = new Adherent_DAL(f.getIdAdherent, f.getSocieteAdherent, f.getEmailAdherent, f.getNomAdherent, f.getPrenomAdherent, f.getAdresseAdherent, f.getDateAdhesionAdherent, f.getStatusAdherent);
            depot.update(adherent);

            return f;
        }

        public void delete(Adherent f)
        {
            Adherent_DAL adherent = new Adherent_DAL(f.getIdAdherent, f.getSocieteAdherent, f.getEmailAdherent, f.getNomAdherent, f.getPrenomAdherent, f.getAdresseAdherent, f.getDateAdhesionAdherent, f.getStatusAdherent);
            depot.delete(adherent);
        }

        public void deleteByID(int ID)
        {
            depot.deleteByID(ID);
        }

    }
}
