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
        public List<User> getAllUsers()
        {
            List<User> users = userCollection.Find(item => true).ToList();

            return users;
        }

     
        public void InsertToCollection(User user)
        {
            userCollection.InsertOne(user);
        }
        public User FindById(ObjectId id)
        {
            return userCollection.Find(item => item._id == id).FirstOrDefault();
        }

        public User FindByEmailAndPassword(string password, string email)
        {
            return userCollection.Find(item => item.password == password & item.email == email).FirstOrDefault();
        }

        public User FindByEmail(string email)
        {
            return userCollection.Find(item => item.email == email).FirstOrDefault();
        }



        public User CheckCredentials(string email, string password)
        {
            return userCollection.Find(item => item.password == password & item.email == email).FirstOrDefault();
           
        }


        public void DeleteFromCollection(ObjectId id) {
            userCollection.DeleteOne(item => item._id == id);
        }

        public void Update(User user)
        {
          userCollection.ReplaceOne(item => item._id == user._id, user);

        }
    }

    }


