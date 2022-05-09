using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
namespace HealthcareSystem.Entity
{

    class Equipment
    {
        public ObjectId _id { get; set; }
        [BsonElement("type")]
        public EquipmentType type;
        [BsonElement("quantity")]
        public int quantity{get;set;}
        [BsonElement("item")]
        public string item{get;set;}
        [BsonElement("isDynamic")]
        public bool isDynamic{get;set;}

        public Equipment(EquipmentType type, string item, int quantity,bool dynamic)
        {
            this.type = type;
            this.item = item;
            this.quantity = quantity;
            this._id = ObjectId.GenerateNewId();
            this.isDynamic = dynamic;
        }

    }

}
