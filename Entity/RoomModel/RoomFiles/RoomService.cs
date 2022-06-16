using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.RoomModel.MoveEquipmentFiles;
using HealthcareSystem.Entity.RoomModel.RenovationFiles;
using HealthcareSystem.Entity.RoomModel.RenovationFiles.MergeRenovation;
using HealthcareSystem.Entity.RoomModel.RenovationFiles.SplitRenovation;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.RoomModel.RoomFiles
{

    class RoomService
    {
        
        public IRenovationRepository renovationReposotory;
        public IMoveEquipmentRepository moveRepository;
        public IRoomRepository roomRepository;

        public RoomService(IMoveEquipmentRepository moveController, IRoomRepository roomRepository,IRenovationRepository renovationRepository)
        {

            this.roomRepository = roomRepository;
            this.renovationReposotory = renovationRepository;
            this.moveRepository = moveController;
        }
        public List<Room> GetAll() 
        {
            return this.roomRepository.GetAll();
        }
        public void Add(string roomName, RoomType roomType)
        {

            Room room = new Room(roomName, roomType);
            roomRepository.Insert(room);



        }
        public Room GetById(string id) 
        {
            return this.roomRepository.GetById(new ObjectId(id));
        }
        public void Add(Room room)
        {

            roomRepository.Insert(room);


        }


        public void AddItemToRoom(Room room,Equipment item)
        {


            room.equipments.Add(item);
            Update(room);



        }

        public void AddEquipmentToRoom(Room room, List<Equipment> equipment)
        {


            foreach (Equipment item in equipment)
            {
                room.equipments.Add(item);
                
            }
            Update(room);



        }


        

        public void Delete(string id)
        {
            roomRepository.Delete(new ObjectId(id));


        }
        public void Update(Room room)
        {

            roomRepository.Update(room);


        }
        public void CheckForRenovations()
        {
            List<Renovation> roomsForRenovation = renovationReposotory.GetAll();
            DateTime currentTime = DateTime.Now;
            foreach (Renovation roomForRenovation in roomsForRenovation)
            {
                if (currentTime > roomForRenovation.renovationEndDate)
                {
                    if (roomForRenovation.RenovationType == 0)
                    {
                        StandardRenovation(roomForRenovation);
                    }
                    if (roomForRenovation.RenovationType == 1)
                    {
                        MergeRoomRenovation mr = renovationReposotory.GetMergeRenovationByRenovationId(roomForRenovation._id);
                        MergeRooms(mr,roomForRenovation); 
                    }
                    if (roomForRenovation.RenovationType == 2)
                    {
                        SplitRoomRenovation sr = renovationReposotory.GetSplitRenovationByRenovationId(roomForRenovation._id);
                        SplitRoom(sr, roomForRenovation);
                    }

                }

            }
        }
        public void StandardRenovation(Renovation roomRenovation)
        {
            Room room = roomRepository.GetById(roomRenovation.roomId);
            room.InRenovation = false;
            roomRepository.Update(room);
            renovationReposotory.Delete(roomRenovation._id);
        }

        public void SplitRoom(SplitRoomRenovation roomForSplit, Renovation roomRenovation)
        {

            Room room = roomRepository.GetById(roomRenovation.roomId);
            Room roomOne = new Room(roomForSplit.FirstRoomName, room.type);
            Room roomTwo = new Room(roomForSplit.SecondRoomName, room.type);
            AddEquipmentToRoom(roomOne, roomForSplit.firstRoomEquipment);
            AddEquipmentToRoom(roomTwo, roomForSplit.secondRoomEquipment);
            Add(roomOne);
            Add(roomTwo);
            Delete(room._id.ToString());
            DeleteSplitRenovation(roomForSplit);

        }


        public void MergeRooms(MergeRoomRenovation roomForMerge, Renovation roomRenovation)
        {

            Room roomOne = roomRepository.GetById(roomForMerge.FirstRoomId);
            Room roomTwo = roomRepository.GetById(roomForMerge.SecondRoomId);
            Room newMergedRoom = new Room(roomForMerge.MergedRoomName, roomOne.type);
            AddEquipmentToRoom(newMergedRoom, MergeEquipment(roomOne.equipments, roomTwo.equipments));
            Add(newMergedRoom);
            Delete(roomOne._id.ToString());
            Delete(roomTwo._id.ToString());
            DeleteMergeRenovation(roomForMerge);

        }

        public List<Equipment> MergeEquipment(List<Equipment> roomOneEquipment, List<Equipment> roomTwoEquipment)
        {
            List<Equipment> mergedEquipment = new List<Equipment>();
            List<Equipment> differentEquipment = new List<Equipment>();
            foreach (Equipment item in roomOneEquipment) 
            {
                mergedEquipment.Add(item);
            }
            foreach (Equipment item in roomTwoEquipment)
            {
                bool added = false;
                foreach (Equipment itemTwo in mergedEquipment)
                {
                    if (item.item == itemTwo.item)
                    {
                        itemTwo.quantity += item.quantity;
                        added = true;
                    }
                }
                if (!added) 
                { 
                    differentEquipment.Add(item); 
                }
            }
            foreach (Equipment item in differentEquipment) 
            {
                mergedEquipment.Add(item);
            }
            return mergedEquipment;

        }

        public void DeleteSplitRenovation(SplitRoomRenovation sr) 
        {
            Renovation r = renovationReposotory.GetById(sr.RenovationId);
            renovationReposotory.Delete(r._id);
            renovationReposotory.DeleteSplitRenovation(sr._id);
        }
        public void DeleteMergeRenovation(MergeRoomRenovation mr)
        {
            Renovation r = renovationReposotory.GetById(mr.RenovationId);
            renovationReposotory.Delete(r._id);
            renovationReposotory.DeleteMergeRenovation(mr._id);
        }


        public List<Tuple<Equipment,string>> GetEquipmentByItemName(string itemName)
        {
            List<Tuple<Equipment, string>> itemAndRoom = new List<Tuple<Equipment, string>>();
            
            foreach (Room r in roomRepository.GetAll())
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

            foreach (Room r in roomRepository.GetAll())
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

            foreach (Room r in roomRepository.GetAll())
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

            foreach (Room r in roomRepository.GetAll())
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

        public void MoveEquipment()
        {
            List<MoveEquipmentRequest> moveEquipmentRequests = moveRepository.GetAll();
            DateTime currentTime = DateTime.Now;
            foreach (MoveEquipmentRequest moveEquipmentRequest in moveEquipmentRequests)
            {

                if (currentTime > moveEquipmentRequest.moveDate)
                {
                    Room roomFrom = roomRepository.GetById(moveEquipmentRequest.moveFrom);
                    if (roomFrom.CheckIfEquipmentIsAvaliable(moveEquipmentRequest.equipment))
                    {
                        Room roomTo = roomRepository.GetById(moveEquipmentRequest.moveTo);
                        if (roomTo.ContainItem(moveEquipmentRequest.equipment.item))
                        {
                            changeQuantityFromEquipment(roomTo, moveEquipmentRequest, "add");
                            changeQuantityFromEquipment(roomFrom, moveEquipmentRequest, "sub");
                            moveRepository.Delete(moveEquipmentRequest._id);
                        }
                        else
                        {
                            AddItemToRoom(roomTo, moveEquipmentRequest.equipment);
                            changeQuantityFromEquipment(roomFrom, moveEquipmentRequest, "sub");
                            moveRepository.Delete(moveEquipmentRequest._id);

                        }

                    }
                    else
                    {
                        Console.WriteLine("Equipment Unavaliable");
                    }

                }

            }
        }
        public void CreateMoveEquipmentRequest(DateTime date, ObjectId roomFirstId, ObjectId roomSecondId, Equipment item)
        {

            MoveEquipmentRequest mer = new MoveEquipmentRequest(date, roomFirstId, roomSecondId, item);
            moveRepository.Insert(mer);




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
                    roomRepository.Update(room);
                }
            }

        }


        public static Boolean RoomLacks(Room r)
        {
            foreach (Equipment e in r.equipments)
            {
                if (e.quantity < 5 && e.isDynamic)
                {
                    return true;

                }
            }
            return false;

        }


        public void PrintRoomsNeedingEquipment(List<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                if (RoomLacks(room) && !room.name.Equals("Warehouse"))
                {
                    Console.WriteLine("ROOM: " + room.name);
                    Console.WriteLine("TYPE: " + room.type.ToString());
                    Console.WriteLine("ID: " + room._id);
                    Console.WriteLine("ITEMS:");
                    foreach (Equipment e in room.equipments)
                    {
                        if (e.isDynamic)
                        {
                            Console.WriteLine("        ITEM: " + e.item);
                            Console.WriteLine("        TYPE: " + e.type.ToString());
                            if (e.quantity < 5)
                            {
                                Console.WriteLine("        QUANTITY: " + e.quantity + " ***");
                            }
                            else
                            {
                                Console.WriteLine("        QUANTITY: " + e.quantity);
                            }
                        }


                    }
                    Console.WriteLine();
                }

            }
        }
        public static bool DoesRoomHave(Room room, String Itemname)
        {
            foreach (Equipment e in room.equipments)
            {
                if (e.item.ToUpper().Equals(Itemname.ToUpper()))
                {
                    return true;
                }

            }
            return false;

        }
        public void PrintLackingEquipmentFromWareHouse(Room warehouse)
        {
            List<Equipment> eq = warehouse.equipments;
            Console.WriteLine("EQUIPMENT THAT IS LACKING IN WAREHOUSE: ");
            foreach (Equipment eqItem in eq)
            {
                if (eqItem.isDynamic && eqItem.quantity == 0)
                {
                    Console.WriteLine("ITEM: " + eqItem.item.ToUpper());
                    Console.WriteLine("TYPE:" + eqItem.type.ToString());
                    Console.WriteLine("ID:" + eqItem._id);
                    Console.WriteLine("----------------------------------------");
                }
            }
        }

        public Room getWarehouse()
        {
            return roomRepository.getWarehouse();
        }

        public void PrintRoomsWhichHaveSpecificEquipment(List<Room> rooms, String ItemName)
        {
            foreach (Room room in rooms)
            {
                if (DoesRoomHave(room, ItemName))
                {
                    Console.WriteLine("ID: " + room._id);
                    Console.WriteLine("ROOM: " + room.name);
                    Console.WriteLine("TYPE: " + room.type);
                    foreach (Equipment e in room.equipments)
                    {
                        if (e.item.ToUpper().Equals(ItemName.ToUpper()))
                        {
                            Console.WriteLine("QUANTITY: " + e.quantity);
                        }
                    }
                    Console.WriteLine();
                }

            }
        }
        public Room GetByNameAndType(string roomName, RoomType roomType)
        {
            return roomRepository.GetByNameAndType(roomName, roomType);
        }


    }
}