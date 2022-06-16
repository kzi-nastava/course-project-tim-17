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
using HealthcareSystem.UI.Secretary;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.Entity.RoomModel.TransferEquipment;
using Autofac;

namespace HealthcareSystem.UI
{
    class SecretaryUI
    {
        public User LoggedUser { get; set; }
        public SecretaryControllers secretaryControllers { get; set; }
       
        public IMongoDatabase database;
        public RoomService roomService { get; set; }
        public HealthCardService healthCardService;

        public EquipmentRequestService equipmentService;
        public CheckAppointmentRequestService checkRequestService;
        public AppointmentService appointmentService;
        
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

        public void PrintAllPatients(List<User> patients)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (secretaryControllers.blockedUserController.GetByUserId(patients[i]._id) == null)
                {
                    Console.WriteLine(" ------------------------------------");
                    Console.WriteLine("Name: " + " " + patients[i].name);
                    Console.WriteLine("Last name: " + " " + patients[i].lastName);
                    Console.WriteLine("Email: " + " " + patients[i].email);
                    HealthCard found = null;
                    List<HealthCard> healthCards = secretaryControllers.healthCardController.GetAll();
                    foreach (HealthCard healthCard in healthCards)
                    {
                        if (healthCard.patientId == patients[i]._id)
                        {
                            found = healthCard;
                        }

                    }
                    Console.WriteLine("Weight: " + found.weight.ToString());
                    Console.WriteLine("height: " + found.height.ToString());
                    Console.WriteLine("Allergies: " + healthCardService.GetAllergies(found));
                }
            }
        }

        public void PrintPatientsWithReferrals(List<User> patients)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (secretaryControllers.blockedUserController.GetByUserId(patients[i]._id) == null)
                {
                    Console.WriteLine(" ------------------------------------");
                    Console.WriteLine("Name: " + " " + patients[i].name);
                    Console.WriteLine("Last name: " + " " + patients[i].lastName);
                    Console.WriteLine("Email: " + " " + patients[i].email);
                    HealthCard found = null;
                    List<HealthCard> healthCards = secretaryControllers.healthCardController.GetAll();
                    foreach (HealthCard healthCard in healthCards)
                    {

                        if (healthCard.patientId == patients[i]._id)
                        {
                            found = healthCard;
                        }
                    }
                    List<Referral> referrals = secretaryControllers.referralController.GetReferralsOfHealthCard(found);
                    if (referrals.Count > 0)
                    {
                        Console.WriteLine("REFERRALS:");
                        foreach (Referral r in referrals)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Referral's id: " + r._id);
                            Console.WriteLine("------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Patient has no referrals");
                    }
                }
            }

        }

        public void DeleteAppointementByRequest(CheckAppointementRequest cr)
        {
            Appointment a = secretaryControllers.AppointmentController.GetById(cr.appointmentId);
            secretaryControllers.AppointmentController.Delete(a._id);
        }

        public void EditAppointementByRequest(CheckAppointementRequest cr)
        {
            AppointmentRequests ar = secretaryControllers.appointmentRequestsController.GetById(cr.appointmentId);
            Appointment a = secretaryControllers.AppointmentController.GetById(ar.appointmentId);
            a.dateTime = ar.dateTime;
            a.doctorId = ar.doctorId;
            a.patientId = ar.patientId;
            a.roomId = ar.roomId;
            secretaryControllers.AppointmentController.Update(a);
        }

        public void HandleCRUD(string option)
        {
            UserService us = Globals.container.Resolve<UserService>();
            if (option.Equals("a"))
            {                                                                // adding patient
                User patient = us.AddPatient();
                if (patient != null)
                {
                    healthCardService.CreateHealthCard(patient);
                    Console.WriteLine("Patient is sucessfully created! ");
                }
                else
                {
                    Console.WriteLine("Sorry, patient already exists! ");
                }
            }
            else if (option.Equals("b"))                                                         // preview of patients 
            {
                List<User> patients = us.GetAll();
                PrintAllPatients(patients);
            }
            else if (option.Equals("c"))
            {                                                                            // update patient
                User patient = us.UpdateUser();
                Console.WriteLine("To edit patient's healthcard enter '1': ");
                string toEdit = Console.ReadLine();
                if (toEdit.Equals("1"))
                {
                    healthCardService.UpdateHealthCard(patient);
                }
                Console.WriteLine("Patient is sucessfully updated! ");
            }
            else if (option.Equals("d"))                            // delete patient        
            {
                User patient = us.DeleteUser();
                if (patient != null)
                {
                    healthCardService.DeleteHealthCard(patient);
                    Console.WriteLine("Patient is sucessfully deleted! ");
                }
                else
                {
                    Console.WriteLine("Sorry, patient with entered email does not exist! ");
                }
            }
        }

        public bool IsRoomAvailable(Room r, DateTime time)
        {
            List<Appointment> apointments = secretaryControllers.AppointmentController.GetAll();
            foreach (Appointment ap in apointments)
            {
                if (ap.roomId == r._id)
                {
                    TimeSpan ts = time.Subtract(ap.dateTime);
                    int hours = Convert.ToInt32(ts.TotalHours);
                    if (hours == 0) // ako je makar jednom razlika 0 sati => zauzeto
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void MakeAppointmentBasedOnReferral(Referral r, ApointmentType t)
        {
            ObjectId patientId = r.patientId;
            ObjectId doctorId = r.doctorId;
            Specialisation s = r.specialization;
            List<DateTime> doctorTimes = new List<DateTime>();
            List<Appointment> doctorsAppointments = secretaryControllers.AppointmentController.GetAllByDoctor(doctorId);   // dobila listu svih appointmenta od doktora
            foreach (Appointment ap in doctorsAppointments)
            {
                doctorTimes.Add(ap.dateTime);
            }
            DateTime suggestedDate = DateTime.Now.AddDays(3);                     // stavljam kao prjedlog da je ovo datum
            suggestedDate = suggestedDate.Date.Add(new TimeSpan(12, 00, 00));
            DateTime doctorAvailable = suggestedDate;
            List<Room> allRooms = secretaryControllers.roomController.GetAll();
            Room availableRoom = allRooms[0];                                       // pocetna soba koju provjeravam
            bool notBreak = true;
            bool done = false;
            while (notBreak)
            {
                foreach (DateTime d in doctorTimes)
                {
                    TimeSpan ts = suggestedDate - d;
                    double hours = Math.Abs(ts.TotalHours);
                    if (hours - 2 > 0)
                    {
                        doctorAvailable = suggestedDate;
                        foreach (Room room in allRooms)
                        {

                            if (IsRoomAvailable(room, doctorAvailable))
                            {
                                availableRoom = room;
                                done = true;

                            }
                            if (done)
                            {
                                break;
                            }

                        }
                        notBreak = false;
                    }
                    else
                    {
                        suggestedDate = suggestedDate.AddHours(2);
                    }
                }
            }
            Appointment a = new Appointment(doctorAvailable, t, doctorId, availableRoom._id, patientId);
            secretaryControllers.AppointmentController.Insert(a);
            secretaryControllers.referralController.Delete(r._id);
            Console.WriteLine("Date of appointment: " + suggestedDate.ToString());
            Console.WriteLine("Room: " + availableRoom.name);
        }

        public List<Appointment> GetAppointmentsOfDoctors(List<Doctor> doctors) {
            List<Appointment> all =appointmentService.GetAll();
            List<Appointment> scheduledAppointments = new List<Appointment>();
            foreach (Doctor d in doctors) {
                List<Appointment> doctorsAppointments = secretaryControllers.AppointmentController.GetAllByDoctor(d._id);
                foreach (Appointment a in doctorsAppointments)
                {
                    scheduledAppointments.Add(a);
                }
            }

            return scheduledAppointments;
        }

        public void ResheduleAppointment(Appointment a) {
            DateTime suggestedDate = DateTime.Now;
            suggestedDate = suggestedDate.AddDays(2);
            a.dateTime = suggestedDate.Date.Add(new TimeSpan(15, 00, 00));
            secretaryControllers.AppointmentController.Update(a);
            Console.WriteLine("Appointment has been resheduled for: " + a.dateTime);
            Console.WriteLine();
        }

        public List<Appointment> GetAppointmentsInNextTwoHours(List<Appointment> doctorsAppointments) {
            List<Appointment> appointmentsInNextTwoHours = new List<Appointment>();
            DateTime today = DateTime.Now;
            foreach (Appointment ap in doctorsAppointments)
            {
                if (ap.dateTime.Date == DateTime.Today)                                                              // da li je datum danas
                {
                    TimeSpan ts = today - ap.dateTime;
                    double hours = ts.Hours;
                    if (hours < 5)
                    {
                        appointmentsInNextTwoHours.Add(ap);
                    }

                }
            }
            return appointmentsInNextTwoHours;


        }

        public void MakeUrgentAppointment(List<Doctor> doctors, ObjectId patientId, ApointmentType t)
        {
            List<Appointment> doctorsAppointments = GetAppointmentsOfDoctors(doctors);   // dobila listu svih appointmenta od doktora
            List<Room> rooms = secretaryControllers.roomController.GetAll();
            DateTime searchedDate;
            Room searchedRoom;
            doctorsAppointments.Sort((a, b) => a.dateTime.CompareTo(b.dateTime));
            List<Appointment> appointmentsInNextTwoHours = GetAppointmentsInNextTwoHours(doctorsAppointments);
            if (appointmentsInNextTwoHours.Count > 0)
            {
                Console.WriteLine("Doctors are not available! ");
                Console.WriteLine("Here are their appointements: ");
                foreach (Appointment app in doctorsAppointments) {
                    if (app.dateTime.Date > DateTime.Today && app.dateTime.Date.Year == 2022)
                    {
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("Date: " + app.dateTime);
                        Console.WriteLine("DoctorId: " + app.doctorId);
                        Console.WriteLine("Appointmetn ID: " + app._id);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Enter ID of appointment you want to reschedule: ");
                ObjectId apId = ObjectId.Parse(Console.ReadLine());
                DateTime date = secretaryControllers.AppointmentController.GetById(apId).dateTime;
                ResheduleAppointment(secretaryControllers.AppointmentController.GetById(apId));

                ObjectId roomId = secretaryControllers.AppointmentController.GetById(apId).roomId;
                Appointment a = new Appointment(date, t, doctors[0]._id, roomId, patientId);
                Console.WriteLine("Appointment has been sucessfully made!");
                Console.WriteLine("Room: " + secretaryControllers.roomController.GetById(roomId).name);
                Console.WriteLine("Date and time: " + date.ToString());
                secretaryControllers.AppointmentController.Insert(a);

            }
            else
            {
                searchedDate = DateTime.Now.AddMinutes(30);
                foreach (Room r in rooms)
                {
                    if (IsRoomAvailable(r, searchedDate))
                    {
                        searchedRoom = r;
                        Appointment a = new Appointment(searchedDate, t, doctors[0]._id, searchedRoom._id, patientId);
                        Console.WriteLine("Appointment has been sucessfully made!");
                        Console.WriteLine("Room: " + searchedRoom.name);
                        Console.WriteLine("Date and time: " + searchedDate.ToString());
                        secretaryControllers.AppointmentController.Insert(a);
                        break;
                    }
                }
            }

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
            UserService us = Globals.container.Resolve<UserService>();
            CheckAppointmentRequestService crs = Globals.container.Resolve<CheckAppointmentRequestService>();
           // EquipmentRequestService ers = new EquipmentRequestService(database);
          //  SecretaryAppointmentService a = new SecretaryAppointmentService(database);
            FreeDayRequestService fs = Globals.container.Resolve<FreeDayRequestService>();

            List<User> patients = us.GetAllPatients();
            BlockPatient b = new BlockPatient(secretaryControllers);
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
                            CRUD c = new CRUD(secretaryControllers);
                            c.HandleCRUD(option);
                        }
                    }
                }
                else if (choice == "2")
                {

                    us.PrintAllPatients(patients);
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
                    us.PrintPatientsWithReferrals(patients);
                    Console.WriteLine("Enter '1' to make an appointment based on referral: ");
                    if (Console.ReadLine() == "1")
                    {
                        Console.WriteLine("Enter referral id: ");
                        ObjectId idRefferal = ObjectId.Parse(Console.ReadLine());
                        Referral r = secretaryControllers.referralController.GetById(idRefferal);
                        Console.WriteLine("Enter type of appointment(checkup/operation): ");
                        ApointmentType type = (ApointmentType)Enum.Parse(typeof(ApointmentType), (Console.ReadLine().ToUpper()));
                        MakeAppointmentBasedOnReferral(r, type);
                        Console.WriteLine("Appointement is succesfully created!");
                    }

                }
                else if (choice == "6")
                {
                    us.PrintAllPatients(patients);
                    Console.WriteLine("Enter patient email: ");
                    String patientEmail = Console.ReadLine();
                    PrintAllSpecializations();
                    Console.WriteLine("Enter specialization: ");
                    Specialisation s = (Specialisation)Enum.Parse(typeof(Specialisation), (Console.ReadLine().ToUpper()));

                    List<Doctor> doctors = secretaryControllers.doctorController.FindDoctorsBySpecialisation(s);

                    User patient = secretaryControllers.userController.GetByEmail(patientEmail);
                    Console.WriteLine("Enter type of appointment(checkup/operation): ");
                    ApointmentType type = (ApointmentType)Enum.Parse(typeof(ApointmentType), (Console.ReadLine().ToUpper()));
                    MakeUrgentAppointment(doctors, patient._id, type);
                }
                else if (choice == "7")
                {
                    Room warehouse = secretaryControllers.roomController.getWarehouse();
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
                    List<Room> rooms = secretaryControllers.roomController.GetAll();
                    roomService.PrintRoomsNeedingEquipment(rooms);
                    Console.WriteLine("Enter room ID which needs more equipment: ");
                    ObjectId roomIdInto = ObjectId.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the name of equipment: ");
                    String name = Console.ReadLine();
                    Console.WriteLine();
                    roomService.PrintRoomsWhichHaveSpecificEquipment(rooms, name);
                    Console.WriteLine("Enter room ID from which you transfer: ");
                    ObjectId roomIdFrom = ObjectId.Parse(Console.ReadLine());
                    Room from = secretaryControllers.roomController.GetById(roomIdFrom);
                    Room into = secretaryControllers.roomController.GetById(roomIdInto);
                    TransferEquipment te = new TransferEquipment();
                    te.Transfer(from, into, name);
                } else if (choice == "10") {

                    fs.PrintAllFreeDayRequests();
                    Console.WriteLine("Enter request id: ");
                    ObjectId obI = ObjectId.Parse(Console.ReadLine());
                    FreeDayRequest freeDayRequest = fs.GetById(obI);
                    Console.WriteLine(freeDayRequest._id);
                    Console.WriteLine("1 -> APPROVE REQUEST");
                    Console.WriteLine("2 -> DECLINE REQUEST");
                    string opt = Console.ReadLine();
                    HandleFreeDayRequests h = new HandleFreeDayRequests();
                    h.Handle(opt, freeDayRequest, fs);

                }
                else if (choice == "11")
                {

                    break;
                }
            }

        }

    }
}
