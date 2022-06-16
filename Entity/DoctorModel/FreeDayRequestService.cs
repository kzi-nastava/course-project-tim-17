using Autofac;
using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
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
        public DoctorService doctorService { get; set; }
        public IFreeDayRequestRepository freeDayRequestRepository;
        public FreeDayRequestService(IFreeDayRequestRepository freeDayRequestRepository)
        {
            this.freeDayRequestRepository = freeDayRequestRepository;
            this.doctorService = Globals.container.Resolve<DoctorService>();
        }
        public void Insert(FreeDayRequest freeDayRequest)
        {
            freeDayRequestRepository.Insert(freeDayRequest);
        }
        public List<FreeDayRequest> GetFreeDayRequestByStatus(Status status)
        {
            List<FreeDayRequest> freeDayRequests = freeDayRequestRepository.GetAll();
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
            List<FreeDayRequest> freeDayRequests = freeDayRequestRepository.GetAll();
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

        public FreeDayRequest GetById(ObjectId id) { 
            
            return freeDayRequestRepository.GetById(id);


        }

        public List<FreeDayRequest> GetAll() { 
        
            return freeDayRequestRepository.GetAll();
        }
        public void PrintAllFreeDayRequests()
        {
            List<FreeDayRequest> freeDayRequests = freeDayRequestRepository.GetAll();
            Console.WriteLine("FREE DAYS REQUESTS: ");
            Console.WriteLine();
            int i = 0;
            foreach (FreeDayRequest fr in freeDayRequests)
            {
                i += 1;
                Doctor doc = doctorService.GetById(fr.doctorId);
                Console.WriteLine(i);
                Console.WriteLine("REQUEST ID: " + fr._id);
                Console.WriteLine("FROM: " + fr.startOf);
                Console.WriteLine("TO: " + fr.endOf);
                Console.WriteLine("DESCRIPTION: " + fr.description);
                Console.WriteLine("STATUS: " + fr.status);
                Console.WriteLine("DOCTOR EMAIL: " + doc.email);
                Console.WriteLine();
                
            }
        }

        public void Update(FreeDayRequest req) {

            freeDayRequestRepository.Update(req);
        }
    }
}
