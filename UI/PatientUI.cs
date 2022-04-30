using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserActionModel;

namespace HealthcareSystem.UI
{
    class PatientUI{
        public User loggedUser {get; set;}
        public PatientControllers patientControllers {get;set;}
        public ApointmentController apointmentController {get;set;}
        public DoctorController doctorController {get;set;}
        public RoomController roomController {get; set;}
        public UserActionController userActionController {get; set;}
        public BlockedUserController blockedUserController {get; set;}
        public PatientUI(PatientControllers patientControllers, ApointmentController apointmentController, DoctorController doctorController, RoomController roomController, UserActionController userActionController, BlockedUserController blockedUserController, User loggedUser)
        {
            this.loggedUser = loggedUser;
            this.patientControllers = patientControllers;
            this.apointmentController = apointmentController;
            this.doctorController = doctorController;
            this.roomController = roomController;
            this.userActionController = userActionController;
            this.blockedUserController = blockedUserController;
            this.UI();
        }
        public void UI(){
            string option = "";
            ApointmentService apointmentservice = new ApointmentService(patientControllers, apointmentController, doctorController, roomController, userActionController, blockedUserController, loggedUser);
            while (true){
                Console.WriteLine("1. Appointment Scheduling");
                Console.WriteLine("2. Read Appointment");
                Console.WriteLine("3. Change Appointment");
                Console.WriteLine("4. Delete Appointment");
                Console.WriteLine("X. Exit");
                option = Console.ReadLine();
                if (option == "1"){
                    apointmentservice.addApointment();
                }
                if (option == "2"){
                    apointmentservice.readApointment();
                }
                if (option == "3"){
                    apointmentservice.changeApointment();
                }
                if (option == "4"){
                    apointmentservice.deleteApointment();
                }
                if (option == "X" || option == "x"){
                    return;
                }
            }   
        }
    }
}