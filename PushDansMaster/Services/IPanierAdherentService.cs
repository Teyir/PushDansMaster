using System.Collections.Generic;

namespace PushDansMaster
{
    public interface IPanierAdherentService
    {
        public List<PanierAdherent> getAll();

        public PanierAdherent getByID(int ID);

        public PanierAdherent insert(PanierAdherent f);

        public void deleteByID(int ID);

    }
}
