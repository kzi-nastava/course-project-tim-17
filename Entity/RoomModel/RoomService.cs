using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.RoomModel
{

    class RoomService
    {
        public RoomController roomController;
        public RenovationRepository renovationReposotory;
        public MoveEquipmentRequestController moveController;


        public RoomService(IMongoDatabase database)
        {

            this.roomController = new RoomController(database);
            this.renovationReposotory = new RenovationRepository(database);
            this.moveController = new MoveEquipmentRequestController(database);
        }
        public void AddRoom(string roomName, RoomType roomType)
        {

            Room room = new Room(roomName, roomType);
            roomController.InsertToCollection(room);



        }
        public void AddRoom(Room room)
        {

            roomController.InsertToCollection(room);



        }

        public void addItemToRoom(Room room,Equipment item)
        {

            
            
            roomController.addEquipment(room, item);



        }

        public void AddEquipmentToRoom(Room room, List<Equipment> equipment)
        {


            foreach (Equipment item in equipment)
            {
                roomController.addEquipment(room, item);
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
        public void CheckForRenovations()
        {
            List<Renovation> roomsForRenovation = renovationReposotory.GetAllRenovations();
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
                        MergeRoomRenovation mr = renovationReposotory.findMergeRenovationByRenovationId(roomForRenovation._id);
                        MergeRooms(mr,roomForRenovation); 
                    }
                    if (roomForRenovation.RenovationType == 2)
                    {
                        SplitRoomRenovation sr = renovationReposotory.findSplitRenovationByRenovationId(roomForRenovation._id);
                        SplitRoom(sr, roomForRenovation);
                    }

                }

            }
        }
        public void StandardRenovation(Renovation roomRenovation)
        {
            Room room = roomController.findById(roomRenovation.roomId);
            room.InRenovation = false;
            roomController.UpdateRoom(room);
            renovationReposotory.DeleteRenovation(roomRenovation._id);
        }

        public void SplitRoom(SplitRoomRenovation roomForSplit, Renovation roomRenovation)
        {

            Room room = roomController.findById(roomRenovation.roomId);
            Room roomOne = new Room(roomForSplit.FirstRoomName, room.type);
            Room roomTwo = new Room(roomForSplit.SecondRoomName, room.type);
            AddEquipmentToRoom(roomOne, roomForSplit.firstRoomEquipment);
            AddEquipmentToRoom(roomTwo, roomForSplit.secondRoomEquipment);
            AddRoom(roomOne);
            AddRoom(roomTwo);
            DeleteRoom(room._id.ToString());
            DeleteSplitRenovation(roomForSplit);

        }


        public void MergeRooms(MergeRoomRenovation roomForMerge, Renovation roomRenovation)
        {

            Room roomOne = roomController.findById(roomForMerge.FirstRoomId);
            Room roomTwo = roomController.findById(roomForMerge.SecondRoomId);
            Room newMergedRoom = new Room(roomForMerge.MergedRoomName, roomOne.type);
            AddEquipmentToRoom(newMergedRoom, MergeEquipment(roomOne.equipments, roomTwo.equipments));
            AddRoom(newMergedRoom);
            DeleteRoom(roomOne._id.ToString());
            DeleteRoom(roomTwo._id.ToString());
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
            Renovation r = renovationReposotory.findRenovationById(sr.RenovationId);
            renovationReposotory.DeleteRenovation(r._id);
            renovationReposotory.DeleteSplitRenovation(sr._id);
        }
        public void DeleteMergeRenovation(MergeRoomRenovation mr)
        {
            Renovation r = renovationReposotory.findRenovationById(mr.RenovationId);
            renovationReposotory.DeleteRenovation(r._id);
            renovationReposotory.DeleteMergeRenovation(mr._id);
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
        public void CreateMoveEquipmentRequest(DateTime date, ObjectId roomFirstId, ObjectId roomSecondId, Equipment item)
        {

            MoveEquipmentRequest mer = new MoveEquipmentRequest(date, roomFirstId, roomSecondId, item);
            moveController.InsertToCollection(mer);




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


    }
}