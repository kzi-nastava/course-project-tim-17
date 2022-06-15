using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace HealthcareSystem.Entity.HealthCardModel
{
    internal interface IHealthCardRepository:IRepository<HealthCard>
    {
        HealthCard FindByPatientId(ObjectId id);

    }
}
