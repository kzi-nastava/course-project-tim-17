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
        [BsonElement("specialization")]
        public Specialisation sp { get; set; }

        public Referral(ObjectId doctorId, Specialisation spec)
        {
            this._id = ObjectId.GenerateNewId();
          
            this.doctorId = doctorId;
            this.sp = spec;
        }


    }
}
