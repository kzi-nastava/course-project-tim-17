using HealthcareSystem.Entity.RoomModel.RenovationFiles.MergeRenovation;
using HealthcareSystem.Entity.RoomModel.RenovationFiles.SplitRenovation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.RoomModel.RenovationFiles
{
    class RenovationRepository : IRenovationRepository
    {
        public IMongoCollection<Renovation> renovationCollection;
        public IMongoCollection<MergeRoomRenovation> mergeRenovationCollection;
        public IMongoCollection<SplitRoomRenovation> splitRenovationCollection;
        public IMongoDatabase database;

        public RenovationRepository() 
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
            this.renovationCollection = database.GetCollection<Renovation>("Renovations");
            this.mergeRenovationCollection = database.GetCollection<MergeRoomRenovation>("MergeRenovations");
            this.splitRenovationCollection = database.GetCollection<SplitRoomRenovation>("SplitRenovations");
        }

        public List<Renovation> GetAll()
        {
            return renovationCollection.Find(item => true).ToList();

        }
        public List<MergeRoomRenovation> GetAllMergeRenovations()
        {
            return mergeRenovationCollection.Find(item => true).ToList();

        }
        public List<SplitRoomRenovation> GetAllSplitRenovations()
        {
            return splitRenovationCollection.Find(item => true).ToList();

        }
        public void Insert(Renovation renovation)
        {
            renovationCollection.InsertOne(renovation);
        }
        public void InsertMergeRenovation(Renovation renovation, MergeRoomRenovation mergeRoomRenovation)
        {
            renovationCollection.InsertOne(renovation);
            mergeRenovationCollection.InsertOne(mergeRoomRenovation);
        }
        public void InsertSplitRenovation(Renovation renovation, SplitRoomRenovation splitRoomRenovation)
        {
            renovationCollection.InsertOne(renovation);
            splitRenovationCollection.InsertOne(splitRoomRenovation);
        }
        public Renovation GetById(ObjectId id)
        {
            return renovationCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public MergeRoomRenovation GetMergeRenovationById(ObjectId id)
        {
            return mergeRenovationCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public MergeRoomRenovation GetMergeRenovationByRenovationId(ObjectId id)
        {
            return mergeRenovationCollection.Find(item => item.RenovationId == id).FirstOrDefault();
        }
        public SplitRoomRenovation GetSplitRenovationById(ObjectId id)
        {
            return splitRenovationCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public SplitRoomRenovation GetSplitRenovationByRenovationId(ObjectId id)
        {
            return splitRenovationCollection.Find(item => item.RenovationId == id).FirstOrDefault();
        }

        public void Delete(ObjectId id)
        {

            renovationCollection.DeleteOne(item => item._id == id);



        }
        public void DeleteMergeRenovation(ObjectId id)
        {

            mergeRenovationCollection.DeleteOne(item => item._id == id);



        }
        public void DeleteSplitRenovation(ObjectId id)
        {

            splitRenovationCollection.DeleteOne(item => item._id == id);



        }
        public void Update(Renovation renovation)
        {
            renovationCollection.ReplaceOne(item => item._id == renovation._id, renovation);
        }

    }
}


