namespace HealthcareSystem.Entity.DrugModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
class Revision
{
    public ObjectId _id { get; set; }
    [BsonElement("description")]
    public string desctription { get; set; }
    [BsonElement("drugVerificationId")]
    public ObjectId drugId { get; set; }

    public Revision(string desctription, ObjectId drugVerificationId)
    {
        _id = ObjectId.GenerateNewId();
        this.desctription = desctription;
        this.drugId = drugVerificationId;
    }

}