namespace PushDansMaster
{
    public class PanierAdherent
    {
        private int ID;
        private int status;
        private int semaine;
        private int id_adherent;
        private int id_panierGlobal;

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

        public int getID_adherent
        {
            get => id_adherent;
            private set => id_adherent = value;
        }

        public int getID_panierGlobal
        {
            get => id_panierGlobal;
            private set => id_panierGlobal = value;
        }
        #endregion

        #region Constructeurs

        public PanierAdherent(int status, int semaine, int id_adherent, int id_panierGlobal)
        {
            this.status = status;
            this.semaine = semaine;
            this.id_adherent = id_adherent;
            this.id_panierGlobal = id_panierGlobal;
        }

        public PanierAdherent(int id, int status, int semaine, int id_adherent, int id_panierGlobal)
            : this(status, semaine, id_adherent, id_panierGlobal)
        {
            ID = id;
        }



        public PanierAdherent()
        {
        }

        #endregion
    }
}
