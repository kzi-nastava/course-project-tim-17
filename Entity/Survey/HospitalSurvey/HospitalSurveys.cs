using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;

namespace HealthcareSystem.Entity.Survey.HospitalSurvey
{
    class HospitalSurveys
    {
        public ObjectId _id { get; set; }
        [BsonElement("quality")]
        public Mark quality { get; set; }
        [BsonElement("cleanliness")]
        public Mark cleanliness { get; set; }
        [BsonElement("satisfaction")]
        public Mark satisfaction { get; set; }
        [BsonElement("comment")]

        public string comment { get; set; }
        public HospitalSurveys(Mark quality, Mark cleanliness, Mark satisfaction, string comment)
        {
            this._id = ObjectId.GenerateNewId();
            this.quality = quality;
            this.cleanliness = cleanliness;
            this.satisfaction = satisfaction;
            this.comment = comment;
            
        }
    }
}
