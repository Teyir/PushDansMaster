namespace PushDansMaster
{
    public class PanierAdherent
    {
        private int ID;
        private bool status;
        private int semaine;
        private int id_adherent;
        private int id_panierGlobal;

        #region Getters / Setters

        /// <summary>
        /// Permet d'obtenir le status
        /// </summary>
        public bool getStatus
        {
            get { return status; }
            private set { status = value; }
        }

        public int getSemaine
        {
            get { return semaine; }
            private set { semaine = value; }
        }

        public int getID
        {
            get { return ID; }
            private set { ID = value; }
        }

        public int getID_adherent
        {
            get { return id_adherent; }
            private set { id_adherent = value; }
        }

        public int getID_panierGlobal
        {
            get { return id_panierGlobal; }
            private set { id_panierGlobal = value; }
        }
        #endregion

        #region Constructeurs

        public PanierAdherent(bool status, int semaine, int id_adherent, int id_panierGlobal)
        {
            this.status = status;
            this.semaine = semaine;
            this.id_adherent = id_adherent;
            this.id_panierGlobal = id_panierGlobal;
        }

        #endregion
    }
}
