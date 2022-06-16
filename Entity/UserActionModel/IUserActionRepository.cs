using MongoDB.Bson;
namespace HealthcareSystem.Entity.UserActionModel
{
    internal interface IUserActionRepository : IRepository<UserAction>
    {
        List<UserAction> GetAllById(ObjectId id);
    }
}
