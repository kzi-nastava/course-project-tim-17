using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
namespace HealthcareSystem.Entity.UserModel
{
    class BlockedUser
    {
        public ObjectId _id{get;set;}
        [BsonElement("userId")]
        public ObjectId userId{get;set;}
        [BsonElement("blockedBy")]
        public BlockedBy blockedBy{get;set;}

        public BlockedUser(ObjectId userId,BlockedBy blockedBy) {
            _id = ObjectId.GenerateNewId();
            this.userId = userId;
            this.blockedBy = blockedBy;
        }
    }
}