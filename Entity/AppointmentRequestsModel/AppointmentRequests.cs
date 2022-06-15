using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserModel;


namespace HealthcareSystem.Entity.AppointmentRequestsModel

{

    class AppointmentRequests
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
        
        [BsonElement("originalAppointmentId")]
        public ObjectId appointmentId{get; set;}
        
        public AppointmentRequests(DateTime dateTime ,ApointmentType apointmentType,ObjectId doctor,ObjectId room,ObjectId appointmentId, ObjectId user) {
            this._id = ObjectId.GenerateNewId();
            this.dateTime = dateTime;
            this.type = apointmentType;
            this.doctorId = doctor;
            this.roomId = room;
            this.appointmentId = appointmentId;
            this.patientId = user;
        }
    }
}
