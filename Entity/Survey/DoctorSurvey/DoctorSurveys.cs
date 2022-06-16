using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;

namespace HealthcareSystem.Entity.Survey.DoctorSurvey
{
    class DoctorSurveys
    {
        public ObjectId _id { get; set; }
        [BsonElement("doctorId")]
        public ObjectId doctorId { get; set; }
        [BsonElement("quality")]
        public Mark quality { get; set; }
        [BsonElement("recommendation")]
        public Mark recommendation { get; set; }
        [BsonElement("comment")]
        public string comment { get; set; }

        public DoctorSurveys(ObjectId doctorId, Mark quality, Mark recommendation, string comment)
        {
            this._id = ObjectId.GenerateNewId();
            this.doctorId = doctorId;
            this.quality = quality;
            this.recommendation = recommendation;
            this.comment = comment;
        }
    }
}
