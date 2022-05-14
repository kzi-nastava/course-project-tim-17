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

namespace HealthcareSystem.UI
{
    class SecretaryUI
    {
        public User loggedUser { get; set; }
        public SecretaryControllers secretaryControllers { get; set; }
        public SecretaryUI(SecretaryControllers secretaryControllers, User loggedUser)
        {
            this.loggedUser = loggedUser;
            this.secretaryControllers = secretaryControllers;
            this.UI();
        }


        public void PrintCRUDMeni()
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
                    string gatheredAllergies = "";
                    List<Ingredient> allergies = found.allergies;
                    foreach (Ingredient a in allergies)
                    {
                        if (a != null)
                        {
                            gatheredAllergies += a.name + ";";
                        }
                    }
                    if (gatheredAllergies != "")
                    {
                        Console.WriteLine("Allergies: " + gatheredAllergies);
                    }
                    else
                    {
                        Console.WriteLine("Allergies: None");
                    }
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
                    List<Referral> referrals = new List<Referral>();
                    foreach (ObjectId rId in found.referrals)
                    {
                        if (secretaryControllers.referralController.findById(rId) != null)
                        {
                            referrals.Add(secretaryControllers.referralController.findById(rId));
                        }
                    }
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
        public void deleteAppointementByRequest(CheckAppointementRequest cr)
        {
            Apointment a = secretaryControllers.AppointmentController.FindById(cr.appointmentId);
            secretaryControllers.AppointmentController.DeleteApointment(a);

        }

