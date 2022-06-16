using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace HealthcareSystem.Entity.NotificationModel
{
    class NotificationFreeDay
    {
        public ObjectId _id { get; set; }

        public String message { get; set; }
        public ObjectId requestId { get; set; }
        public NotificationFreeDay(String message, ObjectId requestId) {
            this.message = message;
            this.requestId = requestId;
            
        }

    }
}
