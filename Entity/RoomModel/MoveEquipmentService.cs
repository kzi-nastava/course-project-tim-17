using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
namespace HealthcareSystem.Entity.RoomModel
{

    class MoveEquipmentService
    {
        public MoveEquipmentRequestController moveController { get; set; }
        public RoomController roomController { get; set; }


        public MoveEquipmentService(MoveEquipmentRequestController moveController, RoomController roomController)
        {

            this.moveController = moveController;
            this.roomController = roomController;


        }
        public void CreateMoveEquipmentRequest()
        {
            try
            {
                Console.Write("Enter move date and time(year-month-day-hour-minute-second(without zeros)): ");
                string moveDate = Console.ReadLine();
                string[] moveDateSplit = moveDate.Split("-");

                DateTime date = new DateTime(int.Parse(moveDateSplit[0]), int.Parse(moveDateSplit[1]),
                int.Parse(moveDateSplit[2]), int.Parse(moveDateSplit[3]), int.Parse(moveDateSplit[4]),
                int.Parse(moveDateSplit[5]));
                Console.Write("Enter ID from the room u want to move equipment from: ");
                ObjectId roomFirstId = new ObjectId(Console.ReadLine());
                Console.Write("Enter ID from the room u want to move equipment in: ");
                ObjectId roomSecondId = new ObjectId(Console.ReadLine());
                Equipment equipment = CreateEquipment();
                MoveEquipmentRequest mer = new MoveEquipmentRequest(date, roomFirstId, roomSecondId, equipment);
                moveController.InsertToCollection(mer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }



        }
        public void MoveEquipment()
        {
            List<MoveEquipmentRequest> moveEquipmentRequests = moveController.GetAllMoveEquipmentRequests();
            DateTime currentTime = DateTime.Now;
            foreach (MoveEquipmentRequest moveEquipmentRequest in moveEquipmentRequests)
            {

                if (currentTime > moveEquipmentRequest.moveDate)
                {
                    Room roomFrom = roomController.findById(moveEquipmentRequest.moveFrom);
                    if (roomFrom.CheckIfEquipmentIsAvaliable(moveEquipmentRequest.equipment))
                    {
                        Room roomTo = roomController.findById(moveEquipmentRequest.moveTo);
                        if (roomTo.ContainItem(moveEquipmentRequest.equipment.item))
                        {
                            changeQuantityFromEquipment(roomTo, moveEquipmentRequest, "add");
                            changeQuantityFromEquipment(roomFrom, moveEquipmentRequest, "sub");
                            moveController.DeleteMoveEquipmentRequest(moveEquipmentRequest._id);
                        }
                        else
                        {
                            roomController.addEquipment(roomTo, moveEquipmentRequest.equipment);
                            changeQuantityFromEquipment(roomFrom, moveEquipmentRequest, "sub");
                            moveController.DeleteMoveEquipmentRequest(moveEquipmentRequest._id);

                        }

                    }
                    else
                    {
                        Console.WriteLine("Equipment Unavaliable");
                    }

                }

            }
        }



        public void changeQuantityFromEquipment(Room room, MoveEquipmentRequest moveEquipmentRequest, string operation)
        {
            for (int i = 0; i < room.equipments.Count(); i++)
            {
                if (room.equipments[i].item == moveEquipmentRequest.equipment.item)
                {
                    if (operation == "sub")
                        room.equipments[i].quantity = room.equipments[i].quantity - moveEquipmentRequest.equipment.quantity;
                    if (operation == "add")
                        room.equipments[i].quantity = room.equipments[i].quantity + moveEquipmentRequest.equipment.quantity;
                    roomController.UpdateRoom(room);
                }
            }

        }
        public void addEquipmentToWarehouse()
        {


            Room room = roomController.getWarehouse();
            Equipment e = CreateEquipment();
            roomController.addEquipment(room, e);



        }

        public void addEquipmentToRoom()
        {

            Console.Write("Enter room id: ");
            Room room = roomController.findById(new ObjectId(Console.ReadLine()));
            Equipment e = CreateEquipment();
            roomController.addEquipment(room, e);



        }

        public Equipment CreateEquipment()
        {
            Console.Write("Enter item name: ");

            string item = Console.ReadLine();
            EquipmentType equipmentType = ChooseEquipmentType();
            Console.WriteLine("1.Yes");
            Console.WriteLine("2.No");
            Console.Write("Is item dynamic?: ");
            string dynamicOption = Console.ReadLine();
            bool isDynamic = false;
            if (dynamicOption == "1") isDynamic = true;
            Console.Write("Quantity?: ");
            int quantity = int.Parse(Console.ReadLine());
            return new Equipment(equipmentType, item, quantity, isDynamic);
        }

        public EquipmentType ChooseEquipmentType()
        {
            int i = 1;
            foreach (EquipmentType et in Enum.GetValues(typeof(EquipmentType)))
            {
                Console.Write(i);
                Console.Write(".");
                Console.WriteLine(et);
                i++;
            }
            Console.Write("Enter equipment type:");
            string equipmentTypeOption = Console.ReadLine();
            int j = 1;
            EquipmentType equipmentType = new EquipmentType();
            foreach (EquipmentType et in Enum.GetValues(typeof(EquipmentType)))
            {
                if (j.ToString() == equipmentTypeOption) equipmentType = et;
                j++;
            }
            return equipmentType;
        }

    }
}