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
        [BsonElement("inRenovation")]
        public bool InRenovation { get; set; }



        public Room(string name,RoomType type)
        {
            this.name = name;
            this.type = type;
            this._id = ObjectId.GenerateNewId();

            this.InRenovation = false;

        }

        public override string ToString()
        {
            return this.name;
        }

        public bool CheckIfEquipmentIsAvaliable(Equipment equipmentForCheck){
            foreach (Equipment equipment in equipments) {
                if(equipment.item == equipmentForCheck.item){
                    if(equipment.quantity > equipmentForCheck.quantity)return true;
                };
            }
            return false;
            

        }

        public bool ContainItem(string itemName) {
            foreach (Equipment equipment in equipments) {
                if(equipment.item == itemName)return true;
            }
            return false;

        }
    }


}