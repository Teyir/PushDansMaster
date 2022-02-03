using System.Collections.Generic;

namespace PushDansMaster
{
    public interface IFournisseurService
    {
        public List<Fournisseur> getAll();

        public Fournisseur getByID(int ID);

        public Fournisseur insert(Fournisseur f);

        public Fournisseur update(Fournisseur f);

        public void delete(Fournisseur f);

        public void deleteByID(int ID);

    }
}
