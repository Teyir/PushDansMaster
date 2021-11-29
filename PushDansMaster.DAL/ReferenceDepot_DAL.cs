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

            command.CommandText = "select id, libelle, reference, marque, quantite from reference";
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

            command.CommandText = "select id, libelle, reference, marque, quantite from reference where id=@ID";
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
                throw new Exception($"Pas de Reference dans la BDD avec l'ID {ID}");

            closeConnection();

            return r;
        }

        public override Reference_DAL insert(Reference_DAL item)
        {
            createConnection();

            command.CommandText = "insert into reference(libelle, reference, marque, quantite)"
                                    + " values (@libelle, @reference, @marque, @quantite); select scope_identity()";
            command.Parameters.Add(new SqlParameter("@libelle", item.ref_libelle));
            command.Parameters.Add(new SqlParameter("@reference", item.ref_reference));
            command.Parameters.Add(new SqlParameter("@marque", item.ref_marque));
            command.Parameters.Add(new SqlParameter("@quantite", item.ref_quantite));

            closeConnection();

            return item;
        }

        public override Reference_DAL update(Reference_DAL item)
        {
            createConnection();

            command.CommandText = "update reference set libelle=@libelle, reference=@reference, marque=@marque, quantite=@quantite"
                                   + " where id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", item.ID));
            command.Parameters.Add(new SqlParameter("@libelle", item.ref_libelle));
            command.Parameters.Add(new SqlParameter("@reference", item.ref_reference));
            command.Parameters.Add(new SqlParameter("@marque", item.ref_marque));
            command.Parameters.Add(new SqlParameter("@quantite", item.ref_quantite));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de mettre à jour la reference d'ID : {item.ID}");

            closeConnection();

            return item;
        }
        public override void delete(Reference_DAL item)
        {
            createConnection();

            command.CommandText = "delete from reference where id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", item.ID));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de supprimer la reference d'ID {item.ID}");

            closeConnection();
        }
    }
}
