using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.NotificationModel
{
    class NotificationFreeDayRepository:INotificationFreeDayRepository
    {

        public IMongoCollection<NotificationFreeDay> notificationCollection;
        public IMongoDatabase database;



        public NotificationFreeDayRepository()
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
            this.notificationCollection = database.GetCollection<NotificationFreeDay>("NotificationFreeDay");
        }



        public List<NotificationFreeDay> GetAll()
        {
            List<NotificationFreeDay> notifications = notificationCollection.Find(item => true).ToList();

            return notifications;
        }
        public void Insert(NotificationFreeDay n)
        {
            notificationCollection.InsertOne(n);
        }
        public NotificationFreeDay GetById(ObjectId id)
        {
            return notificationCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public void Delete(ObjectId id)
        {
            notificationCollection.DeleteOne(item => item._id == id);
        }

        public void Update(NotificationFreeDay n)
        {
            notificationCollection.ReplaceOne(item => item._id ==n._id,n);
        }



    }
}
