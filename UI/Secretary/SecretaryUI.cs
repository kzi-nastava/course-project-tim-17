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

using MongoDB.Bson;

using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;
using HealthCareSystem.Entity.CheckAppointementRequestModel;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.ReferralModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.EquipmentRequestModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;

namespace HealthcareSystem.UI
{
    class SecretaryUI
    {
        public User LoggedUser { get; set; }
        public SecretaryControllers secretaryControllers { get; set; }
        public SecretaryUI(SecretaryControllers secretaryControllers, User LoggedUser)
        {
            this.LoggedUser = LoggedUser;
            this.secretaryControllers = secretaryControllers;
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
                if (secretaryControllers.blockedUserController.FindByUserId(patients[i]._id) == null)
                {
                    Console.WriteLine(" ------------------------------------");
                    Console.WriteLine("Name: " + " " + patients[i].name);
                    Console.WriteLine("Last name: " + " " + patients[i].lastName);
                    Console.WriteLine("Email: " + " " + patients[i].email);
                    HealthCard found = null;
                    List<HealthCard> healthCards = secretaryControllers.healthCardController.getAllHealthCards();
                    foreach (HealthCard healthCard in healthCards)
                    {
                        if (healthCard.patientId == patients[i]._id)
                        {
                            found = healthCard;
                        }

                    }
                    Console.WriteLine("Weight: " + found.weight.ToString());
                    Console.WriteLine("height: " + found.height.ToString());
                    Console.WriteLine("Allergies: " + secretaryControllers.healthCardController.GetAllergies(found));
                }
            }
        }

        public void PrintPatientsWithReferrals(List<User> patients)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (secretaryControllers.blockedUserController.FindByUserId(patients[i]._id) == null)
                {
                    Console.WriteLine(" ------------------------------------");
                    Console.WriteLine("Name: " + " " + patients[i].name);
                    Console.WriteLine("Last name: " + " " + patients[i].lastName);
                    Console.WriteLine("Email: " + " " + patients[i].email);
                    HealthCard found = null;
                    List<HealthCard> healthCards = secretaryControllers.healthCardController.getAllHealthCards();
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
            Apointment a = secretaryControllers.AppointmentController.FindById(cr.appointmentId);
            secretaryControllers.AppointmentController.DeleteApointment(a);
        }

        public void EditAppointementByRequest(CheckAppointementRequest cr)
        {
            AppointmentRequests ar = secretaryControllers.appointmentRequestsController.FindById(cr.appointmentId);
            Apointment a = secretaryControllers.AppointmentController.FindById(ar.appointmentId);
            a.dateTime = ar.dateTime;
            a.doctorId = ar.doctorId;
            a.patientId = ar.patientId;
            a.roomId = ar.roomId;
            secretaryControllers.AppointmentController.UpdateApointment(a);
        }

