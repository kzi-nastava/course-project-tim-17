using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.ApointmentModel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.CheckAppointmentRequestModel
{
    class CheckAppointmentRequestController
    {

        public IMongoCollection<CheckAppointementRequest> checkAppointmentRequestCollection;

        public CheckAppointmentRequestController(IMongoDatabase database)
        {
            this.checkAppointmentRequestCollection = database.GetCollection<CheckAppointementRequest>("CheckAppointmentRequests");

        }
        public List<CheckAppointementRequest> GetAllCheckAppointmentRequests()
        {
            List<CheckAppointementRequest> crs = checkAppointmentRequestCollection.Find(item => true).ToList();

            return crs;
        }
        public void InsertToCollection(CheckAppointementRequest cr)
        {
            checkAppointmentRequestCollection.InsertOne(cr);
        }
        public CheckAppointementRequest FindById(ObjectId id)
        {
            return checkAppointmentRequestCollection.Find(item => item._id == id).FirstOrDefault();
        }

       
        public void DeleteCheckAppointementRequestCard(CheckAppointementRequest cr)
        {
            checkAppointmentRequestCollection.DeleteOne(item => item._id == cr._id);
        }

   

       public void Update(CheckAppointementRequest cr)
        {

            checkAppointmentRequestCollection.ReplaceOne(item => item._id == cr._id, cr);
        }

    }
}
