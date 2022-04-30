using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
namespace HealthcareSystem.Entity.RoomModel
{

    class RoomService
    {
        public RoomController roomController { get; set; }


        public RoomService(RoomController roomController)
        {

            this.roomController = roomController;
        }
        public void AddRoom()
        {
            Console.Write("Enter room name: ");
            string roomName = Console.ReadLine();
            int i = 0;

            RoomType roomType = ChooseRoomType(); ;

            try
            {
                Room room = new Room(roomName, roomType);
                roomController.InsertToCollection(room);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Argumets, please try again!");
                return;
            }


        }
        public void PrintRooms()
        {
            List<Room> rooms = roomController.GetAllRooms();
            foreach (Room room in rooms)
            {
                Console.WriteLine(room.ToString());
            }
        }

        public void DeleteRoom()
        {
            Console.Write("Enter room ID: ");
            try
            {
                ObjectId id = new ObjectId(Console.ReadLine());
                roomController.DeleteRoom(id);
                Console.WriteLine("Invalid id , please try again!");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid id,please try again!");
            }





        }
        public void UpdateRoom()
        {
            try
            {
                Console.Write("Enter room ID: ");
                ObjectId id = new ObjectId(Console.ReadLine());
                Room room = roomController.findById(id);
                if (room == null) throw new Exception("Room not found!");
                if (room != null)
                {
                    Console.WriteLine("1.Change room name : " + room.name);
                    Console.WriteLine("2.Change room type : " + room.type);
                    Console.WriteLine("x.Cancle");
                    Console.Write("Enter option: ");
                    string option = Console.ReadLine();
                    if (option == "x") return;
                    if (option == "1")
                    {
                        room.name = Console.ReadLine();
                    }
                    if (option == "2")
                    {


                        room.type = ChooseRoomType();
                    }
                    roomController.UpdateRoom(room);


                }


                else
                {
                    Console.Write("Room not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Tst()
        {
            Console.Write("Enter room ID: ");
            ObjectId id = new ObjectId(Console.ReadLine());
            Room room = roomController.findById(id);
            Console.WriteLine(room.ContainItem("Chair"));

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

        public RoomType ChooseRoomType()
        {
            int i = 1;
            foreach (RoomType et in Enum.GetValues(typeof(RoomType)))
            {
                Console.Write(i);
                Console.Write(".");
                Console.WriteLine(et);
                i++;
            }
            Console.Write("Enter room type:");
            string roomTypeOption = Console.ReadLine();
            int j = 1;
            RoomType roomType = new RoomType();
            foreach (RoomType et in Enum.GetValues(typeof(RoomType)))
            {
                if (j.ToString() == roomTypeOption) roomType = et;
                j++;
            }
            return roomType;
        }

        public void CheckRoomEquipment()
        {
            try
            {
                Console.WriteLine("1.Item name");
                Console.WriteLine("2.Item type");
                Console.WriteLine("3.Quantity");
                Console.WriteLine("4.Room Type");
                Console.WriteLine("x.Cancle");
                string option = Console.ReadLine();
                List<Room> rooms = roomController.GetAllRooms();
                List<string> result = new List<string>();
                if (option == "x") return;
                if (option == "1")
                {
                    string itemName = Console.ReadLine();
                    foreach (Room room in rooms)
                    {
                        foreach (Equipment equipment in room.equipments)
                        {
                            if (equipment.item == itemName)
                            {
                                string equipmentInfo = "In room : " + room.name +
                                " Equipment name : " + equipment.item + " Equipment type : "
                                + equipment.type + " Awaliable quantity : " + equipment.quantity.ToString();
                                result.Add(equipmentInfo);
                            }
                        }
                    }
                }
                if (option == "2")
                {




                    EquipmentType equipmentType = ChooseEquipmentType();


                    foreach (Room room in rooms)
                    {
                        foreach (Equipment equipment in room.equipments)
                        {
                            if (equipment.type == equipmentType)
                            {
                                string equipmentInfo = "In room : " + room.name +
                                " Equipment name : " + equipment.item + " Equipment type : "
                                + equipment.type + " Awaliable quantity : " + equipment.quantity.ToString();
                                result.Add(equipmentInfo);
                            }
                        }
                    }

                }
                if (option == "3")
                {
                    Console.WriteLine("1.Exact amont");
                    Console.WriteLine("2.In range");
                    Console.WriteLine("3.More than");
                    Console.Write("Enter option: ");
                    string optionForQuantity = Console.ReadLine();
                    int rangeStart = 0;
                    int rangeEnd = 0;

                    if (optionForQuantity == "1")
                    {
                        Console.Write("Enter amount: ");
                        rangeStart = int.Parse(Console.ReadLine());
                        rangeEnd = -1;
                    }
                    if (optionForQuantity == "2")
                    {
                        Console.Write("Enter start of range: ");
                        rangeStart = int.Parse(Console.ReadLine());
                        Console.Write("Enter end of range: ");
                        rangeEnd = int.Parse(Console.ReadLine());
                    }
                    if (optionForQuantity == "3")
                    {
                        Console.Write("Enter start of a range: ");
                        rangeStart = int.Parse(Console.ReadLine());
                        rangeEnd = -2;
                    }

                    foreach (Room room in rooms)
                    {
                        foreach (Equipment equipment in room.equipments)
                        {
                            if (QuantityAmountCheck(equipment.quantity, rangeStart, rangeEnd))
                            {
                                string equipmentInfo = "In room : " + room.name +
                                " Equipment name : " + equipment.item + " Equipment type : "
                                + equipment.type + " Awaliable quantity : " + equipment.quantity.ToString();
                                result.Add(equipmentInfo);
                            }
                        }
                    }
                }
                if (option == "4")
                {
                    RoomType roomType = ChooseRoomType();
                    foreach (Room room in rooms)
                    {
                        if (room.type == roomType)
                        {
                            foreach (Equipment equipment in room.equipments)
                            {
                                {
                                    string equipmentInfo = "In room : " + room.name +
                                    " Equipment name : " + equipment.item + " Equipment type : "
                                    + equipment.type + " Awaliable quantity : " + equipment.quantity.ToString();
                                    result.Add(equipmentInfo);
                                }
                            }
                        }
                    }
                }
                if (result.Count == 0)
                {
                    Console.WriteLine("No matches found!");
                }
                foreach (String res in result)
                {
                    Console.WriteLine(res);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;

            }




        }



        public bool QuantityAmountCheck(int quantity, int rangeStart, int rangeEnd)
        {
            if (rangeEnd == -1) if (rangeStart == quantity) return true;
            if (rangeEnd == -2) if (rangeStart < quantity) return true;
            if (rangeEnd > -1) if (rangeStart < quantity && rangeEnd > quantity) return true;
            return false;
        }


    }
}