using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace HealthcareSystem.Entity
{

    class Equipment
    {
        public ObjectId _id { get; set; }
        [BsonElement("type")]
        public string type;
        [BsonElement("quantity")]
        public int quantity;
        [BsonElement("description")]
        public string description;


        public Equipment(string type, string description, int quantity)
        {
            this.type = type;
            this.description = description;
            this.quantity = quantity;
            this._id = ObjectId.GenerateNewId();
        }

    }

}
