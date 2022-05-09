using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserActionModel;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;

namespace HealthcareSystem.UI
{
    class PatientUI{
        public PatientRepositories patientRepositories { get; set; }
        public User loggedUser {get; set;}
        public PatientUI(PatientRepositories patientRepositories, User loggedUser)
        {
            this.loggedUser = loggedUser;
            this.patientRepositories = patientRepositories;
            this.UI();
        }
        public void UI(){
            string option = "";
            ApointmentService apointmentservice = new ApointmentService(patientRepositories, loggedUser);
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