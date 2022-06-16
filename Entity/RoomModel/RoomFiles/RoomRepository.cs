
using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.RoomModel.RoomFiles
{
    class RoomRepository : IRoomRepository
    {
        public IMongoCollection<Room> collection;
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
            this.collection = database.GetCollection<Room>("Rooms");
        }

        public List<Room> GetAll()
        {
            return collection.Find(item => true).ToList();

        }
        public List<Room> GetRoomsWithItem(string itemName)
        {
            return collection.Find(item => item.ContainItem(itemName) == true).ToList();

        }

        public void Insert(Room room)
        {
            collection.InsertOne(room);
        }
        public Room GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }
        public Room getWarehouse()
        {
            return collection.Find(item => item.name == "Warehouse").FirstOrDefault();
        }
        
        public void Delete(ObjectId id)
        {

            collection.DeleteOne(item => item._id == id);


        }
        public void Update(Room room)
        {
            collection.ReplaceOne(item => item._id == room._id, room);
        }

        public Room GetByNameAndType(string roomName, RoomType roomType)
        {
            return collection.Find(item => item.name == roomName && item.type == roomType).FirstOrDefault();
        }




    }
}