        public void HandleCRUD(string option)
        {
            UserService us = new UserService(secretaryControllers);
            if (option.Equals("a"))
            {                                                                // adding patient
                User patient = us.AddPatient();
                if (patient != null)
                {
                    HealthCardService hc = new HealthCardService(secretaryControllers, patient);
                    hc.CreateHealthCard();
                    Console.WriteLine("Patient is sucessfully created! ");
                }
                else
                {
                    Console.WriteLine("Sorry, patient already exists! ");
                }
            }
            else if (option.Equals("b"))                                                         // preview of patients 
            {
                List<User> patients = us.GetAllPatients();
                PrintAllPatients(patients);
            }
            else if (option.Equals("c"))
            {                                                                            // update patient
                User patient = us.UpdateUser();
                HealthCardService hc = new HealthCardService(secretaryControllers, patient);
                Console.WriteLine("To edit patient's healthcard enter '1': ");
                string toEdit = Console.ReadLine();
                if (toEdit.Equals("1"))
                {
                    hc.UpdateHealthCard();
                }
                Console.WriteLine("Patient is sucessfully updated! ");
            }
            else if (option.Equals("d"))                            // delete patient        
            {
                User patient = us.DeleteUser();
                if (patient != null)
                {
                    HealthCardService hc = new HealthCardService(secretaryControllers, patient);
                    hc.DeleteHealthCard();
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

        public void PrintLackingEquipmentFromWareHouse()
        {
            Room warehouse = secretaryControllers.roomController.getWarehouse();
            List<Equipment> eq = warehouse.equipments;
            Console.WriteLine("EQUIPMENT THAT IS LACKING IN WAREHOUSE: ");
            foreach (Equipment eqItem in eq)
            {
                if (eqItem.isDynamic && eqItem.quantity == 0)
                {
                    Console.WriteLine("ITEM: " + eqItem.item.ToUpper());
                    Console.WriteLine("TYPE:" + eqItem.type.ToString());
                    Console.WriteLine("ID:" + eqItem._id);
                    Console.WriteLine("----------------------------------------");
                }
            }
        }

        public void MakeEquipmentRequest() {
            Console.WriteLine("Enter the item name you are making request for: ");
            String itemName = Console.ReadLine();
            Console.WriteLine("Enter the quantity: ");
            int quantity = Int32.Parse(Console.ReadLine());
            DateTime date = DateTime.Now.AddDays(1);
            EquipmentRequest er = new EquipmentRequest(itemName, date, quantity);
            secretaryControllers.equipmentRequestController.InsertToCollection(er);

        }

        public void PrintAllEquipmentRequest(List<EquipmentRequest> requests) {
            Console.WriteLine("READY REQUESTS");
            Console.WriteLine("-----------------------------");
            foreach (EquipmentRequest req in requests) {
                if (req.DateTime < DateTime.Now) {
                    Console.WriteLine("ID: " + req._id);
                    Console.WriteLine("ITEM: " + req.ItemName);
                    Console.WriteLine("DATE: " + req.DateTime);
                    Console.WriteLine("QUANTITY: " + req.Quantity.ToString());
                }
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("REQUESTS YET TO BE FULFILLED");
            Console.WriteLine("-----------------------------");
            foreach (EquipmentRequest req in requests)
            {
                if (req.DateTime >= DateTime.Now)
                {
                    Console.WriteLine("ITEM: " + req.ItemName);
                    Console.WriteLine("DATE: " + req.DateTime);
                    Console.WriteLine("QUANTITY: " + req.Quantity.ToString());
                }
            }
            Console.WriteLine("-----------------------------");
        }

        public void FulfiilEquipmentRequests()
        {
            Room warehouse = secretaryControllers.roomController.getWarehouse();

            List<EquipmentRequest> requests = secretaryControllers.equipmentRequestController.GetAllEquipmentRequests();
            foreach (EquipmentRequest req in requests)
            {
                if (req.DateTime < DateTime.Now)
                {
                    foreach (Equipment e in warehouse.equipments) {
                        if (e.item.ToUpper().Equals(req.ItemName.ToUpper()))
                        {
                            e.quantity += req.Quantity;
                            secretaryControllers.roomController.Update(warehouse);
                            Console.WriteLine("REQUEST " + req._id + " SUCCESFULLY FULFILLED");

                        }
                        secretaryControllers.equipmentRequestController.DeleteEquipmentRequest(req);

                    }

                }
            }
        }

        public static Boolean RoomLacks(Room r)
        {
            foreach (Equipment e in r.equipments)
            {
                if (e.quantity < 5 && e.isDynamic)
                {
                    return true;

                }
            }
            return false;

        }

        public void PrintRoomsNeedingEquipment(List<Room> rooms)
        {
            foreach (Room room in rooms) {
                if (RoomLacks(room) && !room.name.Equals("Warehouse"))
                {
                    Console.WriteLine("ROOM: " + room.name);
                    Console.WriteLine("TYPE: " + room.type.ToString());
                    Console.WriteLine("ID: " + room._id);
                    Console.WriteLine("ITEMS:");
                    foreach (Equipment e in room.equipments)
                    {
                        if (e.isDynamic)
                        {
                            Console.WriteLine("        ITEM: " + e.item);
                            Console.WriteLine("        TYPE: " + e.type.ToString());
                            if (e.quantity < 5)
                            {
                                Console.WriteLine("        QUANTITY: " + e.quantity + " ***");
                            }
                            else
                            {
                                Console.WriteLine("        QUANTITY: " + e.quantity);
                            }
                        }


                    }
                    Console.WriteLine();
                }

            }

        }

        public Boolean DoesRoomHave(Room room, String Itemname)
        {
            foreach (Equipment e in room.equipments) {
                if (e.item.ToUpper().Equals(Itemname.ToUpper())) {
                    return true;
                }

            }
            return false;

        }
        public void GetRoomsWhichHaveSpecificEquipment(List<Room> rooms, String ItemName)
        {
            foreach (Room room in rooms)
            {
                if (DoesRoomHave(room, ItemName))
                {
                    Console.WriteLine("ID: " + room._id);
                    Console.WriteLine("ROOM: " + room.name);
                    Console.WriteLine("TYPE: " + room.type);
                    foreach (Equipment e in room.equipments)
                    {
                        if (e.item.ToUpper().Equals(ItemName.ToUpper()))
                        {
                            Console.WriteLine("QUANTITY: " + e.quantity);
                        }
                    }
                    Console.WriteLine();
                }

            }
        }

        public void Transfer(Room from, Room to, String ItemName) {
            Equipment e = from.equipments.Where(e => e.item.ToUpper() == ItemName.ToUpper()).FirstOrDefault();
            Console.WriteLine("Max quantity you can enter is: " + e.quantity);
            int enteredQuantity = Int32.Parse(Console.ReadLine());
            while (enteredQuantity > e.quantity) {
                Console.WriteLine("Not possible. Please enter again: ");
                enteredQuantity = Int32.Parse(Console.ReadLine());
            }
            foreach (Equipment eq in from.equipments)
            {
                if (eq.item.ToUpper().Equals(ItemName.ToUpper()))
                {
                    eq.quantity -= enteredQuantity;
                    secretaryControllers.roomController.Update(from);
                }
            }
            foreach (Equipment eq in to.equipments)
            {
                if (eq.item.ToUpper().Equals(ItemName.ToUpper()))
                {
                    eq.quantity += enteredQuantity;
                    secretaryControllers.roomController.Update(to);
                }
            }

            Console.WriteLine("Sucessfully transfered! ");


        }
        public void UI()
        {
            UserService us = new UserService(secretaryControllers);
            CheckAppointmentRequestService crs = new CheckAppointmentRequestService(secretaryControllers);
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
                            HandleCRUD(option);
                        }
                    }
                }
                else if (choice == "2")
                {

                    PrintAllPatients(patients);
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
                            DeleteAppointementByRequest(cr);
                            Console.WriteLine("Appointement is succesfully deleted!");
                        }
                        else if (cr.RequestState == RequestState.EDIT)
                        {
                            EditAppointementByRequest(cr);
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
                    PrintPatientsWithReferrals(patients);
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

                    PrintAllPatients(patients);
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
                    PrintLackingEquipmentFromWareHouse();
                    Console.WriteLine("Enter '1' to make a request: ");
                    if (Console.ReadLine().Equals("1"))
                    {
                        MakeEquipmentRequest();
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
                        PrintAllEquipmentRequest(requests);
                        Console.WriteLine();
                        FulfiilEquipmentRequests();
                    }

                }
                else if (choice == "9") {
                    List<Room> rooms = secretaryControllers.roomController.GetAll();
                    PrintRoomsNeedingEquipment(rooms);
                    Console.WriteLine("Enter room ID which needs more equipment: ");
                    ObjectId roomIdInto = ObjectId.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the name of equipment: ");
                    String name = Console.ReadLine();
                    Console.WriteLine();
                    GetRoomsWhichHaveSpecificEquipment(rooms, name);
                    Console.WriteLine("Enter room ID from which you transfer: ");
                    ObjectId roomIdFrom = ObjectId.Parse(Console.ReadLine());
                    Room from = secretaryControllers.roomController.GetById(roomIdFrom);
                    Room inn = secretaryControllers.roomController.GetById(roomIdInto);
                    Transfer(from, inn, name);
                }
                else if (choice == "11")
                {

                    break;
                }
            }

        }

    }
}
