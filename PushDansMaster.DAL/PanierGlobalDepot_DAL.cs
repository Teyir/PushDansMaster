using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class PanierGlobalDepot_DAL : Depot_DAL<PanierGlobal_DAL>
    {
        public override List<PanierGlobal_DAL> getAll()
        {
            createConnection(); 

            command.CommandText = "SELECT id, status, semaine FROM panier_global";
            var reader = command.ExecuteReader();

            var listeDePaniers = new List<PanierGlobal_DAL>();

            while (reader.Read())
            {
                var p = new PanierGlobal_DAL(reader.GetInt32(0),
                                        reader.GetBoolean(1),
                                        reader.GetInt32(2));

                listeDePaniers.Add(p);
            }

            closeConnection();

            return listeDePaniers;
        }

        public override PanierGlobal_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "SELECT id, status, semaine FROM panier_global WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = command.ExecuteReader();

            var listeDePanier = new List<PanierGlobal_DAL>();

            PanierGlobal_DAL p;
            if (reader.Read())
            {
                p = new PanierGlobal_DAL(reader.GetInt32(0),
                                        reader.GetBoolean(1),
                                        reader.GetInt32(2));
            }
            else
                throw new Exception($"Pas de PanierGlobal dans la BDD avec l'ID {ID}");

            closeConnection();

            return p;
        }

        public override PanierGlobal_DAL insert(PanierGlobal_DAL panier)
        {
            createConnection();

            command.CommandText = "INSERT INTO panier_global(status, semaine)"
                                    + " VALUES (@status, @semaine); SELECT scope_identity()";
            command.Parameters.Add(new SqlParameter("@status", panier.getStatus));
            command.Parameters.Add(new SqlParameter("@semaine", panier.getSemaine));

            var ID = Convert.ToInt32((decimal)command.ExecuteScalar());

            panier.ID = ID;

            closeConnection();

            return panier;
        }

        public override PanierGlobal_DAL update(PanierGlobal_DAL panier)
        {
            createConnection();

            command.CommandText = "UPDATE panier_global SET status=@status, semaine=@semaine"
                                   + " WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", panier.getID));
            command.Parameters.Add(new SqlParameter("@status", panier.getStatus));
            command.Parameters.Add(new SqlParameter("@semaine", panier.getSemaine));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de mettre à jour le PanierGlobal d'ID : {panier.getID}");

            closeConnection();

            return panier;
        }

        public override void delete(PanierGlobal_DAL panier)
        {
            createConnection();

            command.CommandText = "DELETE * FROM panier_global WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", panier.getID));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de supprimer le PanierGlobal d'ID {panier.getID}");

            closeConnection();
        }

        public override void deleteByID(int ID)
        {
            createConnection();

            command.CommandText = "DELETE * FROM panier_global WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));

            var linesAffected = (int)command.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer le panier_global {ID}");
            }

            closeConnection();

        }
    }
}