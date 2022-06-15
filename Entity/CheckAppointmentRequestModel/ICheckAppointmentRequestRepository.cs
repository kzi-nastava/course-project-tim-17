using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.CheckAppointmentRequestModel
{
    internal interface ICheckAppointmentRequestRepository:IRepository<CheckAppointementRequest>
    {
        List<CheckAppointementRequest> GetAllCheckAppointmentRequests();
    }
}
