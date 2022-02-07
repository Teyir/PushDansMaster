using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public interface IPanierAdherentService
    {
        public List<PanierAdherent> getAll();

        public PanierAdherent getByID(int ID);

        public PanierAdherent insert(PanierAdherent f);

    }
}
