using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.NotificationModel;

namespace HealthcareSystem.UI.SecretaryView
{
    internal class HandleFreeDayRequests
    {
        public FreeDayRequestService freeDayRequestService;
        public NotificationFreeDayService notificationFreeDayService;
        public HandleFreeDayRequests() {

            notificationFreeDayService = Globals.container.Resolve<NotificationFreeDayService>();
            freeDayRequestService = Globals.container.Resolve<FreeDayRequestService>();
        }

        public void Accept(FreeDayRequest request) {
            
            request.status = Status.ACCEPTED;
            freeDayRequestService.Update(request);
            Console.WriteLine("Request approved! ");
        }

        public void Deny(FreeDayRequest request)
        {
            request.status = Status.DENIED;
            freeDayRequestService.Update(request);
            Console.WriteLine("Request denied! ");
        }
        public void Handle(String option, FreeDayRequest f) {

            if (option.Equals("1"))
            {
                Accept(f);
                sendNotification(f, "/");
            }
            else if (option.Equals("2")){ 
            
                Deny(f);
                Console.WriteLine("Enter the reason for your decison: ");
                String message =  Console.ReadLine();   
                sendNotification(f, message);
            }
        }

        public void sendNotification(FreeDayRequest f, string message) {
            notificationFreeDayService.MakeNotification(f, message);
           
        }
    }
}