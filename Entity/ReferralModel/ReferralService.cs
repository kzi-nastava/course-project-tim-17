using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace HealthcareSystem.Entity.ReferralModel
{
    internal class ReferralService
    {
        public IReferralRepository ReferralRepository;

        public ReferralService(IReferralRepository referralRepository)
        {
            ReferralRepository = referralRepository;
        }

        public void Insert(Referral referral)
        {
            ReferralRepository.Insert(referral);
        }
        public void Delete(Referral referral)
        {
            ReferralRepository.Delete(referral._id);
        }
        public void Update(Referral referral)
        {
            ReferralRepository.Update(referral);
        }
        public List<Referral> GetAll()
        {
            return ReferralRepository.GetAll();
        }
        public Referral GetById(Referral referral)
        {
            return ReferralRepository.GetById(referral._id);
        }
        public Referral GetById(ObjectId id)
        {
            return ReferralRepository.GetById(id);
        }
    }
}
