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
        public void getAllReqiests()
        {
            List<MoveEquipmentRequest> moveEquipmentRequests = moveEquipmentRequestCollection.Find(item => true).ToList();

            foreach (MoveEquipmentRequest moveEquipmentRequest in moveEquipmentRequests)
            {
                Console.WriteLine(moveEquipmentRequest.equipment.item);
            }
        }
        public void InsertToCollection(MoveEquipmentRequest moveEquipmentRequest)
        {
            moveEquipmentRequestCollection.InsertOne(moveEquipmentRequest);
        }
        public MoveEquipmentRequest findById(ObjectId id) {
            return moveEquipmentRequestCollection.Find(item => item._id == id).FirstOrDefault();
        }

    }
}


