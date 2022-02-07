using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public interface IPanierGlobalService
    {
        public List<PanierGlobal> getAll();

        public PanierGlobal getByID(int ID);

        public PanierGlobal insert(PanierGlobal f);
    }
}
