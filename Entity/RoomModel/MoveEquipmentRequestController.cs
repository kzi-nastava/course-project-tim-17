using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.RoomModel
{
    class MoveEquipmentRequestController
    {
        public IMongoCollection<MoveEquipmentRequest> moveEquipmentRequestCollection;

        public MoveEquipmentRequestController(IMongoDatabase database)
        {
            this.moveEquipmentRequestCollection = database.GetCollection<MoveEquipmentRequest>("MoveEquipmentRequests");


        }
        public List<MoveEquipmentRequest> GetAllMoveEquipmentRequests()
        {
            return moveEquipmentRequestCollection.Find(item => true).ToList();

        }
        public void InsertToCollection(MoveEquipmentRequest moveEquipmentRequest)
        {
            moveEquipmentRequestCollection.InsertOne(moveEquipmentRequest);
        }
        public MoveEquipmentRequest findById(ObjectId id)
        {
            return moveEquipmentRequestCollection.Find(item => item._id == id).FirstOrDefault();
        }

        public void DeleteMoveEquipmentRequest(ObjectId id)
        {

            moveEquipmentRequestCollection.DeleteOne(item => item._id == id);



        }

    }
}


