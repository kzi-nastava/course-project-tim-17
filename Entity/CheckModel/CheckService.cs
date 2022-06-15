using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.CheckModel
{
    internal class CheckService
    {
        public ICheckRepository checkRepository { get; set; }
        public CheckService(ICheckRepository checkRepository)
        {
            this.checkRepository = checkRepository;
        }

        public List<Check> GetAll()
        {
            return this.checkRepository.GetAll();
        }

        public Check GetById(string id)
        {
            return this.checkRepository.GetById(new MongoDB.Bson.ObjectId(id));
        }

        public void Instert(Check check)
        {
            checkRepository.Insert(check);
        }

        public void Update(Check check)
        {
            checkRepository.Update(check);
        }

        public void Delete(Check check)
        {
            checkRepository.Delete(check._id);
        }
    }
}
