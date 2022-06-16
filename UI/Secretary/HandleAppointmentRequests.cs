using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;
using HealthcareSystem.Entity.Enumerations;
using HealthCareSystem.Entity.CheckAppointementRequestModel;


namespace HealthcareSystem.UI.Secretary
{
    internal class HandleAppointmentRequests
    {

        public CheckAppointmentRequestService checkRequestService;
        public AppointmentService appointmentService;
        public AppointmentRequestsService appointmentRequestService;
        public HandleAppointmentRequests()
        {
            checkRequestService = Globals.container.Resolve<CheckAppointmentRequestService>();
            appointmentService = Globals.container.Resolve<AppointmentService>();
            appointmentRequestService = Globals.container.Resolve<AppointmentRequestsService>();
        }
        public void Accept(CheckAppointementRequest cr) {

            cr.status = Status.ACCEPTED;
            checkRequestService.Update(cr);
            if (cr.RequestState == RequestState.DELETE)
            {
                appointmentService.DeleteAppointementByRequest(cr);
                Console.WriteLine("Appointement is succesfully deleted!");
            }
            else if (cr.RequestState == RequestState.EDIT)
            {
                AppointmentRequests ar = appointmentRequestService.GetById(cr.appointmentId);
                appointmentService.EditAppointementByRequest(cr);
                Console.WriteLine("Appointement is succesfully edited!");
            }

        }

        public void Deny(CheckAppointementRequest cr) {
            cr.status = Status.DENIED;
            checkRequestService.Update(cr);
            Console.WriteLine("Request denied!");

        }
        public void Handle(String opt, CheckAppointementRequest cr) {

            if (opt.Equals("1"))               
            {
               Accept(cr);
            }
            else if (opt.Equals("2"))
            {
                Deny(cr);
            }


        }
    }
}
