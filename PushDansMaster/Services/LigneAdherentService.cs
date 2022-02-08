using PushDansMaster.DAL;

namespace PushDansMaster
{
    public class LigneAdherentService : ILigneAdherentService
    {
        private readonly LignesAdherentDepot_DAL depot = new LignesAdherentDepot_DAL();

        public LignesAdherent insert(LignesAdherent f)
        {
            LignesAdherent_DAL line = new LignesAdherent_DAL(f.getID, f.getID_panier, f.getID_reference, f.getQuantite);
            depot.insert(line);

            return f;
        }
    }
}
