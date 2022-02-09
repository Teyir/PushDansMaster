using PushDansMaster.DAL;
using System;


namespace PushDansMaster
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Push dans master...");

            Fournisseur_DAL four = new Fournisseur_DAL("test", false, "bodin", "axe", "bodin.axe@cool.com", "3 rue des fleurs", 1);
            FournisseurDepot_DAL dpf = new FournisseurDepot_DAL();
            dpf.insert(four);

            DateTime dt = DateTime.Now;
            Adherent_DAL adh = new Adherent_DAL("fulllife", "fulllife@gmail.com", "Michel", "Robert", "3 rue des magnolia", dt, 1);
            AdherentDepot_DAL dpadh = new AdherentDepot_DAL();
            dpadh.insert(adh);

            PanierGlobal_DAL pG = new PanierGlobal_DAL(1, 27);
            PanierGlobalDepot_DAL dppG = new PanierGlobalDepot_DAL();
            dppG.insert(pG);

            PanierAdherent_DAL padh = new PanierAdherent_DAL(0, 27, adh.getIdAdherent, pG.getID);
            PanierAdherentDepot_DAL dppadh = new PanierAdherentDepot_DAL();
            dppadh.insert(padh);

            Reference_DAL reff = new Reference_DAL("PC STYLAX", "HJCQJCQH97", "DELL", 20);
            ReferenceDepot_DAL dpreff = new ReferenceDepot_DAL();
            dpreff.insert(reff);

            LignesGlobal_DAL ligneGlob = new LignesGlobal_DAL(1, reff.getQuantite, reff.getReference, reff.ID);
            LignesGlobalDepot_DAL dplg = new LignesGlobalDepot_DAL();
            dplg.insert(ligneGlob);

            LignesAdherent_DAL ligneAdh = new LignesAdherent_DAL(20, reff.ID, padh.ID);
            LignesAdherentDepot_DAL dpla = new LignesAdherentDepot_DAL();
            dpla.insert(ligneAdh);

            Console.WriteLine("Test effectué :)");
        }
    }
}
