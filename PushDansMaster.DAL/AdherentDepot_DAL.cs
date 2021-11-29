using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DAL
{
    public class AdherentDepot_DAL : Depot_DAL<Adherent_DAL>
    {

        public override List<Adherent_DAL> getAll()
        {
            createConnection();

            command.CommandText = "select id, societe, email, nom, prenom, adresse, date_adhesion, status from adherent";
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

            command.CommandText = "select id, societe, email, nom, prenom, adresse, date_adhesion, status where id=@id";
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

            command.CommandText = "insert into adherent(societe, email, nom, prenom, adresse, date_adhesion, status)"
                                + " values (@societe, @email, @nom, @prenom, @adresse, @date_adhesion, @status); select scope_identity()";
            command.Parameters.Add(new SqlParameter("@societe", adherent.societeAdherent));
            command.Parameters.Add(new SqlParameter("@email", adherent.emailAdherent));
            command.Parameters.Add(new SqlParameter("@nom", adherent.nomAdherent));
            command.Parameters.Add(new SqlParameter("@prenom", adherent.prenomAdherent));
            command.Parameters.Add(new SqlParameter("@adresse", adherent.adresseAdherent));
            command.Parameters.Add(new SqlParameter("@date_adhesion", adherent.dateAdhesionAdherent));
            command.Parameters.Add(new SqlParameter("@status", adherent.statusAdherent));

            var ID = Convert.ToInt32((decimal)
                command.ExecuteScalar());


            closeConnection();

            return adherent;
        }

        public override Adherent_DAL update(Adherent_DAL adherent)
        {
            createConnection();

            command.CommandText = "update adherent set societe=@Societe, email=@Email, nom=@Nom, prenom=@Prenom, adresse=@Adresse, date_adhesion=@Date_adhesion, status=@Status)"
                                    + " where id=@ID";
            command.Parameters.Add(new SqlParameter("@Societe", adherent.societeAdherent));
            command.Parameters.Add(new SqlParameter("@Email", adherent.emailAdherent));
            command.Parameters.Add(new SqlParameter("@Nom", adherent.nomAdherent));
            command.Parameters.Add(new SqlParameter("@Prenom", adherent.prenomAdherent));
            command.Parameters.Add(new SqlParameter("@Adresse", adherent.adresseAdherent));
            command.Parameters.Add(new SqlParameter("@Date_adhesion", adherent.dateAdhesionAdherent));
            command.Parameters.Add(new SqlParameter("@Status", adherent.statusAdherent));
            var nombreDeLignesAffectees = (int)
                command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'adherent d'ID {adherent.ID}");
            }

            closeConnection();

            return adherent;
        }

        public override void delete(Adherent_DAL adherent)
        {
            createConnection();

            command.CommandText = "delete from adherent where id=@id";
            command.Parameters.Add(new SqlParameter("@id", adherent.ID));
            var nombreDeLignesAffectees = (int)
                command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer l'adherent d'ID {adherent.ID}");
            }

            closeConnection();
        }

    }
}
