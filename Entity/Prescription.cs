using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
namespace HealthcareSystem.Entity

{

    class Prescription
    {
        public ObjectId _id { get; set; }
        [BsonElement("when")]
        public string when{ get; set; }
        [BsonElement("quantityPerDay")]
        public int quantityPerDay{ get; set; }
        [BsonElement("meal")]
        public Meal meal;

        [BsonElement("drug")]

        public ObjectId drug{ get; set; }




        public Prescription(ObjectId drugId,string when, int quantityPerDay, Meal meal)
        {
            this.drug = drugId;
            this.when = when;
            this.quantityPerDay = quantityPerDay;
            this.meal = meal;
            this._id = ObjectId.GenerateNewId();
        }

    }

}
