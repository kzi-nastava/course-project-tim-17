using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace HealthcareSystem.Entity.DrugModel
{
    class Drug
    {
        public ObjectId _id{get;set;}
        [BsonElement("name")]
        public string name{get;set;}
        [BsonElement("ingredients")]
        public List<Ingredient> ingredients{get;set;}= new List<Ingredient>();

        public DrugStatus DrugStatus { get; set; }


        public Drug(string name,List<Ingredient> ingredients){
            this.name = name; 
            this.ingredients = ingredients;
            this._id = ObjectId.GenerateNewId();
            this.DrugStatus = DrugStatus.ON_HOLD;
            }
    }


}