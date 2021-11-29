using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class FournisseurDepot_DAL : Depot_DAL<Fournisseur_DAL>
    {

        public override List<Fournisseur_DAL> getAll()
        {
            createConnection();

            command.CommandText = "SELECT id,  societe, civilite, nom, prenom, email, adresse FROM fournisseur";
            var reader = command.ExecuteReader();

            var listFournisseur = new List<Fournisseur_DAL>();

            while (reader.Read())
            {
                var f = new Fournisseur_DAL(reader.GetInt32(0),
                                                reader.GetString(1),
                                                reader.GetBoolean(2),
                                                reader.GetString(3),
                                                reader.GetString(4),
                                                reader.GetString(5),
                                                reader.GetString(6));
                listFournisseur.Add(f);
            }

            closeConnection();

            return listFournisseur;
        }


        public override Fournisseur_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "SELECT id,  societe, civilite, nom, prenom, email, adresse FROM fournisseur WHERE id=@id";
            command.Parameters.Add(new SqlParameter("@id", ID));
            var reader = command.ExecuteReader();

            var listFournisseur = new List<Fournisseur_DAL>();

            Fournisseur_DAL f;
            if (reader.Read())
            {
                f = new Fournisseur_DAL(reader.GetInt32(0),
                                                reader.GetString(1),
                                                reader.GetBoolean(2),
                                                reader.GetString(3),
                                                reader.GetString(4),
                                                reader.GetString(5),
                                                reader.GetString(6));
            }
            else
                throw new Exception($"Pas de fournisseur avec l'ID {ID}");

             closeConnection();

            return f;
        }


        public override Fournisseur_DAL insert(Fournisseur_DAL fournisseur)
        {
            createConnection();

            command.CommandText = "INSERT INTO fournisseur(societe, civilite, nom, prenom, email, adresse)"
                                    + " VALUES (@societe, @civilite, @nom, @prenom, @email, @adresse); select scope_identity()";

            command.Parameters.Add(new SqlParameter("@societe", fournisseur.getSocieteFournisseur));
            command.Parameters.Add(new SqlParameter("@civilite", fournisseur.getCiviliteFournisseur));
            command.Parameters.Add(new SqlParameter("@nom", fournisseur.getNomFournisseur));
            command.Parameters.Add(new SqlParameter("@prenom", fournisseur.getPrenomFournisseur));
            command.Parameters.Add(new SqlParameter("@email", fournisseur.getEmailFournisseur));
            command.Parameters.Add(new SqlParameter("@adresse", fournisseur.getAdresseFournisseur));

            var ID = Convert.ToInt32((decimal)command.ExecuteScalar());


            closeConnection();

            return fournisseur;

        }

        public override Fournisseur_DAL update(Fournisseur_DAL fournisseur)
        {
            createConnection();

            command.CommandText = "UPDATE fournisseur set societe=@societe, civilite=@civilite, nom=@nom, prenom=@prenom, email=@email, adresse=@adresse"                     
                                    +  " WHERE id=@ID";

            command.Parameters.Add(new SqlParameter("@ID", fournisseur.getID));
            command.Parameters.Add(new SqlParameter("@societe", fournisseur.getSocieteFournisseur));
            command.Parameters.Add(new SqlParameter("@civilite", fournisseur.getCiviliteFournisseur));
            command.Parameters.Add(new SqlParameter("@nom", fournisseur.getNomFournisseur));
            command.Parameters.Add(new SqlParameter("@prenom", fournisseur.getPrenomFournisseur));
            command.Parameters.Add(new SqlParameter("@email", fournisseur.getEmailFournisseur));
            command.Parameters.Add(new SqlParameter("@adresse", fournisseur.getAdresseFournisseur));

            var linesAffected = (int)command.ExecuteNonQuery();

            if(linesAffected != 1)
            {
                throw new Exception($"Impossible de mettre à jour le fournisseur {fournisseur.getID}");
            }

            closeConnection();

            return fournisseur;

        }



        public override void delete(Fournisseur_DAL fournisseur)
        {
            createConnection();

            command.CommandText = "DELETE * FROM fournisseur WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", fournisseur.getID));

            var linesAffected = (int)command.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer le fournisseur {fournisseur.getID}");
            }

            closeConnection();

        }


    }
}
