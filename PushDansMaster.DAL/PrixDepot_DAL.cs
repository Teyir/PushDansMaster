using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class PrixDepot_DAL : Depot_DAL<Prix_DAL>
    {
        public override List<Prix_DAL> getAll()
        {
            createConnection();

            command.CommandText = "SELECT prix, id_fournisseur, id_lignesglobal FROM prix";
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

            command.CommandText = "SELECT prix, id_fournisseur, id_lignesglobal FROM prix WHERE CONCAT(id_fournisseur, id_lignesglobal)=@ID";
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

            command.CommandText = "INSERT INTO prix(prix, id_fournisseur, id_lignesglobal)"
                                    + " VALUES (@prix, @id_fournisseur, @id_lignesglobal); SELECT scope_identity()";
            command.Parameters.Add(new SqlParameter("@prix", prix.getPrix));
            command.Parameters.Add(new SqlParameter("@id_fournisseur", prix.getIDFournisseur));
            command.Parameters.Add(new SqlParameter("@id_lignesglobal", prix.getIDLignesGlobal));

            closeConnection();

            return prix;
        }

        public override Prix_DAL update(Prix_DAL prix)
        {
            createConnection();

            command.CommandText = "UPDATE prix SET prix=@prix, id_fournisseur=@IDfournisseur, id_lignesglobal=@IDlignesglo)"
                                   + " WHERE id_fournisseur=@IDfournisseur AND id_lignesglobal=@IDlignesglo";
            command.Parameters.Add(new SqlParameter("@prix", prix.getPrix));
            command.Parameters.Add(new SqlParameter("@IDfournisseur", prix.getIDFournisseur));
            command.Parameters.Add(new SqlParameter("@IDlignesglo", prix.getIDLignesGlobal));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                int prixException = int.Parse(prix.getIDFournisseur.ToString() + prix.getIDLignesGlobal.ToString());
                throw new Exception($"Impossible de mettre à jour le prix d'ID : {prixException}");
            }

            closeConnection();

            return prix;
        }

        public override void delete(Prix_DAL prix)
        {
            createConnection();

            command.CommandText = "DELETE * FROM prix WHERE id_fournisseur=@IDfournisseur AND id_lignesglobal=@IDlignesglo";
            command.Parameters.Add(new SqlParameter("@IDfournisseur", prix.getIDFournisseur));
            command.Parameters.Add(new SqlParameter("@IDlignesglo", prix.getIDLignesGlobal));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                int prixException = int.Parse(prix.getIDFournisseur.ToString() + prix.getIDLignesGlobal.ToString());
                throw new Exception($"Impossible de supprimer le prix d'ID {prixException}");
            }

            closeConnection();
        }
    }
}