        public void editAppointementByRequest(CheckAppointementRequest cr)
        {
            AppointmentRequests ar = secretaryControllers.appointmentRequestsController.FindById(cr.appointmentId);
            Apointment a = secretaryControllers.AppointmentController.FindById(ar.appointmentId);
            //   Console.WriteLine(ar.dateTime);
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
            {                             // adding patient
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
            else if (option.Equals("b"))                    // preview of patients 
            {
                List<User> patients = us.GetAllPatients();
                PrintAllPatients(patients);
            }
            else if (option.Equals("c"))
            {                 // update patient
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
            DateTime today = DateTime.Now;
            bool available = false;
            foreach (Apointment ap in apointments)
            {
                TimeSpan ts = ap.dateTime - today;
                double hours = ts.Hours;
                if (hours > 3)
                {
                    available = true;
                }
                else
                {
                    available = false;
                }


            }

            return available;

        }
        public bool CheckDateForRoom(DateTime date, ObjectId roomId)
        {
            List<Apointment> apointments = secretaryControllers.AppointmentController.getAllAppointments();

            bool available = false;
            foreach (Apointment a in apointments)
            {
                TimeSpan ts = date - a.dateTime;
                double hours = ts.TotalHours;
                if (hours - 1 > 0)
                {
                    available = true;
                }
                else
                {
                    available = false;

                }
            }

            return available;

        }
        public void MakeAppointmentBasedOnReferral(ObjectId idRefferal)
        {
            Referral r = secretaryControllers.referralController.findById(idRefferal);
            ObjectId patientId = r.patientId;
            ObjectId doctorId = r.doctorId;
            Specialisation s = r.specialization;
            Console.WriteLine("Enter type of appointment(checkup/operation): ");
            ApointmentType t = (ApointmentType)Enum.Parse(typeof(ApointmentType), (Console.ReadLine().ToUpper()));

            List<DateTime> doctorTimes = new List<DateTime>();
            List<Apointment> doctorsAppointments = secretaryControllers.AppointmentController.FindAllByDoctor(doctorId);   // dobila listu svih appointmenta od doktora
            foreach (Apointment ap in doctorsAppointments)
            {
                doctorTimes.Add(ap.dateTime);
            }
            DateTime suggestedDate = DateTime.Now;
            suggestedDate = suggestedDate.AddDays(3);                               // stavljam kao prjedlog da je ovo datum 
            suggestedDate = suggestedDate.Date.Add(new TimeSpan(12, 00, 00));
            DateTime doctorAvailable = suggestedDate;
            List<Room> allRooms = secretaryControllers.roomController.GetAllRooms();
            Room availableRoom = allRooms[0];
            Console.WriteLine(doctorTimes.Count);
            bool notBreak = true;
            bool done = false;
            while (notBreak)
            {

                foreach (DateTime d in doctorTimes)
                {
                    TimeSpan ts = suggestedDate - d;
                    double hours = ts.TotalHours;
                    Console.WriteLine(hours - 1);
                    if (hours - 1 > 0)
                    {
                        doctorAvailable = suggestedDate;
                        foreach (Room room in allRooms)
                        {

                            if (CheckDateForRoom(doctorAvailable, room._id))
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
                        suggestedDate.AddHours(2);

                    }
                }


            }
            Apointment a = new Apointment(doctorAvailable, t, doctorId, availableRoom._id, patientId);
            secretaryControllers.AppointmentController.InsertToCollection(a);
            secretaryControllers.referralController.Delete(idRefferal);
            Console.WriteLine("Date of appointment: " + suggestedDate.ToString());
            Console.WriteLine("Room: " + availableRoom.name);


        }



        public void MakeUrgentAppointment(ObjectId doctorId, ObjectId patientId)
        {
            Console.WriteLine("Enter type of appointment(checkup/operation): ");
            ApointmentType t = (ApointmentType)Enum.Parse(typeof(ApointmentType), (Console.ReadLine().ToUpper()));
            List<DateTime> doctorInNextTwoHoursTimes = new List<DateTime>();
            List<Apointment> doctorsAppointments = secretaryControllers.AppointmentController.FindAllByDoctor(doctorId);   // dobila listu svih appointmenta od doktora
            List<Room> rooms = secretaryControllers.roomController.GetAllRooms();
            DateTime today = DateTime.Now;
            DateTime searchedDate;
            Room searchedRoom;
            //doctorTodayTimes.Sort((a, b) => a.CompareTo(b));
            foreach (Apointment ap in doctorsAppointments)
            {
                if (ap.dateTime.Date == DateTime.Today)                                                              // da li je datum danas
                {
                    TimeSpan ts = ap.dateTime - today;
                    double hours = ts.Hours;
                    if (hours < 3)
                    {
                        doctorInNextTwoHoursTimes.Add(ap.dateTime);
                    }

                }
            }
            if (doctorInNextTwoHoursTimes.Count > 0)
            {

                Console.WriteLine(doctorInNextTwoHoursTimes.Count);
            }
            else
            {
                searchedDate = DateTime.Now;
                searchedDate = searchedDate.AddMinutes(30);
                bool notFound = true;

                foreach (Room r in rooms)
                {
                    if (IsRoomAvailable(r, searchedDate))
                    {
                        searchedRoom = r;
                        Apointment a = new Apointment(searchedDate, t, doctorId, searchedRoom._id, patientId);
                        Console.WriteLine("Appointment has been sucessfully made!");
                        Console.WriteLine("Room: " + searchedRoom.name);
                        Console.WriteLine("Date and time: " + searchedDate.ToString());
                        break;
                    }
                }
            }

    


        
        }

        public void PrintAllSpecializations() {
            Console.WriteLine(Specialisation.GYNECOLOGY);
            Console.WriteLine(Specialisation.PEDIATRICS);
            Console.WriteLine(Specialisation.OPHTHALMOLOGY);
            Console.WriteLine(Specialisation.INTERNAL_MEDICINE);
            Console.WriteLine(Specialisation.DERMATOLOGY);
            
        }

        public void CancelRequest(CheckAppointementRequest cr)
        {
            cr.status = Status.DENIED;
        }

        public void ApproveRequest(CheckAppointementRequest cr)
        {
            Console.WriteLine(cr.RequestState.ToString());
            cr.status = Status.ACCEPTED;
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
                Console.WriteLine("7 -> LOG OUT");
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
                            deleteAppointementByRequest(cr);
                            Console.WriteLine("Appointement is succesfully deleted!");
                        }
                        else if (cr.RequestState == RequestState.EDIT)
                        {
                            editAppointementByRequest(cr);
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
                    Console.WriteLine("Enter referral id: ");
                    ObjectId idRefferal = ObjectId.Parse(Console.ReadLine());
                    MakeAppointmentBasedOnReferral(idRefferal);
                    Console.WriteLine("Appointement is succesfully created!");

                }
                else if (choice == "6") {

                    PrintAllPatients(patients);
                    Console.WriteLine("Enter patient email: ");
                    String patientEmail = Console.ReadLine();
                    PrintAllSpecializations();
                    Console.WriteLine("Enter specialization: ");
                    Specialisation s = (Specialisation)Enum.Parse(typeof(Specialisation), (Console.ReadLine().ToUpper()));
           
                    List<Doctor> doctors = secretaryControllers.doctorController.FindDoctorsBySpecialisation(s);

                    User patient = secretaryControllers.userController.FindByEmail(patientEmail);
                    MakeUrgentAppointment(doctors[0]._id, patient._id);
                }
                else if (choice == "7")
                {

                    break;
                }
            }

        }

    }
}
