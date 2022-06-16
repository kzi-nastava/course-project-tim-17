using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.HealthCardModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.ReferralModel
{
    class ReferralRepository : IReferralRepository
    {
        public IMongoCollection<Referral> referralCollection;
        IMongoDatabase database;

        public ReferralRepository()
        {
            GetDatabase();
            GetCollection();

        }
        public void GetDatabase()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Tim17:UXGhApWVw9oc6VGg@cluster0.se6mz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            this.database = client.GetDatabase("USI");
        }
        public void GetCollection()
        {
            this.referralCollection = database.GetCollection<Referral>("Referrals");
        }
        public List<Referral> GetAll()
        {
            List<Referral> referrals = referralCollection.Find(item => true).ToList();

            return referrals;
        }
        public void Insert(Referral r)
        {
            referralCollection.InsertOne(r);
        }
        public Referral GetById(ObjectId id)
        {
            return referralCollection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Delete(ObjectId id)
        {

            referralCollection.DeleteOne(item => item._id == id);

        }

        public void Update(Referral referral)
        {
            referralCollection.ReplaceOne(item => item._id == referral._id, referral);
        }


        public List<Referral> GetReferralsOfHealthCard(HealthCard h)
        {
            List<Referral> referrals = new List<Referral>();
            foreach (ObjectId rId in h.referrals)
            {
                if (GetById(rId) != null)
                {
                    referrals.Add(GetById(rId));

                }
            }

            return referrals;
        }



    }
}