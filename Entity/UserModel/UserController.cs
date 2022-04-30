using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.UserModel
{
    class UserController
    {
        public IMongoCollection<User> userCollection;
        public UserController(IMongoDatabase database)
        {
            this.userCollection = database.GetCollection<User>("Users");

        }
        
        public void getAllUsers()
        {
            List<User> users = userCollection.Find(item => true).ToList();

            foreach (User user in users)
            {
                Console.WriteLine(user.name);
            }
        }
        public void InsertToCollection(User user)
        {
            userCollection.InsertOne(user);
        }
        public User findById(ObjectId id)
        {
            return userCollection.Find(item => item._id == id).FirstOrDefault();
        }



        public User checkCredentials(string email, string password)
        {
            return userCollection.Find(item => item.password == password & item.email == email).FirstOrDefault();
           
        }

    }

    }


