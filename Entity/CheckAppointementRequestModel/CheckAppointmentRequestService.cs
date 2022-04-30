using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.CheckAppointemtRequestModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Bson;

namespace HealthCareSystem.Entity.CheckAppointementRequestModel
{
    class CheckAppointmentRequestService
    {

        public SecretaryControllers secretaryControllers { get; set; }


        public CheckAppointmentRequestService(SecretaryControllers sc)
        {
            this.secretaryControllers = sc;
        }

        public void printAllRequests()
        {
            List<CheckAppointementRequest> crs  = secretaryControllers.checkAppointemtRequestController.GetAllCheckAppointmentRequests();
            foreach(CheckAppointementRequest c in crs)
            {
                Console.WriteLine("APPOINTMENT INFO: ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("ID: " + c._id);
                Apointment ap = secretaryControllers.AppointemtController.FindById(c.appointmentId);
                User patient = secretaryControllers.userController.FindById((secretaryControllers.AppointemtController.FindById(c.appointmentId).patientId));
                Console.WriteLine("PATIENT: " + patient.name +  " " + patient.lastName);
                Console.WriteLine("ROOM: :  " + secretaryControllers.roomController.findById(ap.roomId).name);
                Console.WriteLine("DATE: " + ap.dateTime.ToString());
                Console.WriteLine("REQUEST: " + c.RequestState.ToString());
                Console.WriteLine("STATUS: " + c.status.ToString());
            }
        }

        public void DeleteRequest()
        {
            string id = Console.ReadLine();
            ObjectId obI = ObjectId.Parse(id);
            CheckAppointementRequest cr = secretaryControllers.checkAppointemtRequestController.FindById(obI);
            secretaryControllers.checkAppointemtRequestController.DeleteCheckAppointementRequestCard(cr);

        }

        public void Update(CheckAppointementRequest cr) {
            secretaryControllers.checkAppointemtRequestController.Update(cr);
        }
      
    }
}
