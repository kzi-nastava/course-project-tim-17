using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.DrugModel
{
    internal class RevisionService
    {
        public IRevisionRepository revisionRepository;

        public RevisionService(IRevisionRepository revisionRepository)
        { 
            this.revisionRepository = revisionRepository;
        }

        public Revision GetByDrugId(ObjectId id)
        { 
            return revisionRepository.GetByDrugId(id);
        }
        public void Insert(Revision revison)
        {
            revisionRepository.Insert(revison);
        }
        public void Delete(ObjectId id)
        {
           revisionRepository.Delete(id);
        }
    }
}
