using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class RefFournisseur_DAL
    {
        public int ID;
        public int id_fournisseur;
        public int id_reference;
        #region Getters / Setters 
        public int GetIDfournisseur
        {
            get { return id_fournisseur; }
            private set { id_fournisseur = value; }
        }

        public int GetIDreference
        {
            get { return id_reference; }
            private set { id_reference = value; }
        }
        #endregion
        #region Constructeur
        public RefFournisseur_DAL(int id_fournisseur, int id_reference) => (this.id_fournisseur, this.id_reference) = (id_fournisseur, id_reference);
        #endregion
        #region Méthodes
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
        #endregion
    }
}
