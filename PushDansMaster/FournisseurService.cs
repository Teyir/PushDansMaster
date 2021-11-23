using PushDansMaster.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return new Fournisseur(f.ID,)
        }


        /// <summary>
        /// insert Ajouter Fournisseur
        /// </summary>
        public Fournisseur insert(Fournisseur f)
        {
            throw new Exception("Insert pas fais");
        }

        /// <summary>
        /// update Fournisseur
        /// </summary>
        public Fournisseur update(Fournisseur f)
        {
            throw new Exception("Update pas fais");
        }

        /// <summary>
        /// delete Fournisseur
        /// </summary>
        public void delete(Fournisseur f)
        {
            var fournisseur = new Fournisseur_DAL(f.idFournisseur, f.societeFournisseur, f.civiliteFournisseur, f.nomFournisseur, f.prenomFournisseur, f.emailFournisseur, f.adresseFournisseur);
            depot.delete(fournisseur);
        }
    }
}
