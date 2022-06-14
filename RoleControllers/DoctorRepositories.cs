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
        public DrugController drugController;
        public HealthCardController healthCardController;
        public CheckController checkController;
        public ApointmentController apointmentController;
        public UserController userController;
        public ReferralController referralController;
        public DoctorController doctorController;

        public DoctorRepositories(IMongoDatabase database)
        {
            this.roomController = new RoomRepository();
            this.drugController = new DrugController(database);
            this.healthCardController = new HealthCardController(database);
            this.checkController = new CheckController(database);
            this.apointmentController = new ApointmentController(database);
            this.userController = new UserController(database);
            this.doctorController = new DoctorController(database);
            this.referralController = new ReferralController(database);
        }
    }
}

    