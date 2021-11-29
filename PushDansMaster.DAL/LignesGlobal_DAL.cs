using System.Data.SqlClient;


namespace PushDansMaster.DAL
{
    public class LignesGlobal_DAL
    {
        private int ID;
        private int id_panier;
        private int quantite;
        private string reference;
        private int id_reference;

        #region Getters / Setters
        public int getID
        {
            get { return ID; }
            private set { ID = value; }
        }
        public int getId_panier
        {
            get { return id_panier; }
            private set { id_panier = value; }
        }
        public int getQuantite
        {
            get { return quantite; }
            private set { quantite = value; }
        }
        public int getId_reference
        {
            get { return id_reference; }
            private set { id_reference = value; }
        }
        public string getReference
        {
            get { return reference; }
            private set { reference = value; }
        }

        #endregion

        #region Constructeurs
        public LignesGlobal_DAL(int id_panier, int quantite, string reference, int id_reference) => (this.id_panier, this.quantite, this.reference, this.id_reference) = (id_panier, quantite, reference, id_reference);
        public LignesGlobal_DAL(int ID, int id_panier, int quantite, string reference, int id_reference) => (this.ID, this.id_panier, this.quantite, this.reference, this.id_reference) = (ID, id_panier, quantite, reference, id_reference);
        #endregion

        #region Methodes
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
        #endregion
    }
}
