 using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.RoomModel;
using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Functions;
namespace HealthcareSystem.Entity.HealthCardModel;

class HealthCard
{   
    public ObjectId _id { get; set; }
    [BsonElement("checks")]
    public List<ObjectId> checks { get; set; } 
    [BsonElement("height")]
    public double height { get; set; }
    [BsonElement("weight")]
    public double weight { get; set; }
    [BsonElement("patientId")]
    public ObjectId patientId { get; set; }
    [BsonElement("allergies")]
    public List<Ingredient> allergies { get; set; }
    [BsonElement("referrals")]
    public List<ObjectId> referrals { get; set; }

    public HealthCard(double height, double weight, ObjectId patientId, List<Ingredient> allergies)
    {
        this._id = ObjectId.GenerateNewId();
        this.height = height;
        this.weight = weight;
        this.patientId = patientId;
        this.checks = new List<ObjectId>(); 
        this.referrals = new List<ObjectId>();
        this.allergies = allergies;

    }

   
    
}