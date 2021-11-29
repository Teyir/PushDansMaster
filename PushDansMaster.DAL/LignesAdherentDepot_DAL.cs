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

            command.CommandText = "select id, quantite, id_reference, id_panier from lignes_adherent";
            var reader = command.ExecuteReader();

            var listeLignes = new List<LignesAdherent_DAL>();

            while (reader.Read())
            {
                var l = new LignesAdherent_DAL(reader.GetInt32(0), 
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

            command.CommandText = "select id, quantite, id_reference, id_panier from lignes_adherent where id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = command.ExecuteReader();

            var listeDeLignes = new List<LignesAdherent_DAL>();

            LignesAdherent_DAL l;
            if (reader.Read())
            {
                l = new LignesAdherent_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3));
            }
            else
                throw new Exception($"Pas de LignesAdherent dans la BDD avec l'ID {ID}");

            closeConnection();

            return l;
        }

        public override LignesAdherent_DAL insert(LignesAdherent_DAL ligne)
        {
            createConnection();

            command.CommandText = "insert into lignes_adherent(quantite, id_reference, id_panier)"
                                    + " values (@quantite, @id_reference, @id_panier); select scope_identity()";
            command.Parameters.Add(new SqlParameter("@quantite", ligne.quantiteAdherent));
            command.Parameters.Add(new SqlParameter("@id_reference", ligne.idReference));
            command.Parameters.Add(new SqlParameter("@id_panier", ligne.idPanier));

            closeConnection();

            return ligne;
        }

        public override LignesAdherent_DAL update(LignesAdherent_DAL ligne)
        {
            createConnection();

            command.CommandText = "update lignes_adherent set quantite=@quantite, id_reference=@id_reference, id_panier=@id_panier"
                                   + " where id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ligne.ID));
            command.Parameters.Add(new SqlParameter("@quantite", ligne.quantiteAdherent));
            command.Parameters.Add(new SqlParameter("@id_reference", ligne.idReference));
            command.Parameters.Add(new SqlParameter("@id_panier", ligne.idPanier));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de mettre à jour la lignesAdherent d'ID : {ligne.ID}");

            closeConnection();

            return ligne;
        }

        public override void delete(LignesAdherent_DAL ligne)
        {
            createConnection();

            command.CommandText = "delete from lignes_adherent where id = @ID";
            command.Parameters.Add(new SqlParameter("@ID", ligne.ID));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
                throw new Exception($"Impossible de supprimer la lignesAdherent d'ID {ligne.ID}");

            closeConnection();
        }

    }
}
