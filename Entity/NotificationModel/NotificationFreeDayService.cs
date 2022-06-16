using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.DoctorModel;

namespace HealthcareSystem.Entity.NotificationModel
{

    class NotificationFreeDayService
    {
        public INotificationFreeDayRepository notificationRepository;
        public NotificationFreeDayService(INotificationFreeDayRepository notificationRepository) {
            this.notificationRepository = notificationRepository;
        }

        public void MakeNotification(FreeDayRequest request, String message) {
            NotificationFreeDay n = new NotificationFreeDay(message, request._id);
            notificationRepository.Insert(n);
        }

        public List<NotificationFreeDay> GetAll()
        {
            return notificationRepository.GetAll();
        }

    }
}
