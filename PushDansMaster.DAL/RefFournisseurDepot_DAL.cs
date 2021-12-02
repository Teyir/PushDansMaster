using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DAL
{
    public class RefFournisseurDepot_DAL : Depot_DAL<RefFournisseur_DAL>
    {
        public override List<RefFournisseur_DAL> getAll()
        {
            createConnection();

            command.CommandText = "select id_fournisseur, id_reference from ref_fournisseur";
            var reader = command.ExecuteReader();

            var listeDeRefFournisseur = new List<RefFournisseur_DAL>();

            while (reader.Read())
            {
                var p = new RefFournisseur_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1));

                listeDeRefFournisseur.Add(p);
            }

            closeConnection();

            return listeDeRefFournisseur;
        }

        public override RefFournisseur_DAL getByID(int ID)
        {
            createConnection();

            command.CommandText = "select id_fournisseur, id_reference from ref_fournisseur where CONCAT(id_fournisseur, id_reference)=@ID";
            command.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = command.ExecuteReader();

            var listeDePoints = new List<RefFournisseur_DAL>();

            RefFournisseur_DAL rf;
            if (reader.Read())
            {
                rf = new RefFournisseur_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1));
            }
            else
                throw new Exception($"Pas de RefFournisseur dans la BDD avec l'ID {ID}");

            closeConnection();

            return rf;
        }

        public override RefFournisseur_DAL insert(RefFournisseur_DAL refFournisseur)
        {
            createConnection();

            command.CommandText = "insert into ref_fournisseur(id_fournisseur, id_reference)"
                                    + " values (@id_fournisseur, @id_reference); select scope_identity()";
            command.Parameters.Add(new SqlParameter("@id_fournisseur", refFournisseur.GetIDfournisseur));
            command.Parameters.Add(new SqlParameter("@id_reference", refFournisseur.GetIDreference));

            closeConnection();

            return refFournisseur;
        }

        public override RefFournisseur_DAL update(RefFournisseur_DAL refFournisseur)
        {
            createConnection();

            command.CommandText = "update ref_fournisseur set id_fournisseur=@id_fournisseur, id_reference=@id_reference)"
                                   + " where id_fournisseur = @id_reference and id_reference = @id_reference";
            command.Parameters.Add(new SqlParameter("@id_fournisseur", refFournisseur.GetIDfournisseur));
            command.Parameters.Add(new SqlParameter("@id_reference", refFournisseur.GetIDreference));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                int rfException = int.Parse(refFournisseur.GetIDfournisseur.ToString() + refFournisseur.GetIDreference.ToString());
                throw new Exception($"Impossible de mettre à jour la reference fournisseur d'ID : {rfException}");
            }

            closeConnection();

            return refFournisseur;
        }

        public override void delete(RefFournisseur_DAL refFournisseur)
        {
            createConnection();

            command.CommandText = "delete from ref_fournisseur where id_fournisseur = @id_fournisseur and id_reference = @id_reference";
            command.Parameters.Add(new SqlParameter("@id_fournisseur", refFournisseur.GetIDfournisseur));
            command.Parameters.Add(new SqlParameter("@id_reference", refFournisseur.GetIDreference));
            var nombreDeLignesAffectees = (int)command.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                int rfException = int.Parse(refFournisseur.GetIDfournisseur.ToString() + refFournisseur.GetIDreference.ToString());
                throw new Exception($"Impossible de supprimer le prix d'ID {rfException}");
            }

            closeConnection();
        }
    }
}
