using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HealthcareSystem.Entity.ReferralModel
{
    class Referral
    {
        public ObjectId _id { get; set; }
        [BsonElement("doctorId")]
        public ObjectId doctorId { get; set; }
        [BsonElement("patientId")]
        public ObjectId patientId { get; set; }
        [BsonElement("specialization")]
        public Specialisation specialization { get; set; }

        public Referral(ObjectId doctorId,ObjectId patientId, Specialisation spec)
        {
            this._id = ObjectId.GenerateNewId();
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.specialization = spec;
        }


    }
}
