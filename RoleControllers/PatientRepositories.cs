using MongoDB.Driver;

using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.UserActionModel;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.HealthCardModel;

namespace HealthcareSystem.RoleControllers
{
    class PatientRepositories
    {
        
        public PatientControllers patientController;
        public ApointmentController appointmentController;
        public DoctorController doctorController;
        public RoomController roomController;
        public UserActionController userActionController;
        public BlockedUserController blockedUserController;
        public AppointmentRequestsController appointmentRequestsController;
        public CheckAppointmentRequestController checkAppointmentRequestController;
        public CheckController checkController;
        public HealthCardController healthCardController;
        public PatientRepositories(IMongoDatabase database)
        {
            this.patientController = new PatientControllers(database);
            this.appointmentController = new ApointmentController(database);
            this.doctorController = new DoctorController(database);
            this.roomController = new RoomController(database);
            this.userActionController = new UserActionController(database);
            this.blockedUserController = new BlockedUserController(database);
            this.appointmentRequestsController = new AppointmentRequestsController(database);
            this.checkAppointmentRequestController = new CheckAppointmentRequestController(database);
            this.checkController = new CheckController(database);
            this.healthCardController = new HealthCardController(database);
        }
    }
}

