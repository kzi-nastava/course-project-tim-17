using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.DrugModel
{
    class DrugController
    {
        public IMongoCollection<Drug> drugCollection;
        public DrugController(IMongoDatabase database){
            this.drugCollection = database.GetCollection<Drug>("Drugs");

            
            }
        public List<Drug> getAllDrugs() {
            return drugCollection.Find(item =>  true).ToList();

        }
        public void InsertToCollection(Drug drug){
            drugCollection.InsertOne(drug);
        }
        public Drug FindById(ObjectId id)
        {
            return drugCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public Drug FindByDrugName(string drugName)
        {
            return drugCollection.Find(item => item.name == drugName).FirstOrDefault();
        }
        public void UpdateDrug(Drug drug)
        {
            drugCollection.ReplaceOne(item => item._id == drug._id, drug);
        }
    }
    }


