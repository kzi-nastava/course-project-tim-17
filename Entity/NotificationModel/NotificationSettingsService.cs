using MongoDB.Bson;
namespace HealthcareSystem.Entity.NotificationModel
{
    class NotificationSettingsService
    {
        public INotificationSettingsRepository notificationSettingsRepository;

        public NotificationSettingsService(INotificationSettingsRepository notificationSettingsRepository)
        {
            this.notificationSettingsRepository = notificationSettingsRepository;
        }

        public List<NotificationSettings> GetAll()
        {
            return notificationSettingsRepository.GetAll();
        }
        public void Update(NotificationSettings notificationSettings)
        {
            notificationSettingsRepository.Update(notificationSettings);
        }
        public void Insert(NotificationSettings notificationSettings)
        {
            notificationSettingsRepository.Insert(notificationSettings);
        }

        public void Delete(NotificationSettings notificationSettings)
        {
            notificationSettingsRepository.Delete(notificationSettings._id);
        }

        public NotificationSettings GetById(ObjectId notificationSettingsId)
        {
            return notificationSettingsRepository.GetById(notificationSettingsId);
        }

        public void ChangeTimeById(ObjectId id, int time)
        {
            notificationSettingsRepository.ChangeTimeById(id, time);
        }
    }
}
