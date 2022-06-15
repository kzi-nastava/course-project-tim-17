
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.RoomModel.RoomFiles
{
    class RoomRepository : IRoomRepository
    {
        public IMongoCollection<Room> roomCollection;
        public IMongoDatabase database;

        public RoomRepository()
        {

            GetDatabase();
            GetCollection();

        }

        public void GetDatabase()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Tim17:UXGhApWVw9oc6VGg@cluster0.se6mz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            this.database = client.GetDatabase("USI");
        }
        public void GetCollection()
        {
            this.roomCollection = database.GetCollection<Room>("Rooms");
        }

        public List<Room> GetAll()
        {
            return roomCollection.Find(item => true).ToList();

        }
        public List<Room> GetRoomsWithItem(string itemName)
        {
            return roomCollection.Find(item => item.ContainItem(itemName) == true).ToList();

        }

        public void Insert(Room room)
        {
            roomCollection.InsertOne(room);
        }
        public Room GetById(ObjectId id)
        {
            return roomCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public Room getWarehouse()
        {
            return roomCollection.Find(item => item.name == "Warehouse").FirstOrDefault();
        }
        
        public void Delete(ObjectId id)
        {

            roomCollection.DeleteOne(item => item._id == id);


        }
        public void Update(Room room)
        {
            roomCollection.ReplaceOne(item => item._id == room._id, room);
        }





    }
}


