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
        public int IdLignes{ get; }

        public int quantiteAdherent { get; set; }

        public int idReference { get; set; }

        public int idPanier { get; set; }

        public LignesAdherent_DAL(int id, int quantite, int id_reference, int id_panier)
            => (IdLignes, quantiteAdherent, idReference, idPanier)
            = (id, quantite, id_reference, id_panier);

        internal void addLignesAdherent(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {

            }

    }
}
