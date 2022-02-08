using PushDansMaster.DAL;

namespace PushDansMaster
{
    public class LigneGlobalService : ILigneGlobalService
    {
        private LignesGlobalDepot_DAL depot = new LignesGlobalDepot_DAL();

        public LignesGlobal insert(LignesGlobal f)
        {
            var line = new LignesGlobal_DAL(f.getIDPanier, f.getQuantite, f.getReference, f.getIDReference);
            depot.insert(line);

            return f;
        }
    }
}
