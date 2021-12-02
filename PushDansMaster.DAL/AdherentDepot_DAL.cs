using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class AdherentDepot_DAL : Depot_DAL<Adherent_DAL>
    {

        public override List<Adherent_DAL> getAll()
        {
            createConnection();

            command.CommandText = "SELECT id, societe, email, nom, prenom, adresse, date_adhesion, status FROM adherent";
            var reader = command.ExecuteReader();

            var listeAdherent = new List<Adherent_DAL>();      
            while (reader.Read())
            {
                var tmp = new Adherent_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetDateTime(6),
                                        reader.GetBoolean(7));

                listeAdherent.Add(tmp);
            }

            closeConnection();

            return listeAdherent;
        }


        public override Adherent_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "SELECT id, societe, email, nom, prenom, adresse, date_adhesion, status FROM adherent WHERE id=@id";
            command.Parameters.Add(new SqlParameter("@id", ID));
            var reader = command.ExecuteReader();

            var listeAdherent = new List<Adherent_DAL>();

            Adherent_DAL ad;
            if (reader.Read())
            {
                ad = new Adherent_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetDateTime(6),
                                        reader.GetBoolean(7));
            }
            else
                throw new Exception($"Pas d'adherent dans la BDD avec l'ID {ID}");

            closeConnection();

            return ad;
        }

        public override Adherent_DAL insert(Adherent_DAL adherent)
        {
            createConnection();

            command.CommandText = "INSERT INTO adherent(societe, email, nom, prenom, adresse, date_adhesion, status)"
                                + " VALUES (@societe, @email, @nom, @prenom, @adresse, @date_adhesion, @status); SELECT scope_identity()";
            command.Parameters.Add(new SqlParameter("@societe", adherent.getSocieteAdherent));
            command.Parameters.Add(new SqlParameter("@email", adherent.getEmailAdherent));
            command.Parameters.Add(new SqlParameter("@nom", adherent.getNomAdherent));
            command.Parameters.Add(new SqlParameter("@prenom", adherent.getPrenomAdherent));
            command.Parameters.Add(new SqlParameter("@adresse", adherent.getAdresseAdherent));
            command.Parameters.Add(new SqlParameter("@date_adhesion", adherent.getDateAdhesionAdherent));
            command.Parameters.Add(new SqlParameter("@status", adherent.getStatus));

            var ID = Convert.ToInt32((decimal)
                command.ExecuteScalar());


            closeConnection();

            return adherent;
        }

        public override Adherent_DAL update(Adherent_DAL adherent)
        {
            createConnection();

            command.CommandText = "UPDATE adherent SET societe=@Societe, email=@Email, nom=@Nom, prenom=@Prenom, adresse=@Adresse, date_adhesion=@Date_adhesion, status=@Status)"
                                    + " WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@Societe", adherent.getSocieteAdherent));
            command.Parameters.Add(new SqlParameter("@Email", adherent.getEmailAdherent));
            command.Parameters.Add(new SqlParameter("@Nom", adherent.getNomAdherent));
            command.Parameters.Add(new SqlParameter("@Prenom", adherent.getPrenomAdherent));
            command.Parameters.Add(new SqlParameter("@Adresse", adherent.getAdresseAdherent));
            command.Parameters.Add(new SqlParameter("@Date_adhesion", adherent.getDateAdhesionAdherent));
            command.Parameters.Add(new SqlParameter("@Status", adherent.getStatus));
            var nombreDeLignesAffectees = (int)
                command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'adherent d'ID {adherent.getID}");
            }

            closeConnection();

            return adherent;
        }

        public override void delete(Adherent_DAL adherent)
        {
            createConnection();

            command.CommandText = "DELETE * FROM adherent WHERE id=@id";
            command.Parameters.Add(new SqlParameter("@id", adherent.getID));
            var nombreDeLignesAffectees = (int)
                command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer l'adherent d'ID {adherent.getID}");
            }

            closeConnection();
        }

        public override void deleteByID(int ID)
        {
            createConnection();

            command.CommandText = "DELETE * FROM adherent WHERE id=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));

            var linesAffected = (int)command.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer l'adherent {ID}");
            }

            closeConnection();

        }

    }
}
