﻿using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Functions;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.UI;
using MongoDB.Driver;
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
        UserController uc = new UserController(database);
        HealthCardController hc = new HealthCardController(database);

        Console.WriteLine(uc.userCollection);

        User loggedUser = null;
        Boolean notLogged = true;
        string choice = "";
        while (notLogged) {
            if(choice == "x")
            {
                break;
            }
            Console.WriteLine();
            Console.WriteLine("WELCOME TO OUR HEALTHCARE SYSTEM");
            Console.WriteLine("1 -> Log in");
            Console.WriteLine("x  -> Exit");
            Console.WriteLine("Choose option: ");
            choice = Console.ReadLine();
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
                    Console.WriteLine("You are logged in as: " + loggedUser.role.ToString().ToUpper() + "  ->  " + loggedUser.name + " " + loggedUser.lastName);
                    if (loggedUser != null && loggedUser.role == Role.MANAGER)
                    {
                        ManagerControllers managerControllers = new ManagerControllers(database);
                        ManagerUI ui = new ManagerUI(managerControllers, loggedUser);
                        loggedUser = null;
                   
                    }
                    if (loggedUser != null && loggedUser.role == Role.SECRETARY) 
                    {
                        SecretaryControllers secretaryControllers = new SecretaryControllers(database);
                        SecretaryUI ui = new SecretaryUI(secretaryControllers, loggedUser);
                        loggedUser = null;
                  
                    }

                    if (loggedUser != null && loggedUser.role == Role.DOCTOR)
                    {
                        DoctorRepositories doctorRepositories = new DoctorRepositories(database);
                        DoctorUi ui = new DoctorUi((Doctor)loggedUser, doctorRepositories);
                        loggedUser = null;
                    
                        
                    }
                    if (loggedUser != null && loggedUser.role == Role.PATIENT)
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

    }

   

    }
