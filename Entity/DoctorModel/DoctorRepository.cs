using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.DoctorModel
{
    class DoctorRepository : IDoctorRepository
    {
        public IMongoCollection<Doctor> doctorCollection;
        IMongoDatabase database;
        public DoctorRepository(){
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
            this.doctorCollection = database.GetCollection<Doctor>("Doctors");
        }
        public List<Doctor> GetAll() {
            return doctorCollection.Find(item =>  true).ToList();
        }
        public void Insert(Doctor doctor){
            doctorCollection.InsertOne(doctor);
        }
        public Doctor GetByNameAndLastName(string name, string lastname)
        {
            return doctorCollection.Find(item => item.name == name & item.lastName == lastname).FirstOrDefault();
        }
        public Doctor GetById(ObjectId id) {
            return doctorCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public Doctor checkCredentials(string email, string password)
        {
            return doctorCollection.Find(item => item.password == password & item.email == email).FirstOrDefault();

        }
        public void Delete(ObjectId id) 
        {
            doctorCollection.DeleteOne(item => item._id == id);
        }
        public void Update(Doctor doctor)
        {
            doctorCollection.ReplaceOne(item => item._id == doctor._id, doctor);
        }

        public List<Doctor> FindDoctorsBySpecialisation(Specialisation s)
        {
            return doctorCollection.Find(item => item.specialisation == s).ToList();
        }

       
    }
    }


