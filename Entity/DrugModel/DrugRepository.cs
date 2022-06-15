using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace HealthcareSystem.Entity.DrugModel
{
    class DrugRepository : IDrugRepository
    {
        public IMongoCollection<Drug> drugCollection;
        public IMongoDatabase database;
        public DrugRepository()
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
            this.drugCollection = database.GetCollection<Drug>("Drugs");
        }
        public List<Drug> GetAll() {
            return drugCollection.Find(item =>  true).ToList();

        }
        public void Insert(Drug drug){
            drugCollection.InsertOne(drug);
        }
        public Drug GetById(ObjectId id)
        {
            return drugCollection.Find(item => item._id == id).FirstOrDefault();
        }
        public Drug FindByDrugName(string drugName)
        {
            return drugCollection.Find(item => item.name == drugName).FirstOrDefault();
        }
        public void Update(Drug drug)
        {
            drugCollection.ReplaceOne(item => item._id == drug._id, drug);
        }

        public void Delete(ObjectId id)
        {

            drugCollection.DeleteOne(item => item._id == id);


        }
    }
    }


