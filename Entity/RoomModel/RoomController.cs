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
        public void InsertToCollection(Room room)
        {
            roomCollection.InsertOne(room);
        }
        public Room findById(ObjectId id) {
            return roomCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public void addEquipment(Room room, Equipment equipment) 
    {
        room.equipments.Add(equipment);
        roomCollection.ReplaceOne(item => item._id == room._id, room);
    }

    }
}


