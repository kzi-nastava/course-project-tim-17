using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.DoctorModel;

class FreeDayRequestController
{
    public IMongoCollection<FreeDayRequest> freeDayRequestsCollection;
    public FreeDayRequestController(IMongoDatabase database){
        this.freeDayRequestsCollection = database.GetCollection<FreeDayRequest>("FreeDayRequests");
            
    }
    public List<FreeDayRequest> getAllFreeDayRequstests() {
        
        List<FreeDayRequest> freeDayRequests = freeDayRequestsCollection.Find(item =>  true).ToList();
        return freeDayRequests;
    }
    public void InsertToCollection(FreeDayRequest freeDayRequest){
        freeDayRequestsCollection.InsertOne(freeDayRequest);
    }
    public FreeDayRequest findById(ObjectId id) {
        return freeDayRequestsCollection.Find(item => item._id == id).FirstOrDefault();
    }
    
}