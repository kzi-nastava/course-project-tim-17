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

namespace HealthcareSystem.AppStart;



static class Start
{

    public static void ProgramStart()
    {



        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Tim17:UXGhApWVw9oc6VGg@cluster0.se6mz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase("USI");
        UserController uc = new UserController(database);
        HealthCardController hc = new HealthCardController(database);

        Console.WriteLine(uc.userCollection);

        User loggedUser = null;
        Boolean notLogged = true;
        while (notLogged) {
            Console.WriteLine();
            Console.WriteLine("WELCOME TO OUR HEALTHCARE SYSTEM");
            Console.WriteLine("1 -> Log in");
            Console.WriteLine("2  -> Exit");
            Console.WriteLine("Choose option: ");
            string choice = Console.ReadLine();
            if (choice.Equals("1"))
            {
                Console.Write("Enter e-mail: ");
                string email = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                Console.WriteLine();
                loggedUser = Login.Validate(database, email, password);


                if (loggedUser != null)
                {
                    Console.WriteLine("HELLO!");
                    Console.WriteLine("You are logged in as: " +  loggedUser.role.ToString().ToUpper() +  "  ->  " + loggedUser.name + " " + loggedUser.lastName);
                    Console.WriteLine();
                    if (loggedUser.role == Role.MANAGER)
                    {
                        ManagerUI ui = new ManagerUI(database, loggedUser);
                        loggedUser = null;
                    }if (loggedUser.role == Role.SECRETARY) 
                    {
                        SecretaryControllers secretaryControllers = new SecretaryControllers(database);
                        SecretaryUI ui = new SecretaryUI(secretaryControllers, loggedUser);
                        loggedUser = null;
                        notLogged = true;
                    }

                   
                }
            }
            else if (choice.Equals("2")){
                break;
            }

        }

    }

   

    }

