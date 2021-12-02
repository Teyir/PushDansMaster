using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class LignesAdherent_DAL
    {
        private int ID;
        private int quantiteAdherent;
        private int idReference;
        private int idPanier;


        #region Getters / Setters
        public int getID
        {
            get { return ID; }
            private set { ID = value; }
        }
        public int getQuantiteAdherent
        {
            get { return quantiteAdherent; }
            private set { quantiteAdherent = value; }
        }
        public int getIdReference
        {
            get { return idReference; }
            private set { idReference = value; }
        }
        public int getIdPanier
        {
            get { return idPanier; }
            private set { idPanier = value; }
        }
        #endregion

        #region Constructeurs
        public LignesAdherent_DAL(int quantite, int id_reference, int id_panier)
           => (quantiteAdherent, idReference, idPanier)
           = (quantite, id_reference, id_panier);

        public LignesAdherent_DAL(int id, int quantite, int id_reference, int id_panier)
            => (ID, quantiteAdherent, idReference, idPanier)
            = (id, quantite, id_reference, id_panier);
        #endregion

        #region Methodes
        internal void addLignesAdherent(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO lignes_adherent(quantiteAdherent, idReference, idPanier) VALUES (@quantiteAdherent, @idReference, @idPanier)";

                command.Parameters.Add(new SqlParameter("@quantiteAdherent", quantiteAdherent));
                command.Parameters.Add(new SqlParameter("@idReference", idReference));
                command.Parameters.Add(new SqlParameter("@idPanier", idPanier));

                command.ExecuteNonQuery();
            }

        }
        #endregion
    }
}
