using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.ReferralModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;

namespace HealthcareSystem.RoleControllers
{
    class DoctorRepositories
    {
        public RoomRepository roomController;
        public DrugRepository drugController;
        public HealthCardRepository healthCardController;
        public CheckRepository checkController;
        public AppointmentRepository apointmentController;
        public UserController userController;
        public ReferralRepository referralController;
        public DoctorRepository doctorController;

        public DoctorRepositories(IMongoDatabase database)
        {
            this.roomController = new RoomRepository();
            this.drugController = new DrugRepository();
            this.healthCardController = new HealthCardRepository();
            this.checkController = new CheckRepository();
            this.apointmentController = new AppointmentRepository();
            this.userController = new UserController(database);
            this.doctorController = new DoctorRepository();
            this.referralController = new ReferralRepository();
        }
    }
}

    