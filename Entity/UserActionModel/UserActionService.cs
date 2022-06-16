using MongoDB.Bson;

namespace HealthcareSystem.Entity.UserActionModel
{
    class UserActionService
    {
        public IUserActionRepository userActionRepository;
        public UserActionService(IUserActionRepository userActionRepository)
        {
            this.userActionRepository = userActionRepository;
        }
        public List<UserAction> GetAll()
        {
            return userActionRepository.GetAll();
        }
        public void Update(UserAction userAction)
        {
            userActionRepository.Update(userAction);
        }
        public void Insert(UserAction userAction)
        {
            userActionRepository.Insert(userAction);
        }

        public void Delete(UserAction userAction)
        {
            userActionRepository.Delete(userAction._id);
        }

        public List<UserAction> GetAllById(ObjectId userActionId)
        {
            return userActionRepository.GetAllById(userActionId);
        }

    }
}
