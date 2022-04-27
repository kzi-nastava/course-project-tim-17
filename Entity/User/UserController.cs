using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.User
{
    class UserController
    {
        public IMongoCollection<User> userCollection;
        public UserController(IMongoDatabase database){
            this.UserCollection = database.GetCollection<User>("Users");
            
            }
        public void getAllUsers() {
            List<User> Users = UserCollection.Find(item =>  true).ToList();

            foreach(User User in Users) {
                Console.WriteLine(User.name);
            }
        }
        public void InsertToCollection(User User){
            UserCollection.InsertOne(User);
        }
        
        }
    }


