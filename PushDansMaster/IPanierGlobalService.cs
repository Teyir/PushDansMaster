using System.Collections.Generic;

namespace PushDansMaster
{
    public interface IPanierGlobalService
    {
        public List<PanierGlobal> getAll();

        public PanierGlobal getByID(int ID);

        public PanierGlobal insert(PanierGlobal f);

        public void deleteByID(int ID);
    }
}
