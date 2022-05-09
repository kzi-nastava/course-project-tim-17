using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;

namespace HealthcareSystem.UI
{
    class ManagerUI
    {
        public User loggedUser { get; set; }
        public ManagerControllers managerControllers { get; set; }
        public ManagerUI(ManagerControllers managerControllers, User loggedUser)
        {
            this.loggedUser = loggedUser;
            this.managerControllers = managerControllers;
            this.UI();
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
                    roomService.CheckRoomEquipment();

                }
                if (option == "3")
                {
                    moveService.CreateMoveEquipmentRequest();

                }
                if (option == "4")
                {
                    moveService.MoveEquipment();

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
            while (true)
            {
                option = Console.ReadLine();
                if (option == "x") break;
                if (option == "1") { roomService.AddRoom(); }
                if (option == "2") { roomService.PrintRooms(); }
                if (option == "3") { roomService.DeleteRoom(); }
                if (option == "4") { roomService.UpdateRoom(); }
            }
        }






    }
}