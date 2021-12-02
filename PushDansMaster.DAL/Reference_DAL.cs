using System.Data.SqlClient;


namespace PushDansMaster.DAL
{
    public class Reference_DAL
    {
        private int ID;
        private string ref_libelle;
        private string ref_reference;
        private string ref_marque;
        private int ref_quantite;

        #region Getters / Setters
        public int getID
        {
            get { return ID; }
            private set { ID = value; }
        }
        public string getLibelle
        {
            get { return ref_libelle; }
            private set { ref_libelle = value; }
        }
        public string getReference
        {
            get { return ref_reference; }
            private set { ref_reference = value; }
        }
        public string getMarque
        {
            get { return ref_marque; }
            private set { ref_marque = value; }
        }
        public int getQuantite
        {
            get { return ref_quantite; }
            private set { ref_quantite = value; }
        }
        #endregion

        #region Constructeurs
        public Reference_DAL(string libelle, string reference, string marque, int quantite)
        => (ref_libelle, ref_reference, ref_marque, ref_quantite)
        = (libelle, reference, marque, quantite);
        public Reference_DAL(int id, string libelle, string reference, string marque, int quantite)
        => (ID, ref_libelle, ref_reference, ref_marque, ref_quantite)
        = (id, libelle, reference, marque, quantite);
        #endregion

        #region Methodes
        internal void Insert(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "insert into reference(libelle, reference, marque, quantite"
                        + " values (@libelle, @reference, @marque, @quantite";
                command.Parameters.Add(new SqlParameter("@libelle", ref_libelle));
                command.Parameters.Add(new SqlParameter("@reference", ref_reference));
                command.Parameters.Add(new SqlParameter("@marque", ref_marque));
                command.Parameters.Add(new SqlParameter("@quantite", ref_quantite));

                command.ExecuteNonQuery();

                connection.Close();

            }
        }
        #endregion
    }
}
