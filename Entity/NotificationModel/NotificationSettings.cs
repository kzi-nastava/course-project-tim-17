using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.NotificationModel
{
    internal class NotificationSettings
    {
        public ObjectId _id { get; set; }
        [BsonElement("userId")]
        public ObjectId userId { get; set; }
        [BsonElement("hours")]
        public int time { get; set; }

        public NotificationSettings(ObjectId userId, int time)
        {
            _id = ObjectId.GenerateNewId();
            this.userId = userId;
            this.time = time;
        }
    }
}
