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
        public void getAllAppointments() {
            List<Apointment> apointments = apointmentCollection.Find(item =>  true).ToList();

            foreach(Apointment apointment in apointments) {
                Console.WriteLine(apointment.patientId);
            }
        }
        public void InsertToCollection(Apointment apointment){
            apointmentCollection.InsertOne(apointment);
        }
        
        }
    }


