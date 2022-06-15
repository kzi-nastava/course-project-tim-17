using MongoDB.Bson;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.AppointmentRequestsModel
{
    class AppointmentRequestsRepository : IAppointmentRequestRepository
    {
        public IMongoCollection<AppointmentRequests> appointmentRequestsCollection;
        public IMongoDatabase database;
        public AppointmentRequestsRepository(){
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
            this.appointmentRequestsCollection = database.GetCollection<AppointmentRequests>("AppointmentRequests");
        }

        public List<AppointmentRequests> GetAll()
        {
            List<AppointmentRequests> apointments = appointmentRequestsCollection.Find(item => true).ToList();
            return apointments;
        }

        public void Update(AppointmentRequests apointment)
        {
            appointmentRequestsCollection.ReplaceOne(item => item._id == apointment._id, apointment);
        }

        public void Insert(AppointmentRequests appointmentRequest){
            appointmentRequestsCollection.InsertOne(appointmentRequest);
        }

        public void Delete(ObjectId id)
        {
            appointmentRequestsCollection.DeleteOne(item => item._id == id);
        }

        public AppointmentRequests GetById(ObjectId id)
        {
            return appointmentRequestsCollection.Find(item => item._id == id).FirstOrDefault();
        }


    }
}