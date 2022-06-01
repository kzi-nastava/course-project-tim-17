using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.ApointmentModel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.EquipmentRequestModel
{
    class EquipmentRequestController
    {

        public IMongoCollection<EquipmentRequest> equipmentRequestCollection;

        public EquipmentRequestController(IMongoDatabase database)
        {
            this.equipmentRequestCollection = database.GetCollection<EquipmentRequest>("EquipmentRequests");

        }
        public List<EquipmentRequest> GetAllEquipmentRequests()
        {
            List<EquipmentRequest> ers = equipmentRequestCollection.Find(item => true).ToList();

            return ers;
        }
        public void InsertToCollection(EquipmentRequest er)
        {
            equipmentRequestCollection.InsertOne(er);
        }
        public EquipmentRequest FindById(ObjectId id)
        {
            return equipmentRequestCollection.Find(item => item._id == id).FirstOrDefault();
        }


        public void DeleteEquipmentRequest(EquipmentRequest er)
        {
            equipmentRequestCollection.DeleteOne(item => item._id == er._id);
        }



        public void Update(EquipmentRequest er)
        {

            equipmentRequestCollection.ReplaceOne(item => item._id == er._id, er);
        }

    }
}
