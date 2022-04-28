using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.DrugModel;

namespace HealthcareSystem.RoleControllers 
{
    class ManagerControllers {
        public IMongoCollection<Room> roomCollection;
        public IMongoCollection<User> userCollection;
        public IMongoCollection<Drug> drugCollection;
        public IMongoCollection<DrugVerification> drugVerificationCollection;
        public IMongoCollection<Revision> revisionCollection;

        public ManagerControllers(IMongoDatabase database)
        {
            
            this.roomCollection = database.GetCollection<Room>("Rooms");
            this.userCollection = database.GetCollection<User>("Users");
            this.drugCollection = database.GetCollection<Drug>("Drugs");
            this.drugVerificationCollection = database.GetCollection<DrugVerification>("DrugVerifications");
            this.revisionCollection = database.GetCollection<Revision>("Revisions");
            
        }



    }
}