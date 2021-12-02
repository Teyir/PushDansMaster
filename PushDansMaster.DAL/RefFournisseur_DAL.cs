using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DAL
{
    class RefFournisseur_DAL
    {
        public int id_fournisseur { get; private set; }
        public int id_reference { get; private set; }
        public RefFournisseur_DAL(int id_fournisseur, int id_reference) => (this.id_fournisseur, this.id_reference) = (id_fournisseur, id_reference);

        internal void insert(SqlConnection connection)
        {
            // On insert un point dans la BDD
            using (var command = new SqlCommand())
            {
                // Définir la connexion à utiliser
                command.Connection = connection;
                command.CommandText = "INSERT INTO ref_fournisseur(id_fournisseur, id_reference) values (@id_fournisseur, @id_reference)";

                command.Parameters.Add(new SqlParameter("@id_fournisseur", id_fournisseur));
                command.Parameters.Add(new SqlParameter("@id_reference", id_reference));

                command.ExecuteNonQuery();
            }
        }
    }
}
