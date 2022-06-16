using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.UserModel
{
    class BlockedUserRepository : IBlockedUserRepository
    {
        public IMongoCollection<BlockedUser> blockedUserCollection;
        public IMongoCollection<User> userCollection;
        public IMongoDatabase database;

        public BlockedUserRepository(IMongoDatabase database)
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
            this.blockedUserCollection = database.GetCollection<BlockedUser>("BlockedUsers");
            this.userCollection = database.GetCollection<User>("Users");
        }
        public List<BlockedUser> GetAll()
        {
            return blockedUserCollection.Find(item => true).ToList();
        }
        public void Insert(BlockedUser blockedUser)
        {
            blockedUserCollection.InsertOne(blockedUser);
        }
        public void Update(BlockedUser blockedUser)
        {
            blockedUserCollection.ReplaceOne(item => item._id == blockedUser._id, blockedUser);
        }
        public void Delete(ObjectId id)
        {
            blockedUserCollection.DeleteOne(item => item._id == id);
        }
        public BlockedUser GetById(ObjectId id)
        {
            return blockedUserCollection.Find(item => item._id == id).FirstOrDefault();
        }


        public BlockedUser GetByUserId(ObjectId id)
        {
            return blockedUserCollection.Find(item => item.userId == id).FirstOrDefault();
        }
        public BlockedUser CheckIfBlocked(ObjectId id)
        {
            return blockedUserCollection.Find(item => item.userId == id).FirstOrDefault();
        }
     
        public void PrintBlockedUsers() {
            var list = blockedUserCollection.Find(item => true).ToList();
            foreach(BlockedUser bu in list) {
                User u = userCollection.Find(item => item._id == bu.userId).FirstOrDefault();
                Console.WriteLine(" -----------------------------");
                Console.WriteLine("Name: " + " " + u.name);
                Console.WriteLine("Last name: " + " " + u.lastName);
                Console.WriteLine("Email: " + " " + u.email);
                Console.WriteLine("Blocked by: " + " " + bu.blockedBy.ToString());
                Console.WriteLine();
            }
        }

    }
}


