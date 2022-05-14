using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
namespace HealthcareSystem.Entity.RoomModel
{
    class MergeRoomRenovation
    {
        public ObjectId _id;

        [BsonElement("mergedRoomName")]
        public string MergedRoomName { get; set; }

        [BsonElement("renovationId")]
        public ObjectId RenovationId { get; set; }

        [BsonElement("firstRoomId")]
        public ObjectId FirstRoomId { get; set; }

        [BsonElement("secondRoomId")]
        public ObjectId SecondRoomId { get; set; }

        public MergeRoomRenovation(string newName,ObjectId renovationId, ObjectId firsRoomId, ObjectId secondRoomId) 
        {
            this._id = ObjectId.GenerateNewId();   
            this.RenovationId = renovationId;
            this.FirstRoomId = firsRoomId;  
            this.SecondRoomId = secondRoomId;
            this.MergedRoomName = newName;
        }

    }
}
