using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.DrugModel
{
    internal interface IRevisionRepository :IRepository<Revision>
    {
        public Revision GetByDrugId(ObjectId id);
    }
}
