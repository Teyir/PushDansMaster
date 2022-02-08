using System.Data.SqlClient;

namespace PushDansMaster.DAL
{
    public class importReferences_DAL
    {

        public string libelleReference { get; set; }
        public string referenceReference { get; set; }
        public string marqueReference { get; set; }

        public importReferences_DAL(string libelle, string reference, string marque)
        {
            (libelleReference, referenceReference, marqueReference)
                       = (libelle, reference, marque);
        }


        //Send to the database
        internal void addRefenrences(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO references(libelle, reference, marque, quantite)"
                                        + " VALUES (@libelle, @reference, @marque, 0)";
                command.Parameters.Add(new SqlParameter("@libelle", libelleReference));
                command.Parameters.Add(new SqlParameter("@reference", referenceReference));
                command.Parameters.Add(new SqlParameter("@marque", marqueReference));

                command.ExecuteNonQuery();
            }
        }

    }
}
