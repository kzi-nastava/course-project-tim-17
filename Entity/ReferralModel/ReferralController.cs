using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.HealthCardModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.ReferralModel
{
    class ReferralController
    {
        public IMongoCollection<Referral> referralCollection;

        public ReferralController(IMongoDatabase database)
        {
            this.referralCollection = database.GetCollection<Referral>("Referrals");

        }
        public List<Referral> getAllReferrals()
        {
            List<Referral> referrals = referralCollection.Find(item => true).ToList();

            return referrals;
        }
        public void InsertToCollection(Referral r)
        {
            referralCollection.InsertOne(r);
        }
        public Referral findById(ObjectId id)
        {
            return referralCollection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Delete(ObjectId id)
        {

            referralCollection.DeleteOne(item => item._id == id);

        }


        public List<Referral> GetReferralsOfHealthCard(HealthCard h)
        {
            List<Referral> referrals = new List<Referral>();
            foreach (ObjectId rId in h.referrals)
            {
                if (findById(rId) != null)
                {
                    referrals.Add(findById(rId));

                }
            }

            return referrals;
        }



    }
}