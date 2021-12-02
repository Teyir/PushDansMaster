using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class ReferenceDepot_DAL : Depot_DAL<Reference_DAL>
    {
        
        public override List<Reference_DAL> getAll()
        {
            createConnection();

            command.CommandText = "SELECT id, libelle, reference, marque, quantite FROM reference";
            var reader = command.ExecuteReader();

            var references = new List<Reference_DAL>();
            while (reader.Read())
            {
                var r = new Reference_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3), 
                                        reader.GetInt32(4));

                references.Add(r);
            }

            closeConnection();

            return references;

        }

        public override Reference_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "SELECT id, libelle, reference, marque, quantite FROM reference WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = command.ExecuteReader();

            var listeDeReference = new List<Reference_DAL>();

            Reference_DAL r;
            if (reader.Read())
            {
                r = new Reference_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetInt32(4));
            }
            else
                throw new Exception($"Pas de reference dans la BDD avec l'ID {ID}");

            closeConnection();

            return r;
        }

        public override Reference_DAL insert(Reference_DAL item)
        {
            createConnection();

            command.CommandText = "INSERT INTO reference(libelle, reference, marque, quantite)"
                                    + " VALUES (@libelle, @reference, @marque, @quantite); SELECT scope_identity()";
            command.Parameters.Add(new SqlParameter("@libelle", item.getLibelle));
            command.Parameters.Add(new SqlParameter("@reference", item.getReference));
            command.Parameters.Add(new SqlParameter("@marque", item.getMarque));
            command.Parameters.Add(new SqlParameter("@quantite", item.getQuantite));

            var ID = Convert.ToInt32((decimal)command.ExecuteScalar());

            item.ID = ID;

            closeConnection();

            return item;
        }

        public override Reference_DAL update(Reference_DAL item)
        {
            createConnection();

            command.CommandText = "UPDATE reference SET libelle=@libelle, reference=@reference, marque=@marque, quantite=@quantite"
                                   + " WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", item.getID));
            command.Parameters.Add(new SqlParameter("@libelle", item.getLibelle));
            command.Parameters.Add(new SqlParameter("@reference", item.getReference));
            command.Parameters.Add(new SqlParameter("@marque", item.getMarque));
            command.Parameters.Add(new SqlParameter("@quantite", item.getQuantite));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de mettre à jour la reference d'ID : {item.getID}");

            closeConnection();

            return item;
        }
        public override void delete(Reference_DAL item)
        {
            createConnection();

            command.CommandText = "DELETE * from reference WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", item.getID));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de supprimer la reference d'ID {item.getID}");

            closeConnection();
        }

        public override void deleteByID(int ID)
        {
            createConnection();

            command.CommandText = "DELETE * FROM reference WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));

            var linesAffected = (int)command.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer le reference {ID}");
            }

            closeConnection();

        }
    }
}
