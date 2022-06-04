using HealthcareSystem.Entity.Enumerations;
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
        public List<Doctor> getAllDoctors() {
            return doctorCollection.Find(item =>  true).ToList();
        }
        public void InsertToCollection(Doctor doctor){
            doctorCollection.InsertOne(doctor);
        }
        public Doctor findByName(string name, string lastname)
        {
            return doctorCollection.Find(item => item.name == name & item.lastName == lastname).FirstOrDefault();
        }
        public Doctor findById(ObjectId id) {
            return doctorCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public Doctor checkCredentials(string email, string password)
        {
            return doctorCollection.Find(item => item.password == password & item.email == email).FirstOrDefault();

        }

        public List<Doctor> FindDoctorsBySpecialisation(Specialisation s)
        {
            return doctorCollection.Find(item => item.specialisation == s).ToList();
        }

       
    }
    }


