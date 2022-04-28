using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using HealthcareSystem.Entity.Enumerations;
namespace HealthcareSystem.Entity.DrugModel
{
    class DrugVerification
    {

        // status, listu ingr,drug name

        public ObjectId _id { get; set; }
        [BsonElement("drugName")]
        public string drugName { get; set; }
        [BsonElement("ingredients")]
        public List<Ingredient> ingredients { get; set; } = new List<Ingredient>();

        [BsonElement("status")]
        public Status status { get; set; }


        public DrugVerification(string name, List<Ingredient> ingredients)
        {
            this._id = ObjectId.GenerateNewId();
            this.drugName = name;
            this.ingredients = ingredients;
            this.status = Status.ON_HOLD;
            
        }

    }
}
