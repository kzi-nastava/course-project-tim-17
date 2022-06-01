using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HealthcareSystem.Entity.EquipmentRequestModel
{
    class EquipmentRequest
    {
        public ObjectId _id { get; set; }
        [BsonElement("itemName")]
        public String ItemName { get; set; }
        [BsonElement("DateTime")]
        public DateTime DateTime { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }

     
        public EquipmentRequest(String itemName, DateTime datetime, int quantity)
        {
            this._id = ObjectId.GenerateNewId();
            this.ItemName = itemName;
            this.DateTime = datetime;
            this.Quantity = quantity;
        }

    }
}

