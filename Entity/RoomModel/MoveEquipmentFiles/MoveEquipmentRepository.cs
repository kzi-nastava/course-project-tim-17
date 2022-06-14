using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.RoomModel.MoveEquipmentFiles
{
    class MoveEquipmentRepository : IMoveEquipmentRepository
    {
        public IMongoCollection<MoveEquipmentRequest> collection;
        public IMongoDatabase database;

        public MoveEquipmentRepository()
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
            this.collection = database.GetCollection<MoveEquipmentRequest>("MoveEquipmentRequests");
        }
        public List<MoveEquipmentRequest> GetAll()
        {
            return collection.Find(item => true).ToList();

        }
        public void Insert(MoveEquipmentRequest moveEquipmentRequest)
        {
            collection.InsertOne(moveEquipmentRequest);
        }
        public MoveEquipmentRequest GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }

        public void Delete(ObjectId id)
        {

            collection.DeleteOne(item => item._id == id);

        }

        public void Update(MoveEquipmentRequest moveEquipmentRequest)
        {
            collection.ReplaceOne(item => item._id == moveEquipmentRequest._id, moveEquipmentRequest);
        }

    }
}


