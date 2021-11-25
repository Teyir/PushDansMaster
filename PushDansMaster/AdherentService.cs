﻿using System;
using PushDansMaster.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public class AdherentService : IAdherentService
    {
        private AdherentDepot_DAL depot = new AdherentDepot_DAL();

        public List<Adherent> getAll()
        {
            var adherents = depot.getAll()
                .Select(f => new Adherent(f.societeAdherent, f.emailAdherent, f.nomAdherent, f.prenomAdherent, f.adresseAdherent, f.dateAdhesionAdherent,f.statusAdherent))
                .ToList();
            return adherents;
        }

        public Adherent getByID(int ID)
        {
            var f = depot.getByID(ID);


            return new Adherent(f.societeAdherent, f.emailAdherent, f.nomAdherent, f.prenomAdherent, f.adresseAdherent, f.dateAdhesionAdherent, f.statusAdherent);

        }

        public Adherent insert(Adherent f)
        {
            var adherent = new Adherent_DAL(f.idAdherent, f.societeAdherent, f.emailAdherent, f.nomAdherent, f.prenomAdherent, f.adresseAdherent, f.dateAdhesionAdherent, f.statusAdherent);
            depot.insert(adherent);


            return f;
        }

        public Adherent update(Adherent f)
        {
            var adherent = new Adherent_DAL(f.idAdherent, f.societeAdherent, f.emailAdherent, f.nomAdherent, f.prenomAdherent, f.adresseAdherent, f.dateAdhesionAdherent, f.statusAdherent);
            depot.update(adherent);

            return f;
        }

        public void delete(Adherent f)
        {
            var adherent = new Adherent_DAL(f.idAdherent, f.societeAdherent, f.emailAdherent, f.nomAdherent, f.prenomAdherent, f.adresseAdherent, f.dateAdhesionAdherent, f.statusAdherent);
            depot.delete(adherent);
        }

    }
}