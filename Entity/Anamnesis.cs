using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HealthcareSystem.Entity

{

    class Anamnesis
    {
        public ObjectId _id { get; set; }
        [BsonElement("description")]
        public string description{ get; set; }
        [BsonElement("symptons")]
        public string symptoms{ get; set; }
        [BsonElement("diagnosis")]
        public string diagnosis{ get; set; }






        public Anamnesis(string description, string symptoms, string diagnosis)
        {
            this.description = description;
            this.symptoms = symptoms;
            this.diagnosis = diagnosis;
            this._id = ObjectId.GenerateNewId();
        }

    }

}
