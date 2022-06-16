using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Bson;
namespace HealthCareSystem.Entity.CheckAppointementRequestModel
{
    class CheckAppointmentRequestService
    {

        public SecretaryControllers secretaryControllers { get; set; }

        public ICheckAppointmentRequestRepository checkAppointmentRequestRepository;
        public IAppointmentRepository appointmentRepository;
        public IRoomRepository roomRepository;
        public IAppointmentRequestRepository appointmentRequestRepository;
        public CheckAppointmentRequestService(ICheckAppointmentRequestRepository checkAppointmentRequestRepository, IAppointmentRepository appointmentRepository, IRoomRepository roomRepository, IAppointmentRequestRepository appointmentRequestRepository)
        {
            this.checkAppointmentRequestRepository = checkAppointmentRequestRepository;
            this.appointmentRepository = appointmentRepository;
            this.roomRepository = roomRepository;
            this.appointmentRequestRepository = appointmentRequestRepository;   
        }

        public void PrintAllRequests()
        {
            List<CheckAppointementRequest> crs = checkAppointmentRequestRepository.GetAllCheckAppointmentRequests();
            User patient;
            foreach (CheckAppointementRequest c in crs)
            {
                Console.WriteLine("APPOINTMENT INFO: ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("ID: " + c._id);
                if (c.RequestState == RequestState.DELETE)
                {
                    Appointment ap = appointmentRepository.GetById(c.appointmentId);
                    if (ap == null) { Console.WriteLine("This appointment has been deleted! "); }
                    else
                    {
                        patient = secretaryControllers.userController.GetById(secretaryControllers.AppointmentController.GetById(c.appointmentId).patientId);
                        Console.WriteLine("PATIENT: " + patient.name + " " + patient.lastName);
                        Console.WriteLine("ROOM: :  " + roomRepository.GetById(ap.roomId).name);
                        Console.WriteLine("DATE: " + ap.dateTime.ToString());
                    }
                    Console.WriteLine("REQUEST: " + c.RequestState.ToString());
                    Console.WriteLine("STATUS: " + c.status.ToString());
                }
                else
                {
                    AppointmentRequests ar = appointmentRequestRepository.GetById(c.appointmentId);

                    Appointment ap = appointmentRepository.GetById(ar.appointmentId);
                    if (ap == null) { Console.WriteLine("This appointment has been deleted! "); }
                    else
                    {
                        patient = secretaryControllers.userController.GetById(ap.patientId);
                        Console.WriteLine("PATIENT: " + patient.name + " " + patient.lastName);
                        Console.WriteLine("ROOM: :  " + roomRepository.GetById(ap.roomId).name);
                        Console.WriteLine("DATE: " + ap.dateTime.ToString());
                        Console.WriteLine("REQUEST: " + c.RequestState.ToString());
                        Console.WriteLine("STATUS: " + c.status.ToString());
                    }
                    Console.WriteLine("REQUEST: " + c.RequestState.ToString());
                    Console.WriteLine("STATUS: " + c.status.ToString());
                }
            }

        }

     
        public void DeleteRequest(ObjectId id)
        {
            CheckAppointementRequest cr = checkAppointmentRequestRepository.GetById(id);
            checkAppointmentRequestRepository.Delete(cr._id);

        }

        public void Update(CheckAppointementRequest cr)
        {

            checkAppointmentRequestRepository.Update(cr);
        }


        public CheckAppointementRequest GetById(ObjectId id) {
            return checkAppointmentRequestRepository.GetById(id);
        
        }

    }
}
