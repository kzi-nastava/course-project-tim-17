using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.AppointmentRequestsModel
{
    class AppointmentRequestsController
    {
        public IMongoCollection<AppointmentRequests> appointmentRequestCollection;
        public AppointmentRequestsController(IMongoDatabase database){
            this.appointmentRequestCollection = database.GetCollection<AppointmentRequests>("AppointmentRequests");
        }

        public List<AppointmentRequests> findAllByUser(ObjectId id) {
            return appointmentRequestCollection.Find(item => item.patientId == id).ToList();
        }

        public void InsertToCollection(AppointmentRequests appointmentRequest){
            appointmentRequestCollection.InsertOne(appointmentRequest);
        }
    }
}