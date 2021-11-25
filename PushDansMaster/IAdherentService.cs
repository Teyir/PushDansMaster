using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public interface IAdherentService
    {
        public List<Adherent> getAll();

        public Adherent getByID(int ID);

        public Adherent insert(Adherent f);

        public Adherent update(Adherent f);

        public void delete(Adherent f);
    }
}
