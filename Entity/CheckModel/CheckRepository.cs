using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.CheckModel
{
    class CheckRepository : ICheckRepository
    {
        public IMongoCollection<Check> checkCollection;
        public IMongoDatabase database;
        public CheckRepository()
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
            this.checkCollection = database.GetCollection<Check>("Checks");
        }
        public List<Check> GetAll()
        {
            return checkCollection.Find(item => true).ToList();

        }
        public void Insert(Check check)
        {
            checkCollection.InsertOne(check);
        }
        public Check GetById(ObjectId id)
        {
            return checkCollection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Delete(ObjectId id)
        {

            checkCollection.DeleteOne(item => item._id == id);

        }
        public void Update(Check check)
        {
            checkCollection.ReplaceOne(item => item._id == check._id, check);
        }

    }
}

