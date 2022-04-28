using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
namespace HealthcareSystem.Entity.RoomModel
{ //type, equipm
    class Room
    {
        public ObjectId _id { get; set; }
        [BsonElement("name")]
        public string name{get;set;}
        [BsonElement("type")]
        public RoomType type { get; set; }
        [BsonElement("equipments")]
        public List<Equipment> equipments { get; set; } = new List<Equipment>();


        public Room(string name,RoomType type)
        {
            this.name = name;
            this.type = type;
            this._id = ObjectId.GenerateNewId();
        }
    }


}