using MongoDB.Bson;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.NotificationModel
{
    class NotificationSettingsRepository : INotificationSettingsRepository
    {
        public IMongoCollection<NotificationSettings> notificationSettingsCollection;
        public IMongoDatabase database;
        public NotificationSettingsRepository()
        {
            GetDatabase();
            GetCollection();
        }

        public void GetDatabase()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Tim17:UXGhApWVw9oc6VGg@cluster0.se6mz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            this.database = client.GetDatabase("USI");
        }

        public void GetCollection()
        {
            this.notificationSettingsCollection = database.GetCollection<NotificationSettings>("NotificationSettings");
        }

        public List<NotificationSettings> GetAll()
        {
            return notificationSettingsCollection.Find(item => true).ToList();
        }
        public void Insert(NotificationSettings notificationSettings)
        {
            notificationSettingsCollection.InsertOne(notificationSettings);
        }
        public void Delete(ObjectId id)
        {
            notificationSettingsCollection.DeleteOne(item => item._id == id);
        }
        public void Update(NotificationSettings notificationSettings)
        {
            notificationSettingsCollection.ReplaceOne(item => item._id == notificationSettings._id, notificationSettings);
        }
        public NotificationSettings GetById(ObjectId id)
        {
            return notificationSettingsCollection.Find(item => item.userId == id).FirstOrDefault();
        }

        public void ChangeTimeById(ObjectId id, int time)
        {
            NotificationSettings notificationSettings = new NotificationSettings(id, time);
            notificationSettingsCollection.UpdateOne(item => item.userId == id, Builders<NotificationSettings>.Update.Set(item => item.time, time));
        }
    }
}
