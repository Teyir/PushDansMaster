using PushDansMaster.DAL;
using System;
using System.Collections.Generic;


namespace PushDansMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Push dans master...");

            var four = new Fournisseur_DAL("test", false, "bodin", "axe", "bodin.axe@cool.com", "3 rue des fleurs");
            var dpf = new FournisseurDepot_DAL();
            dpf.insert(four);

            DateTime dt = DateTime.Now;
            var adh = new Adherent_DAL("fulllife", "fulllife@gmail.com", "Michel", "Robert", "3 rue des magnolia", dt, 1);
            var dpadh = new AdherentDepot_DAL();
            dpadh.insert(adh);

            var pG = new PanierGlobal_DAL(false, 27);
            var dppG = new PanierGlobalDepot_DAL();
            dppG.insert(pG);

            var padh = new PanierAdherent_DAL(false, 27, adh.getIdAdherent, pG.getID);
            var dppadh = new PanierAdherentDepot_DAL();
            dppadh.insert(padh);

            var reff = new Reference_DAL("PC STYLAX", "HJCQJCQH97", "DELL", 20);
            var dpreff = new ReferenceDepot_DAL();
            dpreff.insert(reff);

            var ligneGlob = new LignesGlobal_DAL(1, reff.getQuantite, reff.getReference, reff.ID);
            var dplg = new LignesGlobalDepot_DAL();
            dplg.insert(ligneGlob);

            var ligneAdh = new LignesAdherent_DAL(20, reff.ID, padh.ID);
            var dpla = new LignesAdherentDepot_DAL();
            dpla.insert(ligneAdh);

            Console.WriteLine("Test effectué :)");
        }
    }
}
