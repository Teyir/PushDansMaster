using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DAL
{
    class LignesGlobalDepot_DAL : Depot_DAL<LignesGlobal_DAL>
    {
        public override List<LignesGlobal_DAL> getAll()
        {
            createConnection();

            command.CommandText = "select id, id_panier, quantite, reference, id_reference from lignes_global";
            var reader = command.ExecuteReader();

            var listeDeLignes = new List<LignesGlobal_DAL>();

            while (reader.Read())
            {
                var p = new LignesGlobal_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetString(2),
                                        reader.GetInt32(3));

                listeDeLignes.Add(p);
            }

            closeConnection();

            return listeDeLignes;
        }

        public override LignesGlobal_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "select id_panier, quantite, reference, id_reference from lignes_global where id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = command.ExecuteReader();

            var listeDePoints = new List<LignesGlobal_DAL>();

            LignesGlobal_DAL p;
            if (reader.Read())
            {
                p = new LignesGlobal_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetString(2),
                                        reader.GetInt32(3));
            }
            else
                throw new Exception($"Pas de ligne globale dans la BDD avec l'ID {ID}");

            closeConnection();

            return p;
        }

        public override LignesGlobal_DAL insert(LignesGlobal_DAL ligne)
        {
            createConnection();

            command.CommandText = "insert into lignes_global(id_panier, quantite, reference, id_reference)"
                                    + " values (@id_panier, @quantite, @reference, @id_reference); select scope_identity()";
            command.Parameters.Add(new SqlParameter("@id_panier", ligne.id_panier));
            command.Parameters.Add(new SqlParameter("@quantite", ligne.quantite));
            command.Parameters.Add(new SqlParameter("@reference", ligne.reference));
            command.Parameters.Add(new SqlParameter("@id_reference", ligne.id_reference));

            closeConnection();

            return ligne;
        }

        public override LignesGlobal_DAL update(LignesGlobal_DAL ligne)
        {
            createConnection();

            command.CommandText = "update lignes_global set id_panier=@id_panier, quantite=@quantite, reference=@reference, id_reference=@id_reference"
                                   + " where id = @ID";
            command.Parameters.Add(new SqlParameter("@id_panier", ligne.id_panier));
            command.Parameters.Add(new SqlParameter("@quantite", ligne.quantite));
            command.Parameters.Add(new SqlParameter("@reference", ligne.reference));
            command.Parameters.Add(new SqlParameter("@id_reference", ligne.id_reference));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de mettre à jour la ligne globale d'ID : {ligne.ID}");

            closeConnection();

            return ligne;
        }

        public override void delete(LignesGlobal_DAL ligne)
        {
            createConnection();

            command.CommandText = "delete from lignes_global where id = @ID";
            command.Parameters.Add(new SqlParameter("@ID", ligne.ID));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de supprimer la ligne globale d'ID {ligne.ID}");

            closeConnection();
        }
    }
}
