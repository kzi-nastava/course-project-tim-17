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
        public void getAllDrugs() {
            List<Drug> drugs = drugCollection.Find(item =>  true).ToList();

            foreach(Drug drug in drugs) {
                Console.WriteLine(drug.name);
            }
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
    }
    }


