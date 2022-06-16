using MongoDB.Bson;

namespace HealthcareSystem.Entity.NotificationModel
{
    internal interface INotificationSettingsRepository : IRepository<NotificationSettings>
    {
        void ChangeTimeById(ObjectId id, int time);
    }
}
