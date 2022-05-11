using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;

namespace HealthcareSystem.UI.Manager
{
    class ManagerService
    {
        public User loggedUser { get; set; }
        public ManagerControllers managerControllers { get; set; }
        public ManagerService(ManagerControllers managerControllers, User loggedUser)
        {
            this.loggedUser = loggedUser;
            this.managerControllers = managerControllers;
            
        }

        public void UI()
        {
            RoomService roomService = new RoomService(managerControllers.roomCollection);
            MoveEquipmentService moveService = new MoveEquipmentService(managerControllers.moveCollection, managerControllers.roomCollection);
            string option = " ";
            Console.WriteLine("1.Room CRUD");
            Console.WriteLine("2.Check Equipment");
            Console.WriteLine("3.Create Move Equipment Request");
            Console.WriteLine("4.(Test MoveEquipment)");
            while (true)
            {
                if (option == "x")
                {
                    return;
                }
                option = Console.ReadLine();
                if (option == "1")
                {
                    RoomCRUD();

                }
                if (option == "2")
                {
                   

                }
                if (option == "3")
                {
                    

                }
                if (option == "4")
                {
                   

                }
            }

        }

        public void RoomCRUD()
        {
            RoomService roomService = new RoomService(managerControllers.roomCollection);
            string option = "";
            Console.WriteLine("1.Add new room");
            Console.WriteLine("2.Print rooms");
            Console.WriteLine("3.Delete room");
            Console.WriteLine("4.(Test MoveEquipment))");
            Console.WriteLine("x.Exit");
           
        }






    }
}