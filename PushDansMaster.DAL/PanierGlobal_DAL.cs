using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DAL
{
    class PanierGlobal_DAL
    {
        public int ID { get; }
        public bool status { get; private set; }
        public int semaine { get; private set; }
        public PanierGlobal_DAL(bool status, int semaine) => (this.status, this.semaine) = (status, semaine);

        internal void insert(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO panier_global(status, semaine) values (@status, @semaine)";

                command.Parameters.Add(new SqlParameter("@status", status));
                command.Parameters.Add(new SqlParameter("@semaine", semaine));

                command.ExecuteNonQuery();
            }
        }
    }
}