using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    class PanierAdherentDepot_DAL : Depot_DAL<PanierAdherent_DAL>
    {
        public override List<PanierAdherent_DAL> getAll()
        {
            createConnection();

            command.CommandText = "select id, status, semaine, id_adherent, id_panierglobal from panier_adherent";
            var reader = command.ExecuteReader();

            var listeDePaniers = new List<PanierAdherent_DAL>();

            while (reader.Read())
            {
                var p = new PanierAdherent_DAL(reader.GetBoolean(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3));

                listeDePaniers.Add(p);
            }

            closeConnection();

            return listeDePaniers;
        }

        public override PanierAdherent_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "select status, semaine, id_adherent, id_panierglobal from panier_global where id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = command.ExecuteReader();

            var listeDePoints = new List<PanierAdherent_DAL>();

            PanierAdherent_DAL p;
            if (reader.Read())
            {
                p = new PanierAdherent_DAL(reader.GetBoolean(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3));
            }
            else
                throw new Exception($"Pas de PanierAdherent dans la BDD avec l'ID {ID}");

            closeConnection();

            return p;
        }

        public override PanierAdherent_DAL insert(PanierAdherent_DAL panier)
        {
            createConnection();

            command.CommandText = "insert into panier_adherent(status, semaine, id_adherent, id_panierglobal)"
                                    + " values (@status, @semaine, @id_adherent, @id_panierglobal); select scope_identity()";
            command.Parameters.Add(new SqlParameter("@status", panier.status));
            command.Parameters.Add(new SqlParameter("@semaine", panier.semaine));
            command.Parameters.Add(new SqlParameter("@id_adherent", panier.id_adherent));
            command.Parameters.Add(new SqlParameter("@id_panierglobal", panier.id_panierGlobal));

            closeConnection();

            return panier;
        }

        public override PanierAdherent_DAL update(PanierAdherent_DAL panier)
        {
            createConnection();

            command.CommandText = "update panier_adherent set status=@status, semaine=@semaine, id_adherent=@id_adherent, id_panierglobal=@id_panierglobal"
                                   + " where id = @ID";
            command.Parameters.Add(new SqlParameter("@status", panier.status));
            command.Parameters.Add(new SqlParameter("@semaine", panier.semaine));
            command.Parameters.Add(new SqlParameter("@id_adherent", panier.id_adherent));
            command.Parameters.Add(new SqlParameter("@id_panierglobal", panier.id_panierGlobal));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de mettre à jour le PanierAdherent d'ID : {panier.ID}");

            closeConnection();

            return panier;
        }

        public override void delete(PanierAdherent_DAL panier)
        {
            createConnection();

            command.CommandText = "delete from panier_adherent where id = @ID";
            command.Parameters.Add(new SqlParameter("@ID", panier.ID));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de supprimer le PanierAdherent d'ID {panier.ID}");

            closeConnection();
        }
    }
}
