using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.DoctorModel
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
        public Doctor findById(ObjectId id) {
            return doctorCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public Doctor checkCredentials(string email, string password)
        {
            return doctorCollection.Find(item => item.password == password & item.email == email).FirstOrDefault();

        }
        
        

    }
    }


