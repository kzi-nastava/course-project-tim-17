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
        public void getAllUsers()
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
        public BlockedUser findById(ObjectId id)
        {
            return blockedUserCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public BlockedUser checkIfBlocked(ObjectId id)
        {
            return blockedUserCollection.Find(item => item.userId == id).FirstOrDefault();
        }


        public User getBlockedUser(ObjectId id)
        {
            return userCollection.Find(item => item._id == id).FirstOrDefault();
           
        }

        public void pritBlockedUsers() {
            var list = blockedUserCollection.Find(item => true).ToList();
            foreach(BlockedUser bu in list) {
                User u = getBlockedUser(bu.userId);
                Console.Write(u.name) ;
                Console.Write(" ") ;
                Console.WriteLine(u.lastName) ;
            }
        }

    }

    }


