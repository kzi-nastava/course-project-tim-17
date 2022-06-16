using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace HealthcareSystem.Entity.UserActionModel
{
    class UserActionRepository : IUserActionRepository
    {
        public IMongoCollection<UserAction> userActionCollection;
        public IMongoDatabase database;
        public UserActionRepository(){
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
            this.userActionCollection = database.GetCollection<UserAction>("UserAction");
        }

        public List<UserAction> GetAll() {
            return userActionCollection.Find(item => true).ToList();
        }
        public void Update(UserAction userAction)
        {
            userActionCollection.ReplaceOne(item => item._id == userAction._id, userAction);
        }
        public void Insert(UserAction userAction)
        {
            userActionCollection.InsertOne(userAction);
        }

        public void Delete(ObjectId id)
        {
            userActionCollection.DeleteOne(item => item._id == id);
        }

        public UserAction GetById(ObjectId id) {
            return userActionCollection.Find(item => item.userId == id).FirstOrDefault();
        }

        public List<UserAction> GetAllById(ObjectId id)
        {
            return userActionCollection.Find(item => item.userId == id).ToList();
        }
    }
}