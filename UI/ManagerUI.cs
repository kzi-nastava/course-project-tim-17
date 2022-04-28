using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.DrugModel;

namespace HealthcareSystem.UI
{
    class ManagerUI
    {
        public User loggedUser { get; set; }
        public IMongoCollection<Room> roomCollection;
        public IMongoCollection<User> userCollection;
        public IMongoCollection<Drug> drugCollection;
        public IMongoCollection<DrugVerification> drugVerificationCollection;
        public IMongoCollection<Revision> revisionCollection;

        public ManagerUI(IMongoDatabase database, User loggedUser)
        {
            this.loggedUser = loggedUser;
            this.roomCollection = database.GetCollection<Room>("Rooms");
            this.userCollection = database.GetCollection<User>("Users");
            this.drugCollection = database.GetCollection<Drug>("Drugs");
            this.drugVerificationCollection = database.GetCollection<DrugVerification>("DrugVerifications");
            this.revisionCollection = database.GetCollection<Revision>("Revisions");
            this.UI();
        }

        public void UI() { 
            string option = " ";
            while (true) {
                if (option == "x") {
                    return;
                }
                option = Console.ReadLine();
                if (option == "1") {
                    Console.WriteLine("Uradi nesto");
                }
            }

        }




    }
}