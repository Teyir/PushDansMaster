using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class PanierAdherent_DAL
    {
        public int ID;
        private int status;
        private int semaine;
        private int id_adherent;
        private int id_panierGlobal;

        #region Getters / Setters
        public int getID
        {
            get => ID;
            private set => ID = value;
        }
        public int getStatus
        {
            get => status;
            private set => status = value;
        }
        public int getSemaine
        {
            get => semaine;
            private set => semaine = value;
        }
        public int getId_adherent
        {
            get => id_adherent;
            private set => id_adherent = value;
        }
        public int getId_panierGlobal
        {
            get => id_panierGlobal;
            private set => id_panierGlobal = value;
        }

        #endregion

        #region Constructeurs
        public PanierAdherent_DAL(int status, int semaine, int id_adh, int id_panierGlo)
        {
            (this.status, this.semaine, id_adherent, id_panierGlobal) = (status, semaine, id_adh, id_panierGlo);
        }

        public PanierAdherent_DAL(int id, int status, int semaine, int id_adh, int id_panierGlo)
        {
            (ID, this.status, this.semaine, id_adherent, id_panierGlobal) = (id, status, semaine, id_adh, id_panierGlo);
        }
        #endregion

        #region Methodes
        internal void insert(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO panier_adherent(status, semaine, id_adherent, id_panierglobal) values (@status, @semaine, @id_adh, @id_panierGlo)";

                command.Parameters.Add(new SqlParameter("@status", status));
                command.Parameters.Add(new SqlParameter("@semaine", semaine));
                command.Parameters.Add(new SqlParameter("@id_adh", id_adherent));
                command.Parameters.Add(new SqlParameter("@id_panierGlo", id_panierGlobal));

                command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
