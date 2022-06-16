using MongoDB.Bson;

namespace HealthcareSystem.Entity.CheckModel
{
    internal interface ICheckRepository : IRepository<Check>
    {
        List<Check> GetAllById(ObjectId id);
    }
}
