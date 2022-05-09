using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.Enumerations;

namespace HealthcareSystem.Entity.UserActionModel
{
    class UserActionController
    {
        public IMongoCollection<UserAction> userActionCollection;
        public UserActionController(IMongoDatabase database){
            this.userActionCollection = database.GetCollection<UserAction>("UserAction");
        }
        public List<UserAction> getAllUserAction() {
            return userActionCollection.Find(item => true).ToList();
        }
        public void InsertToCollection(UserAction userAction){
            userActionCollection.InsertOne(userAction);
        }
        public List<UserAction> findAllByUser(ObjectId id) {
            return userActionCollection.Find(item => item.userId == id).ToList();
        }

    }
}