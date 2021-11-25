using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public interface IFournisseurService
    {

        public List<Fournisseur> getAll();

        public Fournisseur getByID(int ID);

        public Fournisseur insert(Fournisseur f);

        public Fournisseur update(Fournisseur f);

        public void delete(Fournisseur f);

    }
}
