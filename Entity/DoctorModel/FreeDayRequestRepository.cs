using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.DoctorModel;

class FreeDayRequestRepository : IFreeDayRequestRepository
{
    public IMongoCollection<FreeDayRequest> freeDayRequestsCollection;
    IMongoDatabase database;
    public FreeDayRequestRepository(){
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
        this.freeDayRequestsCollection = database.GetCollection<FreeDayRequest>("FreeDayRequests");
    }
    public List<FreeDayRequest> GetAll() {
        
        List<FreeDayRequest> freeDayRequests = freeDayRequestsCollection.Find(item =>  true).ToList();
        return freeDayRequests;
    }
    public void Insert(FreeDayRequest freeDayRequest){
        freeDayRequestsCollection.InsertOne(freeDayRequest);
    }
    public FreeDayRequest GetById(ObjectId id) {
        return freeDayRequestsCollection.Find(item => item._id == id).FirstOrDefault();
    }

    public void Update(FreeDayRequest freeDayRequest) 
    {
        freeDayRequestsCollection.ReplaceOne(item => item._id == freeDayRequest._id, freeDayRequest);
    }
    public void Delete(ObjectId id) 
    {
        freeDayRequestsCollection.DeleteOne(item => item._id == id);
    }

}