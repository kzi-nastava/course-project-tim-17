using MongoDB.Bson;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.AppointmentRequestsModel
{
    class AppointmentRequestsController
    {
        public IMongoCollection<AppointmentRequests> appointmentRequestCollection;
        public AppointmentRequestsController(IMongoDatabase database){
            this.appointmentRequestCollection = database.GetCollection<AppointmentRequests>("AppointmentRequests");
        }

        public void InsertToCollection(AppointmentRequests appointmentRequest){
            appointmentRequestCollection.InsertOne(appointmentRequest);
        }

        public AppointmentRequests FindById(ObjectId id)
        {
            return appointmentRequestCollection.Find(item => item._id == id).FirstOrDefault();
        }


    }
}