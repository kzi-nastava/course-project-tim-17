using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.Enumerations;

namespace HealthcareSystem.Entity.UserActionModel
{
    class UserAction{
        public ObjectId _id { get; set; }
        [BsonElement("userId")]
        public ObjectId userId{ get; set; }
        [BsonElement("apointment")]
        public ObjectId apointment {get; set;}
        [BsonElement("dateTime")]
        public DateTime dateTime{get; set;}
        [BsonElement("status")]
        public ActionStatus actionStatus {get; set;}
        

        public UserAction(ObjectId userId, ObjectId apointment, DateTime dateTime, ActionStatus actionStatus){
            this._id = ObjectId.GenerateNewId();
            this.userId = userId;
            this.apointment = apointment;
            this.dateTime = dateTime;
            this.actionStatus = actionStatus;
        }
    }
}