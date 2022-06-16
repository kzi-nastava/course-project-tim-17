using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.UserModel
{
    class UserRepository : IUserRepository
    {
        public IMongoCollection<User> collection;
        public IMongoDatabase database;
        public UserRepository()
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
            this.collection = database.GetCollection<User>("Users");
        }

        public List<User> GetAll()
        {
            List<User> users = collection.Find(item => true).ToList();

            return users;
        }

     
        public void Insert(User user)
        {
            collection.InsertOne(user);
        }
        public User GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }


        public User GetByEmail(string email)
        {
            return collection.Find(item => item.email == email).FirstOrDefault();
        }

        public List<User> GetAllPatients()
        {
            return  collection.Find(item => item.role == Role.PATIENT).ToList();
            
        }



        public User CheckCredentials(string email, string password)
        {
            return collection.Find(item => item.password == password & item.email == email).FirstOrDefault();
           
        }


        public void Delete(ObjectId id) {
            collection.DeleteOne(item => item._id == id);
        }

        public void Update(User user)
        {
          collection.ReplaceOne(item => item._id == user._id, user);

        }
    }

    }


