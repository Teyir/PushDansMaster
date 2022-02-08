using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class FournisseurDepot_DAL : Depot_DAL<Fournisseur_DAL>
    {
        public FournisseurDepot_DAL()
            : base()
        {

        }
        public override List<Fournisseur_DAL> getAll()
        {
            createConnection();

            command.CommandText = "SELECT id, societe, civilite, nom, prenom, email, adresse, status FROM fournisseur";

            SqlDataReader reader = command.ExecuteReader();

            List<Fournisseur_DAL> listFournisseur = new List<Fournisseur_DAL>();

            while (reader.Read())
            {
                Fournisseur_DAL f = new Fournisseur_DAL(reader.GetInt32(0),
                                                reader.GetString(1),
                                                reader.GetBoolean(2),
                                                reader.GetString(3),
                                                reader.GetString(4),
                                                reader.GetString(5),
                                                reader.GetString(6),
                                                reader.GetInt32(7));
                listFournisseur.Add(f);
            }

            closeConnection();

            return listFournisseur;
        }


        public override Fournisseur_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "SELECT id, societe, civilite, nom, prenom, email, adresse, status FROM fournisseur WHERE id=@id";

            command.Parameters.Add(new SqlParameter("@id", ID));
            SqlDataReader reader = command.ExecuteReader();

            List<Fournisseur_DAL> listFournisseur = new List<Fournisseur_DAL>();

            Fournisseur_DAL f;
            if (reader.Read())
            {
                f = new Fournisseur_DAL(reader.GetInt32(0),
                                                reader.GetString(1),
                                                reader.GetBoolean(2),
                                                reader.GetString(3),
                                                reader.GetString(4),
                                                reader.GetString(5),
                                                reader.GetString(6),
                                                reader.GetInt32(7));
            }
            else
            {
                throw new Exception($"Pas de fournisseur avec l'ID {ID}");
            }

            closeConnection();

            return f;
        }


        public override Fournisseur_DAL insert(Fournisseur_DAL fournisseur)
        {
            createConnection();

            command.CommandText = "INSERT INTO fournisseur(societe, civilite, nom, prenom, email, adresse, status)"
                                    + " VALUES (@societe, @civilite, @nom, @prenom, @email, @adresse, @status); select scope_identity()";

            command.Parameters.Add(new SqlParameter("@societe", fournisseur.getSocieteFournisseur));
            command.Parameters.Add(new SqlParameter("@civilite", fournisseur.getCiviliteFournisseur));
            command.Parameters.Add(new SqlParameter("@nom", fournisseur.getNomFournisseur));
            command.Parameters.Add(new SqlParameter("@prenom", fournisseur.getPrenomFournisseur));
            command.Parameters.Add(new SqlParameter("@email", fournisseur.getEmailFournisseur));
            command.Parameters.Add(new SqlParameter("@adresse", fournisseur.getAdresseFournisseur));
            command.Parameters.Add(new SqlParameter("@status", fournisseur.getstatusFournisseur));

            int ID = Convert.ToInt32((decimal)command.ExecuteScalar());

            fournisseur.idFournisseur = ID;


            closeConnection();

            return fournisseur;

        }

        public override Fournisseur_DAL update(Fournisseur_DAL fournisseur)
        {
            createConnection();

            command.CommandText = "UPDATE fournisseur set societe=@societe, civilite=@civilite, nom=@nom, prenom=@prenom, email=@email, adresse=@adresse, status=@status"

                                    + " WHERE id=@ID";

            command.Parameters.Add(new SqlParameter("@ID", fournisseur.getIdFournisseur));
            command.Parameters.Add(new SqlParameter("@societe", fournisseur.getSocieteFournisseur));
            command.Parameters.Add(new SqlParameter("@civilite", fournisseur.getCiviliteFournisseur));
            command.Parameters.Add(new SqlParameter("@nom", fournisseur.getNomFournisseur));
            command.Parameters.Add(new SqlParameter("@prenom", fournisseur.getPrenomFournisseur));
            command.Parameters.Add(new SqlParameter("@email", fournisseur.getEmailFournisseur));
            command.Parameters.Add(new SqlParameter("@adresse", fournisseur.getAdresseFournisseur));
            command.Parameters.Add(new SqlParameter("@status", fournisseur.getstatusFournisseur));


            int linesAffected = command.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de mettre à jour le fournisseur {fournisseur.getIdFournisseur}");
            }

            closeConnection();

            return fournisseur;

        }



        public override void delete(Fournisseur_DAL fournisseur)
        {
            createConnection();

            command.CommandText = "DELETE FROM fournisseur WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", fournisseur.getIdFournisseur));

            int linesAffected = command.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer le fournisseur {fournisseur.getIdFournisseur}");
            }

            closeConnection();

        }

        public override void deleteByID(int ID)
        {
            createConnection();

            command.CommandText = "DELETE FROM fournisseur WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));

            int linesAffected = command.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer le fournisseur {ID}");
            }

            closeConnection();

        }


    }
}
