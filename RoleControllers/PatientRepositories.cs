using MongoDB.Driver;

using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.UserActionModel;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.Survey.DoctorSurvey;
using HealthcareSystem.Entity.Survey.HospitalSurvey;
using HealthcareSystem.Entity.NotificationModel;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;

namespace HealthcareSystem.RoleControllers
{
    class PatientRepositories
    {

        public ApointmentController appointmentController;
        public DoctorController doctorController;
        public RoomRepository roomController;
        public UserActionController userActionController;
        public BlockedUserController blockedUserController;
        public AppointmentRequestsController appointmentRequestsController;
        public CheckAppointmentRequestController checkAppointmentRequestController;
        public CheckController checkController;
        public HealthCardController healthCardController;
        public DoctorSurveysController doctorSurveysController;
        public HospitalSurveysController hospitalSurveysController;
        public NotificationSettingsController notificationSettingsController;
        public DrugController drugController;
        public PatientRepositories(IMongoDatabase database)
        {
            this.appointmentController = new ApointmentController(database);
            this.doctorController = new DoctorController(database);
            this.roomController = new RoomRepository();
            this.userActionController = new UserActionController(database);
            this.blockedUserController = new BlockedUserController(database);
            this.appointmentRequestsController = new AppointmentRequestsController(database);
            this.checkAppointmentRequestController = new CheckAppointmentRequestController(database);
            this.checkController = new CheckController(database);
            this.healthCardController = new HealthCardController(database);
            this.doctorSurveysController = new DoctorSurveysController(database);
            this.hospitalSurveysController = new HospitalSurveysController(database);
            this.notificationSettingsController = new NotificationSettingsController(database);
            this.drugController = new DrugController(database);
        }
    }
}

