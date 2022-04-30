using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DoctorModel;
using MongoDB.Driver;
using HealthcareSystem.RoleControllers;
using MongoDB.Bson;

namespace HealthcareSystem.UI
{
    class DoctorUi
    {
        public Doctor loggedDoctor { get; set; }
        public DoctorRepositories doctorRepositories { get; set; }

        public DoctorUi(Doctor loggedDoctor, DoctorRepositories doctorRepositories)
        {
            this.loggedDoctor = loggedDoctor;
            this.doctorRepositories = doctorRepositories; 
            Ui();
        }

        public void Ui()
        {
            AppointmentService appointmentService = new AppointmentService(doctorRepositories);
            PrintMenu();
            string option = Console.ReadLine();
            while (option != "x")
            {
                if (option == "1")
                {
                    ApointmentCRUD();
                }

                if (option == "2")
                {
                    Schedule();
                }

                else
                {
                    Console.WriteLine("Option does not exist!");
                }
                PrintMenu();
                option = Console.ReadLine();
            }
            

        }

        public void Schedule()
        {
            AppointmentService appointmentService = new AppointmentService(doctorRepositories);
            appointmentService.PrintSchedule(loggedDoctor);
            //To do:
            //Checkup executing
            
        }
        
        public void PrintMenu()
        {
            Console.WriteLine("1 -> CRUD for appointments");
            Console.WriteLine("2 -> Schedule");
            Console.WriteLine("x -> Logout");
            Console.WriteLine("Choose option: ");
        }

        public void ApointmentCRUD()
        {
            AppointmentService appointmentService = new AppointmentService(doctorRepositories);
            string option = "";
            PrintApointmentCRUDMenu();
            option = Console.ReadLine();
            while (option != "x")
            {
                if (option == "1")
                {
                    appointmentService.AddAppointment(loggedDoctor);
                }

                if (option == "2")
                {
                    
                    Console.WriteLine("Enter Id of an Apointment: ");
                    string apointmentId = Console.ReadLine();
                    Apointment apointment =
                        doctorRepositories.apointmentController.apointmentCollection.Find(item =>
                            item._id == new ObjectId(apointmentId)).FirstOrDefault();
                    
                    string choice = "";
                    Console.WriteLine("1 -> Change date and time");
                    Console.WriteLine("2 -> Change Room");
                    Console.WriteLine("x -> Exit");
                    Console.WriteLine("Choose option: ");
                    choice = Console.ReadLine();
                    while (choice != "x")
                    {
                        if (choice == "1")
                        {
                            appointmentService.UpdateApointmentDate(apointment);
                        }
                        else if (choice == "2")
                        {
                            appointmentService.UpdateApointmentRoom(apointment);
                        }
                        else
                        {
                            Console.WriteLine("Option is not valid!");
                        }
                        Console.WriteLine("1 -> Change date and time");
                        Console.WriteLine("2 -> Change Room");
                        Console.WriteLine("x -> Exit");
                        Console.WriteLine("Choose option: ");
                        choice = Console.ReadLine();
                    }
                    
                }

                if (option == "3")
                {
                    appointmentService.PrintApointments(loggedDoctor);
                }

                if (option == "4")
                {
                    Console.WriteLine("Enter Id of an Apointment: ");
                    string apointmentId = Console.ReadLine();
                    Apointment apointment =
                        doctorRepositories.apointmentController.apointmentCollection.Find(item =>
                            item._id == new ObjectId(apointmentId)).FirstOrDefault();
                    doctorRepositories.apointmentController.DeleteApointment(apointment);
                    Console.WriteLine("Apointment(ID-" + apointment._id.ToString() + ") deleted!");
                }
                
                else
                {
                    Console.WriteLine("Invalid option! ");
                }

                PrintApointmentCRUDMenu();
                option = Console.ReadLine();
            }
            
        }

        private void PrintApointmentCRUDMenu()
        {
            Console.WriteLine("1 -> Create appointment");
            Console.WriteLine("2 -> Update appointment");
            Console.WriteLine("3 -> Print appointments");
            Console.WriteLine("4 -> Delete appointment");
            Console.WriteLine("x -> Exit");
            Console.WriteLine("Choose option: ");
        }
    }
}
