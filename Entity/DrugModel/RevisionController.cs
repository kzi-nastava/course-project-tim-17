using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.DrugModel;

class RevisionController
{
    public IMongoCollection<Revision> revisionCollection;
    public RevisionController(IMongoDatabase database)
    {
        this.revisionCollection = database.GetCollection<Revision>("DrugRequestRevisions");


    }
    public List<Revision> getAllDrugRevisions()
    {
        return revisionCollection.Find(item => true).ToList();

    }

    public Revision FindByDrugId(ObjectId id)
    {
        return revisionCollection.Find(item => item.drugId == id).FirstOrDefault();
    }
    public void InsertToCollection(Revision r)
    {
        revisionCollection.InsertOne(r);
    }
    public void DeleteByDrugId(ObjectId id)
    {

        revisionCollection.DeleteOne(item => item.drugId == id);


    }
}