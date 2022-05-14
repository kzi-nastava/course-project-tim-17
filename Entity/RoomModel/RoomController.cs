
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.RoomModel
{
    class RoomController
    {
        public IMongoCollection<Room> roomCollection;

        public RoomController(IMongoDatabase database)
        {
            this.roomCollection = database.GetCollection<Room>("Rooms");


        }
        public void getAllDrugs()
        {
            List<Room> rooms = roomCollection.Find(item => true).ToList();

            foreach (Room drug in rooms)
            {
                Console.WriteLine(drug.type);
            }
        }

        public List<Room> GetAllRooms()
        {
            return roomCollection.Find(item => true).ToList();

        }
        public List<Room> GetRoomsWithItem(string itemName)
        {
            return roomCollection.Find(item => item.ContainItem(itemName) == true).ToList();

        }

        public void InsertToCollection(Room room)
        {
            roomCollection.InsertOne(room);
        }
        public Room findById(ObjectId id)
        {
            return roomCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public Room getWarehouse()
        {
            return roomCollection.Find(item => item.name == "Warehouse").FirstOrDefault();
        }
        public void addEquipment(Room room, Equipment equipment)
        {
            room.equipments.Add(equipment);
            roomCollection.ReplaceOne(item => item._id == room._id, room);
        }
        public void DeleteRoom(ObjectId id)
        {

            roomCollection.DeleteOne(item => item._id == id);


        }
        public void UpdateRoom(Room room)
        {
            roomCollection.ReplaceOne(item => item._id == room._id, room);
        }




    }
}


