using PushDansMaster.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster
{
    public class ReferenceService : IReferenceService
    {

        private ReferenceDepot_DAL depot = new ReferenceDepot_DAL();

        public List<Reference> getAll()
        {
            var references = depot.getAll()
                .Select(f => new Reference(f.getID, f.getLibelle, f.getReference, f.getMarque, f.getQuantite)).ToList();

            return references;
        }

        public Reference insert(Reference f)
        {
            var references = new Reference_DAL(f.getID, f.getLibelle, f.getReference, f.getMarque, f.getQuantite);
            depot.insert(references);


            return f;
        }
    }
}
