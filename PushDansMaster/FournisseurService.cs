using PushDansMaster.DAL;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster
{
    public class FournisseurService : IFournisseurService
    {
        private FournisseurDepot_DAL depot = new FournisseurDepot_DAL();

        /// <summary>
        /// getAll Fournisseurs
        /// </summary>
        public List<Fournisseur> getAll()
        {
            var fournisseurs = depot.getAll()
                .Select(f => new Fournisseur(f.societeFournisseur, f.civiliteFournisseur, f.nomFournisseur, f.prenomFournisseur, f.emailFournisseur, f.adresseFournisseur))
                .ToList();
            return fournisseurs;
        }

        /// <summary>
        /// getByID Fournisseur par ID
        /// </summary>
        public Fournisseur getByID(int ID)
        {
            var f = depot.getByID(ID);


        return new Fournisseur(f.societeFournisseur, f.civiliteFournisseur, f.nomFournisseur, f.prenomFournisseur, f.emailFournisseur, f.adresseFournisseur);
        
        }


        /// <summary>
        /// insert Ajouter Fournisseur
        /// </summary>
        public Fournisseur insert(Fournisseur f)
        {
            var fournisseur = new Fournisseur_DAL(f.getID,f.getSocieteFournisseur, f.getCiviliteFournisseur, f.getNomFournisseur, f.getPrenomFournisseur, f.getEmailFournisseur, f.getAdresseFournisseur);
            depot.insert(fournisseur);


            return f;
        }

        /// <summary>
        /// update Fournisseur
        /// </summary>
        public Fournisseur update(Fournisseur f)
        {
            var fournisseur = new Fournisseur_DAL(f.getID, f.getSocieteFournisseur, f.getCiviliteFournisseur, f.getNomFournisseur, f.getPrenomFournisseur, f.getEmailFournisseur, f.getAdresseFournisseur);
            depot.update(fournisseur);

            return f;
        }

        /// <summary>
        /// delete Fournisseur
        /// </summary>
        public void delete(Fournisseur f)
        {
            var fournisseur = new Fournisseur_DAL(f.getID, f.getSocieteFournisseur, f.getCiviliteFournisseur, f.getNomFournisseur, f.getPrenomFournisseur, f.getEmailFournisseur, f.getAdresseFournisseur);
            depot.delete(fournisseur);
        }
    }
}
