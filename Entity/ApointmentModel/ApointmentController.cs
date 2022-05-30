using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.ApointmentModel
{
    class ApointmentController
    {
        public IMongoCollection<Apointment> apointmentCollection;
        private IMongoDatabase database;

        public ApointmentController(IMongoDatabase database){
            this.apointmentCollection = database.GetCollection<Apointment>("Apointments");
            this.database = database;
            
            }
        public List<Apointment> getAllAppointments() {
            List<Apointment> apointments = apointmentCollection.Find(item =>  true).ToList();

            return apointments;
        }
        public void InsertToCollection(Apointment apointment){
            apointmentCollection.InsertOne(apointment);
        }

        public void UpdateApointment(Apointment apointment)
        {
            apointmentCollection.ReplaceOne(item => item._id == apointment._id, apointment);
        }

        public List<Apointment> findAllByUser(ObjectId id) {
            return apointmentCollection.Find(item => item.patientId == id).ToList();
        }

        public List<Apointment> FindAllByDoctor(ObjectId id)
        {
            return apointmentCollection.Find(item => item.doctorId == id).ToList();
        }

        public void replaceApointment(Apointment apointment) 
        {
            apointmentCollection.ReplaceOne(item => item._id == apointment._id, apointment);
        }

        public void DeleteApointment(Apointment apointment)
        {
            apointmentCollection.DeleteOne(item => item._id == apointment._id);
        }

        public Apointment FindById(ObjectId id) {
            return apointmentCollection.Find(item => item._id == id).FirstOrDefault();
        }

        public void DeleteApointmentByPatientId(ObjectId id)
        {
            List<Apointment> apointments = apointmentCollection.Find(item => item.patientId == id).ToList();
            foreach (Apointment a in apointments)
            {
                apointmentCollection.DeleteOne(item => item._id == a._id);
            }

        }

       
    }
}


