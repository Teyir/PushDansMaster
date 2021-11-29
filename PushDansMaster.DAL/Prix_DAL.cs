using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    class Prix_DAL
    {
        public int prix { get; private set; }
        public int idFournisseur { get; private set; }
        public int idLignesGlobal { get; private set; }
        public Prix_DAL(int Prix, int IdFournisseur, int IdLignesGlobal) => (prix, idFournisseur, idLignesGlobal) = (Prix, IdFournisseur, IdLignesGlobal);

        internal void insert(SqlConnection connection)
        {
            // On insert un point dans la BDD
            using (var command = new SqlCommand())
            {
                // Définir la connexion à utiliser
                command.Connection = connection;
                command.CommandText = "INSERT INTO prix(prix, id_fournisseur, id_lignesglobal) values (@prix, @id_fournisseur, @id_lignesglobal";

                command.Parameters.Add(new SqlParameter("@prix", prix));
                command.Parameters.Add(new SqlParameter("@id_fournisseur", idFournisseur));
                command.Parameters.Add(new SqlParameter("@id_lignesglobal", idLignesGlobal));

                command.ExecuteNonQuery();
            }
        }
    }
}
