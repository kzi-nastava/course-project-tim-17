using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.UserModel;
using HealthCareSystem.Entity.UserModel;
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

namespace HealthcareSystem.UI
{
    class SecretaryUI
    {
        public User LoggedUser { get; set; }
        public SecretaryControllers secretaryControllers { get; set; }
       
        public IMongoDatabase database;
        public RoomService roomService { get; set; }

        public EquipmentRequestService equipmentService { get; set; }

        public SecretaryUI(SecretaryControllers secretaryControllers, User LoggedUser, IMongoDatabase database)
        {
            this.LoggedUser = LoggedUser;
            this.secretaryControllers = secretaryControllers;
            this.database = database;
            roomService = Globals.container.Resolve<RoomService>();
            this.equipmentService = new EquipmentRequestService(database);
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

        public bool IsRoomAvailable(Room r, DateTime time)
        {
            List<Apointment> apointments = secretaryControllers.AppointmentController.getAllAppointments();
            foreach (Apointment ap in apointments)
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
            List<Apointment> doctorsAppointments = secretaryControllers.AppointmentController.FindAllByDoctor(doctorId);   // dobila listu svih appointmenta od doktora
            foreach (Apointment ap in doctorsAppointments)
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
            Apointment a = new Apointment(doctorAvailable, t, doctorId, availableRoom._id, patientId);
            secretaryControllers.AppointmentController.InsertToCollection(a);
            secretaryControllers.referralController.Delete(r._id);
            Console.WriteLine("Date of appointment: " + suggestedDate.ToString());
            Console.WriteLine("Room: " + availableRoom.name);
        }

        public List<Apointment> GetAppointmentsOfDoctors(List<Doctor> doctors) {
            List<Apointment> all = secretaryControllers.AppointmentController.getAllAppointments();
            List<Apointment> scheduledAppointments = new List<Apointment>();
            foreach (Doctor d in doctors) {
                List<Apointment> doctorsAppointments = secretaryControllers.AppointmentController.FindAllByDoctor(d._id);
                foreach (Apointment a in doctorsAppointments)
                {
                    scheduledAppointments.Add(a);
                }
            }

            return scheduledAppointments;
        }

        public void ResheduleAppointment(Apointment a) {
            DateTime suggestedDate = DateTime.Now;
            suggestedDate = suggestedDate.AddDays(2);
            a.dateTime = suggestedDate.Date.Add(new TimeSpan(15, 00, 00));
            secretaryControllers.AppointmentController.UpdateApointment(a);
            Console.WriteLine("Appointment has been resheduled for: " + a.dateTime);
            Console.WriteLine();
        }

        public List<Apointment> GetAppointmentsInNextTwoHours(List<Apointment> doctorsAppointments) {
            List<Apointment> appointmentsInNextTwoHours = new List<Apointment>();
            DateTime today = DateTime.Now;
            foreach (Apointment ap in doctorsAppointments)
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
            List<Apointment> doctorsAppointments = GetAppointmentsOfDoctors(doctors);   // dobila listu svih appointmenta od doktora
            List<Room> rooms = secretaryControllers.roomController.GetAll();
            DateTime searchedDate;
            Room searchedRoom;
            doctorsAppointments.Sort((a, b) => a.dateTime.CompareTo(b.dateTime));
            List<Apointment> appointmentsInNextTwoHours = GetAppointmentsInNextTwoHours(doctorsAppointments);
            if (appointmentsInNextTwoHours.Count > 0)
            {
                Console.WriteLine("Doctors are not available! ");
                Console.WriteLine("Here are their appointements: ");
                foreach (Apointment app in doctorsAppointments) {
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
                DateTime date = secretaryControllers.AppointmentController.FindById(apId).dateTime;
                ResheduleAppointment(secretaryControllers.AppointmentController.FindById(apId));

                ObjectId roomId = secretaryControllers.AppointmentController.FindById(apId).roomId;
                Apointment a = new Apointment(date, t, doctors[0]._id, roomId, patientId);
                Console.WriteLine("Appointment has been sucessfully made!");
                Console.WriteLine("Room: " + secretaryControllers.roomController.GetById(roomId).name);
                Console.WriteLine("Date and time: " + date.ToString());
                secretaryControllers.AppointmentController.InsertToCollection(a);

            }
            else
            {
                searchedDate = DateTime.Now.AddMinutes(30);
                foreach (Room r in rooms)
                {
                    if (IsRoomAvailable(r, searchedDate))
                    {
                        searchedRoom = r;
                        Apointment a = new Apointment(searchedDate, t, doctors[0]._id, searchedRoom._id, patientId);
                        Console.WriteLine("Appointment has been sucessfully made!");
                        Console.WriteLine("Room: " + searchedRoom.name);
                        Console.WriteLine("Date and time: " + searchedDate.ToString());
                        secretaryControllers.AppointmentController.InsertToCollection(a);
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
            UserService us = new UserService(secretaryControllers);
            CheckAppointmentRequestService crs = new CheckAppointmentRequestService(secretaryControllers);
           // EquipmentRequestService ers = new EquipmentRequestService(database);
          //  SecretaryAppointmentService a = new SecretaryAppointmentService(database);
            FreeDayRequestService fs = new FreeDayRequestService(database);
            List<User> patients = us.GetAllPatients();
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
                    us.blockUser();
                    Console.WriteLine("Patient is sucessfully blocked! ");

                }
                else if (choice == "3")
                {
                    secretaryControllers.blockedUserController.PrintBlockedUsers();
                    Console.WriteLine("Enter '1' to unblock a patient: ");
                    string response = Console.ReadLine();
                    if (response.Equals("1"))
                    {
                        us.unblockUser();
                    }

                }
                else if (choice == "4")
                {
                    crs.printAllRequests();
                    Console.WriteLine("Enter request id: ");
                    ObjectId obI = ObjectId.Parse(Console.ReadLine());
                    CheckAppointementRequest cr = secretaryControllers.checkAppointemtRequestController.FindById(obI);
                    Console.WriteLine("1 -> APPROVE REQUEST");
                    Console.WriteLine("2 -> DECLINE REQUEST");
                    string opt = Console.ReadLine();
                    if (opt.Equals("1"))                // accept
                    {
                        cr.status = Status.ACCEPTED;
                        crs.Update(cr);
                        if (cr.RequestState == RequestState.DELETE)
                        {
                           // a.DeleteAppointementByRequest(cr);
                            Console.WriteLine("Appointement is succesfully deleted!");
                        }
                        else if (cr.RequestState == RequestState.EDIT)
                        {
                            AppointmentRequests ar = secretaryControllers.appointmentRequestsController.FindById(cr.appointmentId);
                        //    a.EditAppointementByRequest(cr, ar);
                            Console.WriteLine("Appointement is succesfully edited!");
                        }
                    }
                    else if (opt.Equals("2"))
                    {
                        cr.status = Status.DENIED;
                        crs.Update(cr);
                        Console.WriteLine("Request denied!");
                    }

                }
                else if (choice == "5")
                {
                    us.PrintPatientsWithReferrals(patients);
                    Console.WriteLine("Enter '1' to make an appointment based on referral: ");
                    if (Console.ReadLine() == "1")
                    {
                        Console.WriteLine("Enter referral id: ");
                        ObjectId idRefferal = ObjectId.Parse(Console.ReadLine());
                        Referral r = secretaryControllers.referralController.findById(idRefferal);
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

                    User patient = secretaryControllers.userController.FindByEmail(patientEmail);
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
                    List<EquipmentRequest> requests = secretaryControllers.equipmentRequestController.GetAllEquipmentRequests();
                    if (requests.Count == 0)
                    {

                        Console.WriteLine("NO REQUESTS! ");
                    }
                    else
                    {
                        equipmentService.PrintAllEquipmentRequest(requests);
                        Console.WriteLine();
                        FulfillEquipmentRequest request = new FulfillEquipmentRequest(secretaryControllers);
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
                    TransferEquipment te = new TransferEquipment(secretaryControllers);
                    te.Transfer(from, into, name);
                } else if (choice == "10") {
                    //List<FreeDayRequest> freeDayRequests = secretaryControllers.freeDayRequestController.getAllFreeDayRequests();
                    //fs.PrintAllFreeDayRequests(freeDayRequests);
                    Console.WriteLine("1 -> APPROVE REQUEST");
                    Console.WriteLine("2 -> DECLINE REQUEST");
                    string opt = Console.ReadLine();
                    if (opt.Equals("1")) {                 // accept

                    }
                }
                else if (choice == "11")
                {

                    break;
                }
            }

        }

    }
}
