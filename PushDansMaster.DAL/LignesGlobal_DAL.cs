using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DAL
{
    class LignesGlobal_DAL
    {
        public int ID { get; }
        public int id_panier { get; private set; }
        public int quantite { get; private set; }
        public string reference { get; private set; }
        public int id_reference { get; private set; }

        public LignesGlobal_DAL(int id_panier, int quantite, string reference, int id_reference) => (this.id_panier, this.quantite, this.reference, this.id_reference) = (id_panier, quantite, reference, id_reference);
        public LignesGlobal_DAL(int ID, int id_panier, int quantite, string reference, int id_reference) => (this.ID, this.id_panier, this.quantite, this.reference, this.id_reference) = (ID, id_panier, quantite, reference, id_reference);

        internal void insert(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO lignes_global(id_panier, quantite, reference, id_reference) values (@id_panier, @quantite, @reference, @id_reference)";

                command.Parameters.Add(new SqlParameter("@id_panier", id_panier));
                command.Parameters.Add(new SqlParameter("@quantite", quantite));
                command.Parameters.Add(new SqlParameter("@reference", reference));
                command.Parameters.Add(new SqlParameter("@id_reference", id_reference));

                command.ExecuteNonQuery();
            }
        }
    }
}
