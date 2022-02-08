using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class LignesAdherentDepot_DAL : Depot_DAL<LignesAdherent_DAL>
    {
        public override List<LignesAdherent_DAL> getAll()
        {
            createConnection();

            command.CommandText = "SELECT id, quantite, id_reference, id_panier FROM lignes_adherent";
            SqlDataReader reader = command.ExecuteReader();

            List<LignesAdherent_DAL> listeLignes = new List<LignesAdherent_DAL>();

            while (reader.Read())
            {
                LignesAdherent_DAL l = new LignesAdherent_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3));

                listeLignes.Add(l);
            }

            closeConnection();

            return listeLignes;
        }

        public override LignesAdherent_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "SELECT id, quantite, id_reference, id_panier FROM lignes_adherent WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));
            SqlDataReader reader = command.ExecuteReader();

            List<LignesAdherent_DAL> listeDeLignes = new List<LignesAdherent_DAL>();

            LignesAdherent_DAL l;
            if (reader.Read())
            {
                l = new LignesAdherent_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3));
            }
            else
            {
                throw new Exception($"Pas de LignesAdherent dans la BDD avec l'ID {ID}");
            }

            closeConnection();

            return l;
        }

        public override LignesAdherent_DAL insert(LignesAdherent_DAL ligne)
        {
            createConnection();

            command.CommandText = "INSERT INTO lignes_adherent(quantite, id_reference, id_panier)"
                                    + " VALUES (@quantite, @id_reference, @id_panier); SELECT scope_identity()";
            command.Parameters.Add(new SqlParameter("@quantite", ligne.getQuantiteAdherent));
            command.Parameters.Add(new SqlParameter("@id_reference", ligne.getIdReference));
            command.Parameters.Add(new SqlParameter("@id_panier", ligne.getIdPanier));

            int ID = Convert.ToInt32((decimal)command.ExecuteScalar());

            ligne.ID = ID;

            closeConnection();

            return ligne;
        }

        public override LignesAdherent_DAL update(LignesAdherent_DAL ligne)
        {
            createConnection();

            command.CommandText = "UPDATE lignes_adherent SET quantite=@quantite, id_reference=@id_reference, id_panier=@id_panier"
                                   + " WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ligne.getID));
            command.Parameters.Add(new SqlParameter("@quantite", ligne.getQuantiteAdherent));
            command.Parameters.Add(new SqlParameter("@id_reference", ligne.getIdReference));
            command.Parameters.Add(new SqlParameter("@id_panier", ligne.getIdPanier));
            int nombreDeLignesAffectees = command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la lignesAdherent d'ID : {ligne.getID}");
            }

            closeConnection();

            return ligne;
        }

        public override void delete(LignesAdherent_DAL ligne)
        {
            createConnection();

            command.CommandText = "DELETE * from lignes_adherent where id = @ID";
            command.Parameters.Add(new SqlParameter("@ID", ligne.getID));
            int nombreDeLignesAffectees = command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer la lignesAdherent d'ID {ligne.getID}");
            }

            closeConnection();
        }

        public override void deleteByID(int ID)
        {
            createConnection();

            command.CommandText = "DELETE * FROM lignes_adherent WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));

            int linesAffected = command.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer la ligne_adherent {ID}");
            }

            closeConnection();

        }

    }
}
