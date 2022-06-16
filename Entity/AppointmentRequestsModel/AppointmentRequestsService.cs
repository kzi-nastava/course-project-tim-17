using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace HealthcareSystem.Entity.AppointmentRequestsModel
{
    class AppointmentRequestsService 
    {

        public IAppointmentRequestRepository appointmentRequestRepository;

        public AppointmentRequestsService(IAppointmentRequestRepository appointmentRequestRepository)
        {
            this.appointmentRequestRepository = appointmentRequestRepository;
        }

        public void Insert(AppointmentRequests appointment)
        {
            appointmentRequestRepository.Insert(appointment);
        }

        public void Delete(AppointmentRequests appointment)
        {
            appointmentRequestRepository.Delete(appointment._id);
        }

        public void Update(AppointmentRequests appointment)
        {
            appointmentRequestRepository.Update(appointment);
        }

        public List<AppointmentRequests> GetAll()
        {
            return appointmentRequestRepository.GetAll();
        }

        public AppointmentRequests GetById(ObjectId id) { 
            return appointmentRequestRepository.GetById(id);
        }

    }
}
