using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HealthcareSystem.Entity.CheckAppointmentRequestModel
{
    class CheckAppointementRequest { 
        public ObjectId _id { get; set; }
        [BsonElement("appointmentId")]
        public ObjectId appointmentId { get; set; }
       
        [BsonElement("status")]
        public Status status{ get; set; }

        public RequestState RequestState { get; set; }

        public CheckAppointementRequest(ObjectId appointementId, RequestState state)
        {
            this._id = ObjectId.GenerateNewId();
            this.status = Status.ON_HOLD;
            this.appointmentId = appointementId;
            this.RequestState = state;
        }

    }

        

}
