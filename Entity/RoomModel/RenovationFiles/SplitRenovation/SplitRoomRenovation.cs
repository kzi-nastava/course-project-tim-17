using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
namespace HealthcareSystem.Entity.RoomModel.RenovationFiles.SplitRenovation
{
    class SplitRoomRenovation
    {
        public ObjectId _id;

        [BsonElement("roomId")]

        public ObjectId roomId;

        [BsonElement("renovationId")]
        public ObjectId RenovationId { get; set; }

        [BsonElement("firstRoomName")]
        public string FirstRoomName { get; set; }

        [BsonElement("secondRoomName")]
        public string SecondRoomName { get; set; }

        

        [BsonElement("firstRoomEquipment")]

        public List<Equipment> firstRoomEquipment = new List<Equipment>();

        [BsonElement("secondRoomEquipment")]

        public List<Equipment> secondRoomEquipment = new List<Equipment>();




        public SplitRoomRenovation(ObjectId roomId,ObjectId renovation,string first,string second, List<Equipment> firstRoomEquipment, List<Equipment> secondRoomEquipment)
        {
            this._id = ObjectId.GenerateNewId();
            this.roomId = roomId;
            this.RenovationId = renovation;
            this.FirstRoomName = first;
            this.SecondRoomName = second;
            this.firstRoomEquipment = firstRoomEquipment;
            this.secondRoomEquipment = secondRoomEquipment;
            
        }

    }
}
