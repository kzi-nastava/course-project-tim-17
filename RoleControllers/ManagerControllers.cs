using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.DrugModel;

namespace HealthcareSystem.RoleControllers 
{
    class ManagerControllers {
        public RoomController roomCollection;
        public UserController userCollection;
        public DrugController drugCollection;
        public DrugVerificationController drugVerificationCollection;
        public RevisionController revisionCollection;

        public MoveEquipmentRequestController moveCollection;

        public ManagerControllers(IMongoDatabase database)
        {
            
            this.roomCollection = new RoomController(database);
            this.userCollection = new UserController(database);
            this.drugCollection = new DrugController(database);
            this.drugVerificationCollection = new DrugVerificationController(database);
            this.revisionCollection = new RevisionController(database);
            this.moveCollection = new MoveEquipmentRequestController(database);
            
        }



    }
}