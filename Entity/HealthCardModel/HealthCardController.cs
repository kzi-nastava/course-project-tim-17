using HealthcareSystem.Entity.CheckModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.HealthCardModel
{
    class HealthCardController
    {
        public IMongoCollection<HealthCard> healthCardCollection;

        public HealthCardController(IMongoDatabase database)
        {
            this.healthCardCollection = database.GetCollection<HealthCard>("HealthCards");

        }
        public List<HealthCard> getAllHealthCards()
        {
            List<HealthCard> healthCards = healthCardCollection.Find(item => true).ToList();

            return healthCards;
        }
        public void InsertToCollection(HealthCard healthCard)
        {
            healthCardCollection.InsertOne(healthCard);
        }
        public HealthCard findById(ObjectId id)
        {
            return healthCardCollection.Find(item => item._id == id).FirstOrDefault();
        }

        public void addCheck(HealthCard healthCard, Check check)
        {
            healthCard.checks.Add(check._id);
            healthCardCollection.ReplaceOne(item => item._id == healthCard._id, healthCard);
        }

        public void deleteHealthCard(HealthCard healthCard)
        {
            healthCardCollection.DeleteOne(item => item._id == healthCard._id);
        }

        public void update(HealthCard healthCard)
        {
            healthCardCollection.ReplaceOne(item => item._id == healthCard._id, healthCard);
        }

    }
}