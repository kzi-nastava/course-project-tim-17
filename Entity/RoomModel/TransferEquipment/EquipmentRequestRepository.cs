using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.ApointmentModel;
using MongoDB.Bson;
using MongoDB.Driver;


namespace HealthcareSystem.Entity.RoomModel.TransferEquipment
{
    class EquipmentRequestRepository:IEquipmentRequestRepository
    {

        public IMongoCollection<EquipmentRequest> equipmentRequestCollection;
        public IMongoDatabase database;


        public EquipmentRequestRepository()
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
            this.equipmentRequestCollection = database.GetCollection<EquipmentRequest>("EquipmentRequests");
        }

        public List<EquipmentRequest> GetAll()
        {
            List<EquipmentRequest> ers = equipmentRequestCollection.Find(item => true).ToList();

            return ers;
        }
        public void Insert(EquipmentRequest er)
        {
            equipmentRequestCollection.InsertOne(er);
        }
        public EquipmentRequest FindById(ObjectId id)
        {
            return equipmentRequestCollection.Find(item => item._id == id).FirstOrDefault();
        }


        public void Delete(ObjectId id)
        {
            equipmentRequestCollection.DeleteOne(item => item._id == id);
        }


        public EquipmentRequest GetById(ObjectId id)
        {
            return equipmentRequestCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public void Update(EquipmentRequest er)
        {

            equipmentRequestCollection.ReplaceOne(item => item._id == er._id, er);
        }

    }
}
