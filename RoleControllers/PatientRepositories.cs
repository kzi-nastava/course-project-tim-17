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

        public AppointmentRepository appointmentController;
        public DoctorController doctorController;
        public RoomRepository roomController;
        public UserActionController userActionController;
        public BlockedUserController blockedUserController;
        public AppointmentRequestsRepository appointmentRequestsController;
        public CheckAppointmentRequestController checkAppointmentRequestController;
        public CheckController checkController;
        public HealthCardRepository healthCardController;
        public DoctorSurveysRepository doctorSurveysController;
        public HospitalSurveysRepository hospitalSurveysController;
        public NotificationSettingsController notificationSettingsController;
        public DrugRepository drugController;
        public PatientRepositories(IMongoDatabase database)
        {
            this.appointmentController = new AppointmentRepository();
            this.doctorController = new DoctorController(database);
            this.roomController = new RoomRepository();
            this.userActionController = new UserActionController(database);
            this.blockedUserController = new BlockedUserController(database);
            this.appointmentRequestsController = new AppointmentRequestsRepository();
            this.checkAppointmentRequestController = new CheckAppointmentRequestController(database);
            this.checkController = new CheckController(database);
            this.healthCardController = new HealthCardRepository();
            this.doctorSurveysController = new DoctorSurveysRepository();
            this.hospitalSurveysController = new HospitalSurveysRepository();
            this.notificationSettingsController = new NotificationSettingsController(database);
            this.drugController = new DrugRepository();
        }
    }
}

