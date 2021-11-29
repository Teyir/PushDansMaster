using System;
using System.Data.SqlClient;


namespace PushDansMaster.DAL
{
    public class Reference_DAL
    {
       public int ID { get; private set; }
       public string ref_libelle { get; private set; }
       public string ref_reference { get; private set; }
       public string ref_marque { get; private set; }
       public int ref_quantite { get; private set; }

        public Reference_DAL(string libelle, string reference, string marque, int quantite)
        => (ref_libelle, ref_reference, ref_marque, ref_quantite)
        = (libelle, reference, marque, quantite);
        public Reference_DAL(int id, string libelle, string reference, string marque, int quantite)
        => (ID, ref_libelle, ref_reference, ref_marque, ref_quantite)
        = (id, libelle, reference, marque, quantite);

        internal void Insert(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "insert into reference(libelle, reference, marque, quantite"
                        + " values (@libelle, @reference, @marque, @quantite";
                command.Parameters.Add(new SqlParameter("@libelle", ref_libelle));
                command.Parameters.Add(new SqlParameter("@reference", ref_reference));
                command.Parameters.Add(new SqlParameter("@marque", ref_marque));
                command.Parameters.Add(new SqlParameter("@quantite", ref_quantite));

                command.ExecuteNonQuery();

                connection.Close();

            }
        }
    }
}
