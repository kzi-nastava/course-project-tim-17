using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.CheckModel
{
    class CheckController
    {
        public IMongoCollection<Check> checkCollection;
        public CheckController(IMongoDatabase database)
        {
            this.checkCollection = database.GetCollection<Check>("Checks");

        }
        public void getAllChecks()
        {
            List<Check> checks = checkCollection.Find(item => true).ToList();

            foreach (Check check in checks)
            {
                Console.WriteLine(check.appointmentId);
            }
        }
        public void InsertToCollection(Check check)
        {
            checkCollection.InsertOne(check);
        }
        public Check findById(ObjectId id)
        {
            return checkCollection.Find(item => item._id == id).FirstOrDefault();
        }

    }
}

