using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.ApointmentModel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.CheckAppointmentRequestModel
{
    class CheckAppointmentRequestRepository:ICheckAppointmentRequestRepository
    {

        public IMongoCollection<CheckAppointementRequest> checkAppointmentRequestCollection;
        public IMongoDatabase database;

        public CheckAppointmentRequestRepository()
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
            this.checkAppointmentRequestCollection = database.GetCollection<CheckAppointementRequest>("CheckAppointmentRequests");
        }
        public List<CheckAppointementRequest> GetAllCheckAppointmentRequests()
        {
            List<CheckAppointementRequest> crs = checkAppointmentRequestCollection.Find(item => true).ToList();

            return crs;
        }
        public void Insert(CheckAppointementRequest cr)
        {
            checkAppointmentRequestCollection.InsertOne(cr);
        }
        public CheckAppointementRequest GetById(ObjectId id)
        {
            return checkAppointmentRequestCollection.Find(item => item._id == id).FirstOrDefault();
        }

       
        public void Delete(ObjectId id)
        {
            checkAppointmentRequestCollection.DeleteOne(item => item._id == id);
        }

   

       public void Update(CheckAppointementRequest cr)
        {

            checkAppointmentRequestCollection.ReplaceOne(item => item._id == cr._id, cr);
        }

        public List<CheckAppointementRequest> GetAll()
        {
            List<CheckAppointementRequest> checkAppointementRequests = checkAppointmentRequestCollection.Find(item => true).ToList();

            return checkAppointementRequests;
        }
    }
}
