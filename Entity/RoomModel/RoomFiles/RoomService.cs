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


    }
}