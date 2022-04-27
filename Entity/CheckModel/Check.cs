using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using HealthcareSystem.Entity.ApointmentModel;



namespace HealthcareSystem.Entity.CheckModel

{

    class Check
    {
        public ObjectId _id { get; set; }

        
        [BsonElement("appointmentId")]
        public ObjectId appointmentId { get; set; }

        [BsonElement("prescription")]
        public Prescription prescription { get; set; }

        [BsonElement("anamnesis")]
        public Anamnesis anamnesis { get; set; }






        public Check(ObjectId appointmentId, Anamnesis anamnesis, Prescription prescription)
        {
            this._id = ObjectId.GenerateNewId();
            this.anamnesis = anamnesis;
            this.prescription = prescription;
            this.appointmentId = appointmentId;
            
        }

    }

}
