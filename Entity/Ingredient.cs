using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace HealthcareSystem.Entity
{
    class Ingredient
    {
        public ObjectId _id{get;set;}
        [BsonElement("name")]
        public string name;

        public Ingredient(string name) {
        this.name = name;
        this._id = ObjectId.GenerateNewId();
        }

    }
}