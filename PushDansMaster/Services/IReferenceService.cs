using System.Collections.Generic;

namespace PushDansMaster
{
    public interface IReferenceService
    {

        public List<Reference> getAll();

        public Reference insert(Reference f);
    }
}
