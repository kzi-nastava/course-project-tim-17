using HealthcareSystem.Entity.Enumerations;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.DoctorModel
{
    class FreeDayRequestService
    {
        public FreeDayRequestController freeDayRequestRepository;
        public FreeDayRequestService(IMongoDatabase database)
        {
            freeDayRequestRepository = new FreeDayRequestController(database);
        }

        public List<FreeDayRequest> GetFreeDayRequestByStatus(Status status)
        {
            List<FreeDayRequest> freeDayRequests = freeDayRequestRepository.getAllFreeDayRequstests();
            List<FreeDayRequest> certainFreeDayRequest = new List<FreeDayRequest>();
            foreach (FreeDayRequest freeDayRequest in freeDayRequests)
            {
                if(freeDayRequest.status == status)
                {
                    certainFreeDayRequest.Add(freeDayRequest);
                }
            }
            return certainFreeDayRequest;

        }
        public List<FreeDayRequest> GetFreeDayRequestByStatusAndByDoctor(Status status, Doctor doctor)
        {
            List<FreeDayRequest> freeDayRequests = freeDayRequestRepository.getAllFreeDayRequstests();
            List<FreeDayRequest> certainFreeDayRequest = new List<FreeDayRequest>();
            foreach (FreeDayRequest freeDayRequest in freeDayRequests)
            {
                if (freeDayRequest.status == status && freeDayRequest.doctorId == doctor._id)
                {
                    certainFreeDayRequest.Add(freeDayRequest);
                }
            }
            return certainFreeDayRequest;

        }

    }
}
