using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserModel;


namespace HealthcareSystem.Entity.ApointmentModel

{

    class Apointment
    {
        public ObjectId _id { get; set; }
        [BsonElement("dateTime")]
        public DateTime dateTime{ get; set; }
        [BsonElement("type")]
        public ApointmentType type{ get; set; }
        [BsonElement("doctorId")]
        public ObjectId doctorId{ get; set; }

        [BsonElement("roomId")]
        public ObjectId roomId{ get; set; }
        
        [BsonElement("patientId")]
        public ObjectId patientId{ get; set; }
        

        public Apointment(DateTime dateTime ,ApointmentType apointmentType,ObjectId doctor,ObjectId room,ObjectId user) {
            this._id = ObjectId.GenerateNewId();
            this.dateTime = dateTime;
            this.type = apointmentType;
            this.doctorId = doctor;
            this.roomId = room;
            this.patientId = user;
            
        }












    }

}
