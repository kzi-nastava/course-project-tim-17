using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.UserModel
{
    class BlockedUserController
    {
        public IMongoCollection<BlockedUser> blockedUserCollection;
        public IMongoCollection<User> userCollection;
        
        public BlockedUserController(IMongoDatabase database)
        {
            this.blockedUserCollection = database.GetCollection<BlockedUser>("BlockedUsers");
            this.userCollection = database.GetCollection<User>("Users");

        }
        public void GetAllUsers()
        {
            List<BlockedUser> blockedUsers = blockedUserCollection.Find(item => true).ToList();

            foreach (BlockedUser user in blockedUsers)
            {
                Console.WriteLine(user._id);
            }
        }
        public void InsertToCollection(BlockedUser blockedUser)
        {
            blockedUserCollection.InsertOne(blockedUser);
        }
        public BlockedUser FindById(ObjectId id)
        {
            return blockedUserCollection.Find(item => item._id == id).FirstOrDefault();
        }

        public BlockedUser FindByUserId(ObjectId id)
        {
            return blockedUserCollection.Find(item => item.userId == id).FirstOrDefault();
        }
        public BlockedUser CheckIfBlocked(ObjectId id)
        {
            return blockedUserCollection.Find(item => item.userId == id).FirstOrDefault();
        }


        public User GetBlockedUser(ObjectId id)
        {
            return userCollection.Find(item => item._id == id).FirstOrDefault();
           
        }

        public void Unblock(ObjectId id)
        {
            blockedUserCollection.DeleteOne(item => item._id == id);
        }


        public void PrintBlockedUsers() {
            var list = blockedUserCollection.Find(item => true).ToList();
            foreach(BlockedUser bu in list) {
                User u = GetBlockedUser(bu.userId);
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


