using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.DoctorModel;

class FreeDayRequestController
{
    public IMongoCollection<FreeDayRequest> freeDayRequestsCollection;
    public FreeDayRequestController(IMongoDatabase database){
        this.freeDayRequestsCollection = database.GetCollection<FreeDayRequest>("FreeDayRequests");
            
    }
    public List<FreeDayRequest> getAllFreeDayRequests() {
        
        List<FreeDayRequest> freeDayRequests = freeDayRequestsCollection.Find(item =>  true).ToList();
        return freeDayRequests;
    }
    public void InsertToCollection(FreeDayRequest freeDayRequest){
        freeDayRequestsCollection.InsertOne(freeDayRequest);
    }
    public FreeDayRequest findById(ObjectId id) {
        return freeDayRequestsCollection.Find(item => item._id == id).FirstOrDefault();
    }

    public void Update(FreeDayRequest req)
    {
        freeDayRequestsCollection.ReplaceOne(item => item._id == req._id, req);
    }

}