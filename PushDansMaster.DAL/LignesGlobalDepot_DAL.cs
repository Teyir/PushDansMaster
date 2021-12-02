using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class LignesGlobalDepot_DAL : Depot_DAL<LignesGlobal_DAL>
    {
        public override List<LignesGlobal_DAL> getAll()
        {
            createConnection();

            command.CommandText = "SELECT id, id_panier, quantite, reference, id_reference FROM lignes_global";
            var reader = command.ExecuteReader();

            var listeDeLignes = new List<LignesGlobal_DAL>();

            while (reader.Read())
            {
                var p = new LignesGlobal_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetString(3),
                                        reader.GetInt32(4));

                listeDeLignes.Add(p);
            }

            closeConnection();

            return listeDeLignes;
        }

        public override LignesGlobal_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "SELECT id, id_panier, quantite, reference, id_reference FROM lignes_global WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = command.ExecuteReader();

            var listeDePoints = new List<LignesGlobal_DAL>();

            LignesGlobal_DAL p;
            if (reader.Read())
            {
                p = new LignesGlobal_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetString(3),
                                        reader.GetInt32(4));
            }
            else
                throw new Exception($"Pas de ligne globale dans la BDD avec l'ID {ID}");

            closeConnection();

            return p;
        }

        public override LignesGlobal_DAL insert(LignesGlobal_DAL ligne)
        {
            createConnection();

            command.CommandText = "INSERT INTO lignes_global(id_panier, quantite, reference, id_reference)"
                                    + " VALUES (@id_panier, @quantite, @reference, @id_reference); SELECT scope_identity()";
            command.Parameters.Add(new SqlParameter("@id_panier", ligne.getId_panier));
            command.Parameters.Add(new SqlParameter("@quantite", ligne.getQuantite));
            command.Parameters.Add(new SqlParameter("@reference", ligne.getReference));
            command.Parameters.Add(new SqlParameter("@id_reference", ligne.getId_reference));

            





            closeConnection();

            return ligne;
        }

        public override LignesGlobal_DAL update(LignesGlobal_DAL ligne)
        {
            createConnection();

            command.CommandText = "UPDATE lignes_global SET id_panier=@id_panier, quantite=@quantite, reference=@reference, id_reference=@id_reference"
                                   + " WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ligne.getID));
            command.Parameters.Add(new SqlParameter("@id_panier", ligne.getId_panier));
            command.Parameters.Add(new SqlParameter("@quantite", ligne.getQuantite));
            command.Parameters.Add(new SqlParameter("@reference", ligne.getReference));
            command.Parameters.Add(new SqlParameter("@id_reference", ligne.getId_reference));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de mettre à jour la ligne globale d'ID : {ligne.getID}");

            closeConnection();

            return ligne;
        }

        public override void delete(LignesGlobal_DAL ligne)
        {
            createConnection();

            command.CommandText = "DELETE * from lignes_global WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ligne.getID));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de supprimer la ligne globale d'ID {ligne.getID}");

            closeConnection();
        }

        public override void deleteByID(int ID)
        {
            createConnection();

            command.CommandText = "DELETE * FROM lignes_global WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));

            var linesAffected = (int)command.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer le lignes_global {ID}");
            }

            closeConnection();

        }
    }
}
