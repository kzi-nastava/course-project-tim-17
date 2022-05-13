using HealthcareSystem.Entity.CheckModel;
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



    }
}