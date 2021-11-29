using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class Prix_DAL
    {
        private int prix;
        private int idFournisseur;
        private int idLignesGlobal;

        #region Getters / Setters
        public int getPrix
        {
            get { return prix; }
            private set { prix = value; }
        }
        public int getIDFournisseur
        {
            get { return idFournisseur; }
            private set { idFournisseur = value; }
        }
        public int getIDLignesGlobal
        {
            get { return idLignesGlobal; }
            private set { idLignesGlobal = value; }
        }
        #endregion

        #region Constructeur
        public Prix_DAL(int Prix, int IdFournisseur, int IdLignesGlobal) => (prix, idFournisseur, idLignesGlobal) = (Prix, IdFournisseur, IdLignesGlobal);
        #endregion

        #region Methodes
        internal void insert(SqlConnection connection)
        {
            // On insert un point dans la BDD
            using (var command = new SqlCommand())
            {
                // Définir la connexion à utiliser
                command.Connection = connection;
                command.CommandText = "INSERT INTO Prix(prix, id_fournisseur, id_lignesglobal) values (@prix, @id_fournisseur, @id_lignesglobal";

                command.Parameters.Add(new SqlParameter("@prix", prix));
                command.Parameters.Add(new SqlParameter("@id_fournisseur", idFournisseur));
                command.Parameters.Add(new SqlParameter("@id_lignesglobal", idLignesGlobal));

                command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
