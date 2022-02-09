namespace PushDansMaster
{
    public class PanierGlobal
    {
        private int ID;
        private int status;
        private int semaine;

        #region Getters / Setters

        /// <summary>
        /// Permet d'obtenir le status
        /// </summary>
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

        public int getID
        {
            get => ID;
            private set => ID = value;
        }
        #endregion

        #region Constructeurs

        public PanierGlobal(int status, int semaine)
        {
            this.status = status;
            this.semaine = semaine;
        }

        public PanierGlobal(int id, int status, int semaine)
            : this(status, semaine)
        {
            ID = id;
        }

        public PanierGlobal()
        {

        }

        #endregion
    }
}