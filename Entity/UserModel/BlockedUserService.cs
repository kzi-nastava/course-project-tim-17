using MongoDB.Bson;
namespace HealthcareSystem.Entity.UserModel
{
    class BlockedUserService
    {
        public IBlockedUserRepository blockedUserRepository;
        public BlockedUserService(IBlockedUserRepository blockedUserRepository)
        {
            this.blockedUserRepository = blockedUserRepository;
        }

        public List<BlockedUser> GetAll()
        {
            return blockedUserRepository.GetAll();
        }
        public void Insert(BlockedUser blockedUser)
        {
            blockedUserRepository.Insert(blockedUser);
        }
        public void Update(BlockedUser blockedUser)
        {
            blockedUserRepository.Update(blockedUser);
        }
        public void Delete(ObjectId id)
        {
            blockedUserRepository.Delete(id);
        }
        public BlockedUser GetById(ObjectId id)
        {
            return blockedUserRepository.GetById(id);
        }


        public BlockedUser GetByUserId(ObjectId id)
        {
            return blockedUserRepository.GetByUserId(id);
        }
        public BlockedUser CheckIfBlocked(ObjectId id)
        {
            return blockedUserRepository.CheckIfBlocked(id);
        }

        public void PrintBlockedUsers()
        {
            blockedUserRepository.PrintBlockedUsers();
        }
    }
}
