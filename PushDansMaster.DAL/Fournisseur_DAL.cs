using System;
using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class Fournisseur_DAL
    {
        public int idFournisseur { get; }
        public string societeFournisseur { get; private set; }
        public bool civiliteFournisseur { get; private set; }
        public string nomFournisseur { get; private set; }
        public string prenomFournisseur { get; private set; }
        public string emailFournisseur { get; private set; }
        public string adresseFournisseur { get; private set; }

        public Fournisseur_DAL(int id,string societe, bool civilite, string nom, string prenom, string email, string adresse)
            => (societeFournisseur, civiliteFournisseur, nomFournisseur, prenomFournisseur, emailFournisseur, adresseFournisseur)
            = (societe, civilite, nom, prenom, email, adresse);

        internal void addFournisseur(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO fournisseur(societe, civilite, nom, prenom, email, adresse)"
                                       +  " values (@societe, @civilite, @nom, @prenom, @email, @adresse)";
                command.Parameters.Add(new SqlParameter("@societe", societeFournisseur));
                command.Parameters.Add(new SqlParameter("@civilite", civiliteFournisseur));
                command.Parameters.Add(new SqlParameter("@nom", nomFournisseur));
                command.Parameters.Add(new SqlParameter("@prenom", prenomFournisseur));
                command.Parameters.Add(new SqlParameter("@email", emailFournisseur));
                command.Parameters.Add(new SqlParameter("@adresse", adresseFournisseur));

                command.ExecuteNonQuery();
            }
           
        }

    }
}
