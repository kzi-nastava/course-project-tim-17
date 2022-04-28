using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.RoleControllers;

namespace HealthcareSystem.UI
{
    class ManagerUI
    {
        public User loggedUser { get; set; }
        public ManagerControllers managerControllers {get;set;}
        public ManagerUI(ManagerControllers managerControllers, User loggedUser)
        {
            this.loggedUser = loggedUser;
            this.managerControllers = managerControllers;
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