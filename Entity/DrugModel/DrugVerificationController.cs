using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.DrugModel
{
        class DrugVerificationController
    {

        public IMongoCollection<DrugVerification> drugCollection;
        public DrugVerificationController(IMongoDatabase database)
        {
            this.drugCollection = database.GetCollection<DrugVerification>("DrugVerifications");


        }
        public void getAllDrugVerifications()
        {
            List<DrugVerification> drugVerifications = drugCollection.Find(item => true).ToList();

            foreach (DrugVerification d in drugVerifications)
            {
                Console.WriteLine(d.drugName);
            }
        }
        public void InsertToCollection(DrugVerification d)
        {
            drugCollection.InsertOne(d);
        }

    }

}
