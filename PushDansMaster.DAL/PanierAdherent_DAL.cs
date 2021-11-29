using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DAL
{
    public class PanierAdherent_DAL
    {
        public int ID { get; }
        public bool status { get; private set; }
        public int semaine { get; private set; }
        public int id_adherent { get; private set; }
        public int id_panierGlobal { get; private set; }


        public PanierAdherent_DAL(bool status, int semaine, int id_adh, int id_panierGlo) => (this.status, this.semaine, this.id_adherent, this.id_panierGlobal) = (status, semaine, id_adh, id_panierGlo);

        public PanierAdherent_DAL(int id, bool status, int semaine, int id_adh, int id_panierGlo) => (this.ID, this.status, this.semaine, this.id_adherent, this.id_panierGlobal) = (id ,status, semaine, id_adh, id_panierGlo);

        internal void insert(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO panier_adherent(status, semaine, id_adherent, id_panierglobal) values (@status, @semaine, @id_adh, @id_panierGlo)";

                command.Parameters.Add(new SqlParameter("@status", status));
                command.Parameters.Add(new SqlParameter("@semaine", semaine));
                command.Parameters.Add(new SqlParameter("@id_adh", id_adherent));
                command.Parameters.Add(new SqlParameter("@id_panierGlo", id_panierGlobal));

                command.ExecuteNonQuery();
            }
        }
    }
}
