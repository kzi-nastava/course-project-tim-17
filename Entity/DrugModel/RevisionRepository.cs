using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.DrugModel;

class RevisionRepository : IRevisionRepository
{
    public IMongoCollection<Revision> revisionCollection;
    public IMongoDatabase database;
    public RevisionRepository()
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
        this.revisionCollection = database.GetCollection<Revision>("DrugRequestRevisions");
    }

    public List<Revision> GetAll()
    {
        return revisionCollection.Find(item => true).ToList();

    }

    public Revision GetByDrugId(ObjectId id)
    {
        return revisionCollection.Find(item => item.drugId == id).FirstOrDefault();
    }

    public Revision GetById(ObjectId id)
    {
        return revisionCollection.Find(item => item._id == id).FirstOrDefault();
    }
    public void Insert(Revision r)
    {
        revisionCollection.InsertOne(r);
    }
    public void Delete(ObjectId id)
    {

        revisionCollection.DeleteOne(item => item.drugId == id);

    }

    public void Update(Revision revision)
    {
        revisionCollection.ReplaceOne(item => item._id == revision._id, revision);
    }
}