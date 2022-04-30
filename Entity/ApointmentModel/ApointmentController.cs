using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.ApointmentModel
{
    class ApointmentController
    {
        public IMongoCollection<Apointment> apointmentCollection;
        public ApointmentController(IMongoDatabase database){
            this.apointmentCollection = database.GetCollection<Apointment>("Apointments");
        }
        public List<Apointment> getAllAppointments() {
            return apointmentCollection.Find(item =>  true).ToList();

        }
        public void InsertToCollection(Apointment apointment){
            apointmentCollection.InsertOne(apointment);
        }

        public List<Apointment> findAllByUser(ObjectId id) {
            return apointmentCollection.Find(item => item.patientId == id).ToList();
        }

        public void replaceApointment(Apointment apointment) 
        {
            apointmentCollection.ReplaceOne(item => item._id == apointment._id, apointment);
        }
        public void DeleteApointment(Apointment apointment)
        {
            apointmentCollection.DeleteOne(item => item._id == apointment._id);
        }
    }
}


