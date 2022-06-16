using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Enumerations;

namespace HealthcareSystem.UI.Secretary
{
    internal class HandleFreeDayRequests
    {

        public HandleFreeDayRequests() { 
            
            
        }

        public void Accept(FreeDayRequest request, FreeDayRequestService fs) {
            
            request.status = Status.ACCEPTED;
            fs.Update(request);
            Console.WriteLine("Request approved! ");
        }

        public void Deny(FreeDayRequest request, FreeDayRequestService fs)
        {
            request.status = Status.DENIED;
            fs.Update(request);
            Console.WriteLine("Request denied! ");
        }
        public void Handle(String option, FreeDayRequest f, FreeDayRequestService fs) {

            if (option.Equals("1"))
            {
                Accept(f, fs);
            }
            else if (option.Equals("2")){ 
            
                Deny(f, fs);
            }


        }
    }
}
