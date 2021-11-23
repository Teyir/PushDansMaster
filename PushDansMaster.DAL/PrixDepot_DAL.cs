using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    class PrixDepot_DAL : Depot_DAL<Prix_DAL>
    {
        public override List<Prix_DAL> getAll()
        {
            createConnection();

            command.CommandText = "select prix, id_fournisseur, id_lignesglobal from prix";
            var reader = command.ExecuteReader();

            var listeDePrix = new List<Prix_DAL>();

            while (reader.Read())
            {
                var p = new Prix_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2));

                listeDePrix.Add(p);
            }

            closeConnection();

            return listeDePrix;
        }

        public override Prix_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "select prix, id_fournisseur, id_lignesglobal from prix where CONCAT(id_fournisseur, id_lignesglobal)=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = command.ExecuteReader();

            var listeDePoints = new List<Prix_DAL>();

            Prix_DAL p;
            if (reader.Read())
            {
                p = new Prix_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2));
            }
            else
                throw new Exception($"Pas de prix dans la BDD avec l'ID {ID}");

            closeConnection();

            return p;
        }

        public override Prix_DAL insert(Prix_DAL prix)
        {
            createConnection();

            command.CommandText = "insert into prix(prix, id_fournisseur, id_lignesglobal)"
                                    + " values (@prix, @id_fournisseur, @id_lignesglobal); select scope_identity()";
            command.Parameters.Add(new SqlParameter("@prix", prix.prix));
            command.Parameters.Add(new SqlParameter("@id_fournisseur", prix.idFournisseur));
            command.Parameters.Add(new SqlParameter("@id_lignesglobal", prix.idLignesGlobal));

            closeConnection();

            return prix;
        }

        public override Prix_DAL update(Prix_DAL prix)
        {
            createConnection();

            command.CommandText = "update Prix set prix=@prix, id_fournisseur=@IDfournisseur, id_lignesglobal=@IDlignesglo)"
                                   + " where id_fournisseur = @IDfournisseur and id_lignesglobal = @IDlignesglo";
            command.Parameters.Add(new SqlParameter("@prix", prix.prix));
            command.Parameters.Add(new SqlParameter("@IDfournisseur", prix.idFournisseur));
            command.Parameters.Add(new SqlParameter("@IDlignesglo", prix.idLignesGlobal));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                int prixException = int.Parse(prix.idFournisseur.ToString() + prix.idLignesGlobal.ToString());
                throw new Exception($"Impossible de mettre à jour le prix d'ID : {prixException}");
            }

            closeConnection();

            return prix;
        }

        public override void delete(Prix_DAL prix)
        {
            createConnection();

            command.CommandText = "delete from Prix where id_fournisseur = @IDfournisseur and id_lignesglobal = @IDlignesglo";
            command.Parameters.Add(new SqlParameter("@IDfournisseur", prix.idFournisseur));
            command.Parameters.Add(new SqlParameter("@IDlignesglo", prix.idLignesGlobal));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                int prixException = int.Parse(prix.idFournisseur.ToString() + prix.idLignesGlobal.ToString());
                throw new Exception($"Impossible de supprimer le prix d'ID {prixException}");
            }

            closeConnection();
        }
    }
}
