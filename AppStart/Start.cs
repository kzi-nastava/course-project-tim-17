using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.RoomModel;
using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.HealthCardModel;
using MongoDB.Bson;
using HealthcareSystem.Functions;
using HealthcareSystem.UI;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.UserActionModel;

namespace HealthcareSystem.AppStart;



static class Start
{

    public static void ProgramStart()
    {
    

  
        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Tim17:UXGhApWVw9oc6VGg@cluster0.se6mz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase("USI");


        User loggedUser = null;

        while (loggedUser == null) {
            Console.WriteLine("############Hospital: Novak Djokovic####################");
            Console.Write("Enter e-mail(or x for exti): ");
            string email = Console.ReadLine();
            if(email == "x")
            {
                loggedUser = null;
                break;
            }
            Console.WriteLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            loggedUser = Login.validate(database, email, password);


        }


        if (loggedUser != null)
        {
            Console.WriteLine(loggedUser.name);


            if (loggedUser.role == Role.MANAGER)
            {
                ManagerControllers managerControllers = new ManagerControllers(database);
                ManagerUI ui = new ManagerUI(managerControllers,loggedUser);
                loggedUser = null;
            }
            if (loggedUser.role == Role.PATIENT)
            {
                PatientControllers patientControllers = new PatientControllers(database);
                ApointmentController apointmentController = new ApointmentController(database);
                DoctorController doctorController = new DoctorController(database);
                RoomController roomController = new RoomController(database);
                UserActionController userActionController = new UserActionController(database);
                BlockedUserController blockedUserController = new BlockedUserController(database);
                PatientUI ui = new PatientUI(patientControllers, apointmentController, doctorController, roomController, userActionController, blockedUserController, loggedUser);
                loggedUser = null;
            }
        }
    }

}
