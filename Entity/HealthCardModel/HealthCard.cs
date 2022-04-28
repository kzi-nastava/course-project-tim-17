using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HealthcareSystem.Entity.HealthCardModel;

class HealthCard
{   
    public ObjectId _id { get; set; }
    [BsonElement("checks")]
    public List<ObjectId> checks { get; set; } = new List<ObjectId>();
    [BsonElement("height")]
    public double height { get; set; }
    [BsonElement("weight")]
    public double weight { get; set; }
    [BsonElement("patientId")]
    public ObjectId patientId { get; set; }


    public HealthCard(double height, double weight, ObjectId patientId)
    {
        this._id = ObjectId.GenerateNewId();
        this.height = height;
        this.weight = weight;
        this.patientId = patientId;
    }
    
    
}