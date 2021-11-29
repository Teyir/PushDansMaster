using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DAL
{
    public class LignesAdherent_DAL
    {
        public int ID { get; }
        public int quantiteAdherent { get; set; }
        public int idReference { get; set; }
        public int idPanier { get; set; }
        public LignesAdherent_DAL(int quantite, int id_reference, int id_panier)
           => (quantiteAdherent, idReference, idPanier)
           = (quantite, id_reference, id_panier);

        public LignesAdherent_DAL(int id, int quantite, int id_reference, int id_panier)
            => (ID, quantiteAdherent, idReference, idPanier)
            = (id, quantite, id_reference, id_panier);

        internal void addLignesAdherent(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO lignes_adherent(quantiteAdherent, idReference, idPanier) values (@quantiteAdherent, @idReference, @idPanier)";

                command.Parameters.Add(new SqlParameter("@quantiteAdherent", quantiteAdherent));
                command.Parameters.Add(new SqlParameter("@idReference", idReference));
                command.Parameters.Add(new SqlParameter("@idPanier", idPanier));

                command.ExecuteNonQuery();
            }

        }
    }
}
