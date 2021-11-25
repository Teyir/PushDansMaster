using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DAL
{ 

    public class Adherent_DAL
    {
    public int idAdherent { get; set; }

    public string societeAdherent { get;  private set; }

    public string emailAdherent { get ; private set; }

    public string nomAdherent { get; private set; }

    public string prenomAdherent { get; private set; }

    public string adresseAdherent { get; private set; }

    public DateTime dateAdhesionAdherent { get;  private set; }

    public bool statusAdherent { get; private set; }


    public Adherent_DAL(int id,string societe, string email, string nom, string prenom, string adresse, DateTime dateAdhesion, bool status)
        => (idAdherent, societeAdherent, emailAdherent, nomAdherent, prenomAdherent, adresseAdherent, dateAdhesionAdherent, statusAdherent)
        = (id, societe, email, nom, prenom, adresse, dateAdhesion, status);

    internal void Insert(SqlConnection connection)
    {
        using (var command = new SqlCommand())
        {
            command.Connection = connection;
                    command.CommandText = "insert into adherent(societe, email, nom, prenom, adresse, date_adhesion, status"
                            + " values (@societe, @email, @nom, @prenom, @adresse, @date_adhesion, @status)";
                command.Parameters.Add(new SqlParameter("@societe", societeAdherent));
                command.Parameters.Add(new SqlParameter("@email", emailAdherent));
                command.Parameters.Add(new SqlParameter("@nom", nomAdherent));
                command.Parameters.Add(new SqlParameter("@prenom", prenomAdherent));
                command.Parameters.Add(new SqlParameter("@adresse", adresseAdherent));
                command.Parameters.Add(new SqlParameter("@date_adhesion", dateAdhesionAdherent));
                command.Parameters.Add(new SqlParameter("@status", statusAdherent));

                command.ExecuteNonQuery();

                connection.Close();

            }
        }
 }
}
