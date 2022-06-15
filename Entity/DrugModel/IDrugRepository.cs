using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.DrugModel
{
    internal interface IDrugRepository : IRepository<Drug>
    {
        public Drug FindByDrugName(string drugName);
    }
}
