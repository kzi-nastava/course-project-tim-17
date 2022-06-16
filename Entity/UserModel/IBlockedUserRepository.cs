using MongoDB.Bson;

namespace HealthcareSystem.Entity.UserModel
{
    internal interface IBlockedUserRepository : IRepository<BlockedUser>
    {
        BlockedUser GetByUserId(ObjectId id);
        BlockedUser CheckIfBlocked(ObjectId id);
        void PrintBlockedUsers();
    }
}
