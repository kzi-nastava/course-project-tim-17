using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Driver;
using Autofac;
using MongoDB.Bson;

using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;
using HealthCareSystem.Entity.CheckAppointementRequestModel;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.ReferralModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.UI.SecretaryView;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.Entity.RoomModel.TransferEquipment;
using Autofac;
using HealthcareSystem.UI.SecretaryView;

namespace HealthcareSystem.UI
{
    class SecretaryUI
    {
        public User LoggedUser { get; set; }
        public SecretaryControllers secretaryControllers { get; set; }
       
        public IMongoDatabase database;
        public RoomService roomService { get; set; }
        public HealthCardService healthCardService;
        public UserService userService;
        public EquipmentRequestService equipmentService;
        public CheckAppointmentRequestService checkRequestService;
        public AppointmentService appointmentService;
        public FreeDayRequestService freeDayRequestService;
        public ReferralService referralService; 
        
        public SecretaryUI(SecretaryControllers secretaryControllers, User LoggedUser, IMongoDatabase database)
        {
            this.LoggedUser = LoggedUser;
            this.secretaryControllers = secretaryControllers;
            this.database = database;
            roomService = Globals.container.Resolve<RoomService>();
            healthCardService = Globals.container.Resolve<HealthCardService>();
            equipmentService = Globals.container.Resolve<EquipmentRequestService>();
            checkRequestService = Globals.container.Resolve<CheckAppointmentRequestService>();
            appointmentService = Globals.container.Resolve<AppointmentService>();
            userService = Globals.container.Resolve<UserService>();
            freeDayRequestService = Globals.container.Resolve<FreeDayRequestService>();
            referralService = Globals.container.Resolve<ReferralService>();
            this.UI();
        }

        public static void PrintCRUDMeni()
        {
            Console.WriteLine("a -> CREATE NEW ACCOUNT");
            Console.WriteLine("b -> PREVIEW OF ACCOUNTS");
            Console.WriteLine("c -> UPDATE ACCOUNT");
            Console.WriteLine("d -> DELETE ACCOUNT");
            Console.WriteLine("x -> EXIT");

        }

        public static void PrintAllSpecializations() {
            Console.WriteLine(Specialisation.GYNECOLOGY);
            Console.WriteLine(Specialisation.PEDIATRICS);
            Console.WriteLine(Specialisation.OPHTHALMOLOGY);
            Console.WriteLine(Specialisation.INTERNAL_MEDICINE);
            Console.WriteLine(Specialisation.DERMATOLOGY);

        }
        
