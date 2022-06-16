using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.Survey.HospitalSurvey
{
    class HospitalSurveysRepository : IHospitalSurveysRepository
    {
        public IMongoCollection<HospitalSurveys> collection;
        public IMongoDatabase database;

        public HospitalSurveysRepository()
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
            this.collection = database.GetCollection<HospitalSurveys>("HospitalSurveys");
        }

        public void Insert(HospitalSurveys hospitalSurveys)
        {
            collection.InsertOne(hospitalSurveys);
        }

        public List<HospitalSurveys> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public void Delete(ObjectId id)
        {

            collection.DeleteOne(item => item._id == id);


        }
        public void Update(HospitalSurveys hs)
        {
            collection.ReplaceOne(item => item._id == hs._id, hs);
        }

        public HospitalSurveys GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }
    }
}
