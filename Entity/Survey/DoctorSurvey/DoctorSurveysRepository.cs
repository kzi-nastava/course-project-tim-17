using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.Survey.DoctorSurvey
{
    class DoctorSurveysRepository : IDoctorSurveysRepository
    {
        public IMongoCollection<DoctorSurveys> collection;
        public IMongoDatabase database;

        public DoctorSurveysRepository()
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
            this.collection = database.GetCollection<DoctorSurveys>("DoctorSurveys");
        }

        public void Insert(DoctorSurveys doctorSurveys)
        {
            collection.InsertOne(doctorSurveys);
        }

        public List<DoctorSurveys> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        public void Delete(ObjectId id)
        {

            collection.DeleteOne(item => item._id == id);


        }
        public void Update(DoctorSurveys ds)
        {
            collection.ReplaceOne(item => item._id == ds._id, ds);
        }

        public DoctorSurveys GetById(ObjectId id)
        {
            return collection.Find(item => item._id == id).FirstOrDefault();
        }
    }
}