        public void UI()
        {
            List<User> patients = userService.GetAllPatients();
            BlockPatient b = new BlockPatient();
            while (true)
            {
                Console.WriteLine("1 -> CREATE/READ/UPDATE/DELETE PATIENT'S ACCOUNT");
                Console.WriteLine("2 -> BLOCK PATIENT");
                Console.WriteLine("3 -> OVERVIEW OF BLOCKED PATIENTS");
                Console.WriteLine("4 -> OVERVIEW OF REQUESTS FOR UPDATE/DELETION OF CHECKUPS");
                Console.WriteLine("5 -> MAKE AN APPOINTMENT FOR CHECK/OPERATION BASED ON REFFERAL");
                Console.WriteLine("6 -> MAKE AN APPOINTMENT FOR URGENT CHECK/OPERATION ");
                Console.WriteLine("7 -> CREATE A REQUEST FOR PURCHASE OF DYNAMIC EQUIPMENT ");
                Console.WriteLine("8 -> CHECK EQUIPMENT REQUESTS ");
                Console.WriteLine("9 -> ARRANGE DYNAMIC EQUIPMENT ");
                Console.WriteLine("10 -> OVERVIEW OF REQUESTS FOR DAYS OFF");
                Console.WriteLine("11 -> LOG OUT");
                Console.WriteLine("Enter option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    bool done = false;
                    while (!done)
                    {
                        PrintCRUDMeni();
                        Console.WriteLine("Enter option: ");
                        string option = Console.ReadLine();
                        if (option.Equals("x"))
                        {
                            done = true;
                            break;
                        }
                        else
                        {
                            CRUD c = new CRUD();
                            c.HandleCRUD(option);
                        }
                    }
                }
                else if (choice == "2")
                {

                    userService.PrintAllPatients(patients);
                    b.Block();

                }
                else if (choice == "3")
                {
                    secretaryControllers.blockedUserController.PrintBlockedUsers();
                    Console.WriteLine("Enter '1' to unblock a patient: ");
                    string response = Console.ReadLine();
                    if (response.Equals("1"))
                    {
                        b.Unblock();
                    }
                }
                else if (choice == "4")
                {
                    checkRequestService.PrintAllRequests();
                    Console.WriteLine("Enter request id: ");
                    ObjectId obI = ObjectId.Parse(Console.ReadLine());
                    CheckAppointementRequest cr = checkRequestService.GetById(obI);
                    Console.WriteLine("1 -> APPROVE REQUEST");
                    Console.WriteLine("2 -> DECLINE REQUEST");
                    string opt = Console.ReadLine();
                    HandleAppointmentRequests h = new HandleAppointmentRequests();
                    h.Handle(opt, cr);

                }
                else if (choice == "5")
                {
                    userService.PrintPatientsWithReferrals(patients);
                    Console.WriteLine("Enter '1' to make an appointment based on referral: ");
                    if (Console.ReadLine() == "1")
                    {
                        Console.WriteLine("Enter referral id: ");
                        ObjectId idRefferal = ObjectId.Parse(Console.ReadLine());
                        Referral r = referralService.GetById(idRefferal);
                        Console.WriteLine("Enter type of appointment(checkup/operation): ");
                        ApointmentType type = (ApointmentType)Enum.Parse(typeof(ApointmentType), (Console.ReadLine().ToUpper()));
                        HandleRefferal h = new HandleRefferal();
                        h.MakeAppointmentBasedOnReferral(r, type);
                        Console.WriteLine("Appointement is succesfully created!");
                    }

                }
                else if (choice == "6")
                {
                    userService.PrintAllPatients(patients);
                    Console.WriteLine("Enter patient email: ");
                    String patientEmail = Console.ReadLine();
                    PrintAllSpecializations();
                    Console.WriteLine("Enter specialization: ");
                    Specialisation s = (Specialisation)Enum.Parse(typeof(Specialisation), (Console.ReadLine().ToUpper()));

                    List<Doctor> doctors = secretaryControllers.doctorController.FindDoctorsBySpecialisation(s);

                    User patient = userService.GetByEmail(patientEmail);
                    Console.WriteLine("Enter type of appointment(checkup/operation): ");
                    ApointmentType type = (ApointmentType)Enum.Parse(typeof(ApointmentType), (Console.ReadLine().ToUpper()));
                    UrgentAppointment u = new UrgentAppointment();
                    u.MakeUrgentAppointment(doctors, patient._id, type);
                   
                }
                else if (choice == "7")
                {
                    Room warehouse = roomService.getWarehouse();
                    roomService.PrintLackingEquipmentFromWareHouse(warehouse);
                    Console.WriteLine("Enter '1' to make a request: ");
                    if (Console.ReadLine().Equals("1"))
                    {
                        equipmentService.MakeEquipmentRequest();
                    }
                }
                else if (choice == "8")
                {
                    List<EquipmentRequest> requests = equipmentService.GetAll();
                    if (requests.Count == 0)
                    {

                        Console.WriteLine("NO REQUESTS! ");
                    }
                    else
                    {
                        equipmentService.PrintAllEquipmentRequest(requests);
                        Console.WriteLine();
                        FulfillEquipmentRequest request = new FulfillEquipmentRequest();
                        request.Fulfiil();
                    }
                }
                else if (choice == "9") {
                    List<Room> rooms = roomService.GetAll();
                    roomService.PrintRoomsNeedingEquipment(rooms);
                    Console.WriteLine("Enter room ID which needs more equipment: ");
                    ObjectId roomIdInto = ObjectId.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the name of equipment: ");
                    String name = Console.ReadLine();
                    Console.WriteLine();
                    roomService.PrintRoomsWhichHaveSpecificEquipment(rooms, name);
                    Console.WriteLine("Enter room ID from which you transfer: ");
                    ObjectId roomIdFrom = ObjectId.Parse(Console.ReadLine());
                    Room from = roomService.GetById(roomIdFrom);
                    Room into = roomService.GetById(roomIdInto);
                    TransferEquipment te = new TransferEquipment();
                    te.Transfer(from, into, name);
                } else if (choice == "10") {
                    freeDayRequestService.PrintAllFreeDayRequests();
                    Console.WriteLine("Enter the serial number of request: ");
                    int index = Int32.Parse(Console.ReadLine());
                    List<FreeDayRequest> requests = freeDayRequestService.GetAll();
                    Console.WriteLine("1 -> APPROVE REQUEST");
                    Console.WriteLine("2 -> DECLINE REQUEST");
                    string opt = Console.ReadLine();
                    HandleFreeDayRequests h = new HandleFreeDayRequests();
                    h.Handle(opt, requests[index - 1]);
                    Console.WriteLine("Notification is sent!");
                }
                else if (choice == "11")
                {
                    break;
                }
            }

        }

    }
}
