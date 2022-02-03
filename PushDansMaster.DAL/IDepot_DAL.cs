using System.Collections.Generic;

namespace PushDansMaster.DAL
{
    //Interface with getter / setters
    interface IDepot_DAL<Type_DAL>
    {
        public string connectionString { get; set; }

        public List<Type_DAL> getAll();

        public Type_DAL getByID(int ID);

        public Type_DAL insert(Type_DAL item);

        public Type_DAL update(Type_DAL item);

        public void delete(Type_DAL item);

        public void deleteByID(int ID);
    }
}
