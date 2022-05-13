using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;
using HealthcareSystem.Entity.Enumerations;
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
            List<CheckAppointementRequest> crs = secretaryControllers.checkAppointemtRequestController.GetAllCheckAppointmentRequests();
            User patient;
            foreach (CheckAppointementRequest c in crs)
            {
                Console.WriteLine("APPOINTMENT INFO: ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("ID: " + c._id);
                if (c.RequestState == RequestState.DELETE)
                {
                    Apointment ap = secretaryControllers.AppointemtController.FindById(c.appointmentId);
                    if (ap == null) { Console.WriteLine("This appointment has been deleted! "); }
                    else
                    {
                        patient = secretaryControllers.userController.FindById(secretaryControllers.AppointemtController.FindById(c.appointmentId).patientId);
                        Console.WriteLine("PATIENT: " + patient.name + " " + patient.lastName);
                        Console.WriteLine("ROOM: :  " + secretaryControllers.roomController.findById(ap.roomId).name);
                        Console.WriteLine("DATE: " + ap.dateTime.ToString());
                    }
                    Console.WriteLine("REQUEST: " + c.RequestState.ToString());
                    Console.WriteLine("STATUS: " + c.status.ToString());
                }
                else
                {
                    AppointmentRequests ar = secretaryControllers.appointmentRequestsController.FindById(c.appointmentId);

                    Apointment ap = secretaryControllers.AppointemtController.FindById(ar.appointmentId);

                    patient = secretaryControllers.userController.FindById(ap.patientId);
                    Console.WriteLine("PATIENT: " + patient.name + " " + patient.lastName);
                    Console.WriteLine("ROOM: :  " + secretaryControllers.roomController.findById(ap.roomId).name);
                    Console.WriteLine("DATE: " + ap.dateTime.ToString());
                    Console.WriteLine("REQUEST: " + c.RequestState.ToString());
                    Console.WriteLine("STATUS: " + c.status.ToString());

                }
            }

        }

     
        public void DeleteRequest(ObjectId id)
        {
            CheckAppointementRequest cr = secretaryControllers.checkAppointemtRequestController.FindById(id);
            secretaryControllers.checkAppointemtRequestController.DeleteCheckAppointementRequestCard(cr);

        }

        public void Update(CheckAppointementRequest cr)
        {
            secretaryControllers.checkAppointemtRequestController.Update(cr);
        }

    }
}
