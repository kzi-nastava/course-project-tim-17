﻿using HealthcareSystem.Entity.DrugModel;
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
 using HealthcareSystem.RoleControllers;
 using HealthcareSystem.UI;

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
                loggedUser = Login.validate(database, email, password);


                if (loggedUser != null)
                {
                    Console.WriteLine("HELLO!");
                    Console.WriteLine("You are logged in as: ");
                    Console.WriteLine(loggedUser.name, loggedUser.lastName);
                    if (loggedUser.role == Role.MANAGER)
                    {
                        // ManagerUI ui = new ManagerUI(database, loggedUser);
                        // loggedUser = null;
                        Console.WriteLine("Manager");
                    }
                    if (loggedUser.role == Role.SECRETARY) 
                    {
                        // SecretaryUI ui = new SecretaryUI(database, loggedUser);
                        // loggedUser = null;
                        Console.WriteLine("Secretary");
                    }

                    if (loggedUser.role == Role.DOCTOR)
                    {
                        DoctorRepositories doctorRepositories = new DoctorRepositories(database);
                        DoctorUi ui = new DoctorUi((Doctor)loggedUser, doctorRepositories);
                        loggedUser = null;
                        
                    }

                    notLogged = false;
                }
            }
            else if (choice.Equals("2")){
                break;
            }

        }

    }

   

    }
