using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
namespace HealthcareSystem.Entity.DoctorModel;

class FreeDayRequest
{
    public ObjectId _id { get; set; }
    [BsonElement("startOf")]
    public DateTime startOf { get; set; }
    [BsonElement("endOf")]
    public DateTime endOf { get; set; }
    [BsonElement("doctorId")]
    public ObjectId doctorId { get; set; }
    [BsonElement("description")]
    public string description { get; set; }

    [BsonElement("status")]
    public Status status { get; set; }

    public FreeDayRequest(DateTime startOf, DateTime endOf, ObjectId doctorId, string description)
    {
        _id = ObjectId.GenerateNewId();
        this.startOf = startOf;
        this.endOf = endOf;
        this.doctorId = doctorId;
        this.status = Status.ON_HOLD;
        this.description = description;
    }
}