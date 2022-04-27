using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.Doctor
{
    class DoctorController
    {
        public IMongoCollection<Doctor> doctorCollection;
        public DoctorController(IMongoDatabase database){
            this.doctorCollection = database.GetCollection<Doctor>("Doctors");
            
            }
        public void getAllDoctors() {
            List<Doctor> doctors = doctorCollection.Find(item =>  true).ToList();

            foreach(Doctor doctor in doctors) {
                Console.WriteLine(doctor.name);
            }
        }
        public void InsertToCollection(Doctor doctor){
            doctorCollection.InsertOne(doctor);
        }
        
        }
    }


