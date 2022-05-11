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
        public void AddRoom(string roomName, RoomType roomType)
        {

            Room room = new Room(roomName, roomType);
            roomController.InsertToCollection(room);



        }
        public void PrintRooms()
        {
            List<Room> rooms = roomController.GetAllRooms();
            foreach (Room room in rooms)
            {
                Console.WriteLine(room.ToString());
            }
        }

        public void DeleteRoom(string id)
        {
            roomController.DeleteRoom(new ObjectId(id));


        }
        public void UpdateRoom(Room room)
        {

            roomController.UpdateRoom(room);


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

        public List<Tuple<Equipment,string>> GetEquipmentByItemName(string itemName)
        {
            List<Tuple<Equipment, string>> itemAndRoom = new List<Tuple<Equipment, string>>();
            
            foreach (Room r in roomController.GetAllRooms())
            {
                foreach (Equipment equipment in r.equipments)
                {
                    if (equipment.item == itemName)
                    {
                        itemAndRoom.Add(new Tuple<Equipment, string>(equipment, r.name));
                    }
                }
            }

            return itemAndRoom;
        }

        public List<Tuple<Equipment, string>> GetEquipmentByItemType(string itemType)
        {
            List<Tuple<Equipment, string>> itemAndRoom = new List<Tuple<Equipment, string>>();

            foreach (Room r in roomController.GetAllRooms())
            {
                foreach (Equipment equipment in r.equipments)
                {
                    if (equipment.type.ToString() == itemType)
                    {
                        itemAndRoom.Add(new Tuple<Equipment, string>(equipment, r.name));
                    }
                }
            }

            return itemAndRoom;
        }

        public List<Tuple<Equipment, string>> GetEquipmentByRoomType(string roomType)
        {
            List<Tuple<Equipment, string>> itemAndRoom = new List<Tuple<Equipment, string>>();

            foreach (Room r in roomController.GetAllRooms())
            {
                if (r.type.ToString() == roomType)
                {
                    foreach (Equipment equipment in r.equipments)
                    {


                        itemAndRoom.Add(new Tuple<Equipment, string>(equipment, r.name));

                    }
                }
            }

            return itemAndRoom;
        }

        public List<Tuple<Equipment, string>> GetEquipmentByQuantity(string type)
        {
            List<Tuple<Equipment, string>> itemAndRoom = new List<Tuple<Equipment, string>>();

            foreach (Room r in roomController.GetAllRooms())
            {
                
                
                foreach (Equipment equipment in r.equipments)
                    {

                    if (QuantityAmountCheck(equipment.quantity,type))
                    {
                        itemAndRoom.Add(new Tuple<Equipment, string>(equipment, r.name));
                    }

                    }
                
            }

            return itemAndRoom;
        }



        public bool QuantityAmountCheck(int quantity, string option)
        {
            if (option == ">10") if (10 >= quantity) return true;
            if (option == "<10") if (10 <= quantity) return true;
            if (option == "1t10") if (0 < quantity && quantity<=10) return true;
            return false;
        }


    }
}