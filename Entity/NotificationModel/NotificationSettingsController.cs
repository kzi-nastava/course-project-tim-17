using MongoDB.Bson;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.NotificationModel
{
    class NotificationSettingsController
    {
        public IMongoCollection<NotificationSettings> notificationSettingsCollection;
        public NotificationSettingsController(IMongoDatabase database)
        {
            this.notificationSettingsCollection = database.GetCollection<NotificationSettings>("NotificationSettings");
        }
        public void InsertToCollection(ObjectId userId)
        {
            NotificationSettings notificationSettings = new NotificationSettings(userId, 1);
            notificationSettingsCollection.InsertOne(notificationSettings);
        }
        public NotificationSettings FindById(ObjectId id)
        {
            return notificationSettingsCollection.Find(item => item.userId == id).FirstOrDefault();
        }
        public List<NotificationSettings> getAllNotifications()
        {
            return notificationSettingsCollection.Find(item => true).ToList();
        }
        public void ChangeTimeById(ObjectId id, int time)
        {
            NotificationSettings notificationSettings = new NotificationSettings(id, time);
            notificationSettingsCollection.UpdateOne(item => item.userId == id, Builders<NotificationSettings>.Update.Set(item => item.time, time));
        }
    }
}
