using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.RoomModel;


namespace HealthcareSystem.RoleControllers
{
    class DoctorRepositories
    {
        public RoomController roomController;
        public DrugController drugController;
        public HealthCardController healthCardController;
        public CheckController checkController;
        public ApointmentController apointmentController;
        public UserController userController;

        public DoctorRepositories(IMongoDatabase database)
        {
            this.roomController = new RoomController(database);
            this.drugController = new DrugController(database);
            this.healthCardController = new HealthCardController(database);
            this.checkController = new CheckController(database);
            this.apointmentController = new ApointmentController(database);
            this.userController = new UserController(database);
        }
    }
}

    