using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.RoomModel
{
    class RenovationRepository
    {
        public IMongoCollection<Renovation> renovationCollection;
        public IMongoCollection<MergeRoomRenovation> mergeRenovationCollection;
        public IMongoCollection<SplitRoomRenovation> splitRenovationCollection;

        public RenovationRepository(IMongoDatabase database)
        {
            this.renovationCollection = database.GetCollection<Renovation>("Renovations");
            this.mergeRenovationCollection = database.GetCollection<MergeRoomRenovation>("MergeRenovations");
            this.splitRenovationCollection = database.GetCollection<SplitRoomRenovation>("SplitRenovations");


        }
        public List<Renovation> GetAllRenovations()
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
        public void InsertToCollection(Renovation renovation)
        {
            renovationCollection.InsertOne(renovation);
        }
        public void InsertToCollectionMergeRenovation(Renovation renovation, MergeRoomRenovation mergeRoomRenovation)
        {
            renovationCollection.InsertOne(renovation);
            mergeRenovationCollection.InsertOne(mergeRoomRenovation);
        }
        public void InsertToCollectionSplitRenovation(Renovation renovation, SplitRoomRenovation splitRoomRenovation)
        {
            renovationCollection.InsertOne(renovation);
            splitRenovationCollection.InsertOne(splitRoomRenovation);
        }
        public Renovation findRenovationById(ObjectId id)
        {
            return renovationCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public MergeRoomRenovation findMergeRenovationById(ObjectId id)
        {
            return mergeRenovationCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public MergeRoomRenovation findMergeRenovationByRenovationId(ObjectId id)
        {
            return mergeRenovationCollection.Find(item => item.RenovationId == id).FirstOrDefault();
        }
        public SplitRoomRenovation findSplitRenovationById(ObjectId id)
        {
            return splitRenovationCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public SplitRoomRenovation findSplitRenovationByRenovationId(ObjectId id)
        {
            return splitRenovationCollection.Find(item => item.RenovationId == id).FirstOrDefault();
        }

        public void DeleteRenovation(ObjectId id)
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

    }
}


