using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;

namespace HealthcareSystem.Entity.RoomModel.RenovationFiles
{
    class Renovation
    {
        public ObjectId _id { get; set; }
        [BsonElement("roomId")]
        public ObjectId roomId { get; set; }

        [BsonElement("renovationStartDate")]
        public DateTime renovationStartDate { get; set; }

        [BsonElement("renovationEndDate")]
        public DateTime renovationEndDate { get; set; }

        [BsonElement("renovationType")]
        public int RenovationType { get; set; }

        public Renovation(ObjectId roomId,DateTime start,DateTime end) 
        {
            _id = ObjectId.GenerateNewId();
            this.roomId = roomId;
            this.renovationStartDate = start;
            this.renovationEndDate = end;
            
        }



    }
}
