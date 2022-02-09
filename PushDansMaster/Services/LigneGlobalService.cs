using PushDansMaster.DAL;

namespace PushDansMaster
{
    public class LigneGlobalService : ILigneGlobalService
    {
        private readonly LignesGlobalDepot_DAL depot = new LignesGlobalDepot_DAL();

        public LignesGlobal insert(LignesGlobal f)
        {
            LignesGlobal_DAL line = new LignesGlobal_DAL(f.getIDPanier, f.getQuantite, f.getReference, f.getIDReference);
            depot.insert(line);

            return f;
        }
    }
}
