using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace HealthcareSystem.Entity.RoomModel
{ //type, equipm
    class Room
    {
        public ObjectId _id { get; set; }
        [BsonElement("type")]
        public string type { get; set; }
        [BsonElement("equipments")]
        public List<Equipment> equipments { get; set; } = new List<Equipment>();


        public Room(string type, List<Equipment> equipments)
        {
            this.type = type;
            this.equipments = equipments;
            this._id = ObjectId.GenerateNewId();
        }
    }


}