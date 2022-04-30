using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.DoctorModel;

namespace HealthcareSystem.RoleControllers
{
    class PatientControllers {
        public IMongoCollection<Apointment> apointmentCollection;
        public IMongoCollection<User> userCollection;
        public IMongoCollection<Room> roomCollection;
        public IMongoCollection<Doctor> doctorCollection;

        public PatientControllers(IMongoDatabase database){
            this.apointmentCollection = database.GetCollection<Apointment>("Apointments");
            this.userCollection = database.GetCollection<User>("Users");
            this.roomCollection = database.GetCollection<Room>("Rooms");
            this.doctorCollection = database.GetCollection<Doctor>("Doctors");
        }
    }
}