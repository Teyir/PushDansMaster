using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    class PanierGlobalDepot_DAL : Depot_DAL<PanierGlobal_DAL>
    {
        public override List<PanierGlobal_DAL> getAll()
        {
            createConnection();

            command.CommandText = "select id, status, semaine from panier_global";
            var reader = command.ExecuteReader();

            var listeDePaniers = new List<PanierGlobal_DAL>();

            while (reader.Read())
            {
                var p = new PanierGlobal_DAL(reader.GetBoolean(0),
                                        reader.GetInt32(0));

                listeDePaniers.Add(p);
            }

            closeConnection();

            return listeDePaniers;
        }

        public override PanierGlobal_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "select status, semaine from panier_global where id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = command.ExecuteReader();

            var listeDePoints = new List<PanierGlobal_DAL>();

            PanierGlobal_DAL p;
            if (reader.Read())
            {
                p = new PanierGlobal_DAL(reader.GetBoolean(0),
                                        reader.GetInt32(0));
            }
            else
                throw new Exception($"Pas de prix dans la BDD avec l'ID {ID}");

            closeConnection();

            return p;
        }

        public override PanierGlobal_DAL insert(PanierGlobal_DAL panier)
        {
            createConnection();

            command.CommandText = "insert into panier_global(status, semaine)"
                                    + " values (@status, @semaine); select scope_identity()";
            command.Parameters.Add(new SqlParameter("@status", panier.status));
            command.Parameters.Add(new SqlParameter("@semaine", panier.semaine));

            closeConnection();

            return panier;
        }

        public override PanierGlobal_DAL update(PanierGlobal_DAL panier)
        {
            createConnection();

            command.CommandText = "update panier_global set status=@status, semaine=@semaine"
                                   + " where id = @ID";
            command.Parameters.Add(new SqlParameter("@status", panier.status));
            command.Parameters.Add(new SqlParameter("@semaine", panier.semaine));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de mettre à jour le prix d'ID : {panier.ID}");

            closeConnection();

            return panier;
        }

        public override void delete(PanierGlobal_DAL panier)
        {
            createConnection();

            command.CommandText = "delete from panier where id = @ID";
            command.Parameters.Add(new SqlParameter("@ID", panier.ID));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de supprimer le prix d'ID {panier.ID}");

            closeConnection();
        }
    }
}