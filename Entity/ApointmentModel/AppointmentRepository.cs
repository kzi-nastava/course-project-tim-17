using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.ApointmentModel
{
    class AppointmentRepository : IAppointmentRepository
    {
        public IMongoCollection<Appointment> appointmentCollection;
        public IMongoDatabase database;

        public AppointmentRepository()
        {
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
            this.appointmentCollection = database.GetCollection<Appointment>("Apointments");
        }
        public List<Appointment> GetAll() {
            List<Appointment> apointments = appointmentCollection.Find(item =>  true).ToList();

            return apointments;
        }
        public void Insert(Appointment apointment){
            appointmentCollection.InsertOne(apointment);
        }

        public void Update(Appointment apointment)
        {
            appointmentCollection.ReplaceOne(item => item._id == apointment._id, apointment);
        }

        public List<Appointment> GetAllByUser(ObjectId id) {
            return appointmentCollection.Find(item => item.patientId == id).ToList();
        }

        public List<Appointment> GetAllByDoctor(ObjectId id)
        {
            return appointmentCollection.Find(item => item.doctorId == id).ToList();
        }

        public void Delete(ObjectId id)
        {
            appointmentCollection.DeleteOne(item => item._id == id);
        }

        public Appointment GetById(ObjectId id) {
            return appointmentCollection.Find(item => item._id == id).FirstOrDefault();
        }

        public void DeleteApointmentByPatientId(ObjectId id)
        {
            List<Appointment> apointments = appointmentCollection.Find(item => item.patientId == id).ToList();
            foreach (Appointment a in apointments)
            {
                appointmentCollection.DeleteOne(item => item._id == a._id);
            }

        }
        public Appointment GetAppointmentByDateTime(DateTime dateTime)
        {
           return appointmentCollection.Find(item => item.dateTime == dateTime).FirstOrDefault();
        }

        public Appointment GetAppointmentByDateTimeAndRoom(Room room, DateTime dateTime)
        {
            return appointmentCollection.Find(item => item.dateTime == dateTime & item.roomId == room._id).FirstOrDefault();
        }
        public List<Appointment> GetDoctorSchedule(ObjectId doctorId, DateTime startingDate, DateTime endingDate)
        {
            return appointmentCollection.Find(item => item.doctorId == doctorId & item.dateTime > startingDate & item.dateTime <endingDate).ToList();
        }

       
    }
}


