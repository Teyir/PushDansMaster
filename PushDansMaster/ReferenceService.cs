using PushDansMaster.DAL;
using System.Collections.Generic;
using System.Linq;

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
