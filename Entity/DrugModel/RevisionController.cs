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
    public void getAllDrugRevisions()
    {
        List<Revision> revisionVerifications = revisionCollection.Find(item => true).ToList();

        foreach (Revision r in revisionVerifications)
        {
            Console.WriteLine(r.desctription);
        }
    }
    public void InsertToCollection(Revision r)
    {
        revisionCollection.InsertOne(r);
    }
}