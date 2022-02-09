using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class PanierGlobal_DAL
    {
        public int ID;
        private int status;
        private int semaine;

        #region Getters / Setters
        public int getID
        {
            get => ID;
            private set => ID = value;
        }
        public int getSemaine
        {
            get => semaine;
            private set => semaine = value;
        }
        public int getStatus
        {
            get => status;
            private set => status = value;
        }

        #endregion

        #region Constructeurs
        public PanierGlobal_DAL(int status, int semaine)
        {
            (this.status, this.semaine) = (status, semaine);
        }

        public PanierGlobal_DAL(int id, int status, int semaine)
        {
            (ID, this.status, this.semaine) = (id, status, semaine);
        }
        #endregion


        #region Methodes
        internal void insert(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO panier_global(status, semaine) VALUES (@status, @semaine)";

                command.Parameters.Add(new SqlParameter("@status", status));
                command.Parameters.Add(new SqlParameter("@semaine", semaine));

                command.ExecuteNonQuery();
            }
        }
        #endregion 
    }
}