using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class PanierAdherentDepot_DAL : Depot_DAL<PanierAdherent_DAL>
    {
        public override List<PanierAdherent_DAL> getAll()
        {
            createConnection();

            command.CommandText = "SELECT id, status, semaine, id_adherent, id_panierglobal FROM panier_adherent";
            var reader = command.ExecuteReader();

            var listeDePaniers = new List<PanierAdherent_DAL>();

            while (reader.Read())
            {
                var p = new PanierAdherent_DAL(reader.GetInt32(0), 
                                        reader.GetBoolean(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4));

                listeDePaniers.Add(p);
            }

            closeConnection();

            return listeDePaniers;
        }

        public override PanierAdherent_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "SELECT id, status, semaine, id_adherent, id_panierglobal FROM panier_global WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = command.ExecuteReader();

            var listeDePoints = new List<PanierAdherent_DAL>();

            PanierAdherent_DAL p;
            if (reader.Read())
            {
                p = new PanierAdherent_DAL(reader.GetInt32(0), 
                                        reader.GetBoolean(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4));
            }
            else
                throw new Exception($"Pas de PanierAdherent dans la BDD avec l'ID {ID}");

            closeConnection();

            return p;
        }

        public override PanierAdherent_DAL insert(PanierAdherent_DAL panier)
        {
            createConnection();

            command.CommandText = "INSERT INTO panier_adherent(status, semaine, id_adherent, id_panierglobal)"
                                    + " VALUES (@status, @semaine, @id_adherent, @id_panierglobal); SELECT scope_identity()";
            command.Parameters.Add(new SqlParameter("@status", panier.getStatus));
            command.Parameters.Add(new SqlParameter("@semaine", panier.getSemaine));
            command.Parameters.Add(new SqlParameter("@id_adherent", panier.getId_adherent));
            command.Parameters.Add(new SqlParameter("@id_panierglobal", panier.getId_panierGlobal));

            var ID = Convert.ToInt32((decimal)command.ExecuteScalar());

            panier.ID = ID;

            closeConnection();

            return panier;
        }

        public override PanierAdherent_DAL update(PanierAdherent_DAL panier)
        {
            createConnection();

            command.CommandText = "UPDATE panier_adherent SET status=@status, semaine=@semaine, id_adherent=@id_adherent, id_panierglobal=@id_panierglobal"
                                   + " WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", panier.getID));
            command.Parameters.Add(new SqlParameter("@status", panier.getStatus));
            command.Parameters.Add(new SqlParameter("@semaine", panier.getSemaine));
            command.Parameters.Add(new SqlParameter("@id_adherent", panier.getId_adherent));
            command.Parameters.Add(new SqlParameter("@id_panierglobal", panier.getId_panierGlobal));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de mettre à jour le PanierAdherent d'ID : {panier.getID}");

            closeConnection();

            return panier;
        }

        public override void delete(PanierAdherent_DAL panier)
        {
            createConnection();

            command.CommandText = "DELETE * FROM panier_adherent where id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", panier.getID));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de supprimer le PanierAdherent d'ID {panier.getID}");

            closeConnection();
        }

        public override void deleteByID(int ID)
        {
            createConnection();

            command.CommandText = "DELETE * FROM panier_adherent WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));

            var linesAffected = (int)command.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer le panier_adherent {ID}");
            }

            closeConnection();

        }
    }
}
