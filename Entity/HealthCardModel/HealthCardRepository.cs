using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.ReferralModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.HealthCardModel
{
    class HealthCardRepository : IHealthCardRepository { 
    
        public IMongoCollection<HealthCard> healthCardCollection;
        public IMongoDatabase database;

        public HealthCardRepository()
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
            this.healthCardCollection = database.GetCollection<HealthCard>("HealthCards");
        }

        public List<HealthCard> GetAll()
        {
            List<HealthCard> healthCards = healthCardCollection.Find(item => true).ToList();

            return healthCards;
        }
        public void Insert(HealthCard healthCard)
        {
            healthCardCollection.InsertOne(healthCard);
        }
        public HealthCard GetById(ObjectId id)
        {
            return healthCardCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public HealthCard FindByPatientId(ObjectId id)
        {
            return healthCardCollection.Find(item => item.patientId == id).FirstOrDefault();
        }

        public void Delete(ObjectId id)
        {
            healthCardCollection.DeleteOne(item => item._id == id);
        }

        public void Update(HealthCard healthCard)
        {
            healthCardCollection.ReplaceOne(item => item._id == healthCard._id, healthCard);
        }
      
        

    }

    
}