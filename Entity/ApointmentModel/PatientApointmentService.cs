using MongoDB.Driver;
using MongoDB.Bson;
using System.Globalization;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.UserActionModel;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;

namespace HealthcareSystem.Entity.ApointmentModel
{
    class ApointmentService{
        public User loggedUser {get; set;}
        public PatientRepositories patientRepositories { get; set; }
        public ApointmentService(PatientRepositories patientRepositories, User loggedUser)
        {
            this.patientRepositories = patientRepositories;
            this.loggedUser = loggedUser;
        }

        public void trollCheck(){
            int create = 0, change = 0;
            List<UserAction> userActions = patientRepositories.userActionController.findAllByUser(loggedUser._id);
            foreach(UserAction userAction in userActions){
                if(DateTime.Compare(userAction.dateTime, DateTime.Today.AddMinutes(-43200))>0){
                    if(userAction.actionStatus == ActionStatus.CREATE){
                        create = create + 1;
                    }else{
                        change = change + 1;
                    }
                }
            }
            Console.WriteLine(change);
            if(create >= 8 || change >= 5){
                BlockedUser blockedUser = new BlockedUser(loggedUser._id, BlockedBy.SYSTEM);
                patientRepositories.blockedUserController.InsertToCollection(blockedUser);
                Console.WriteLine("The account is blocked because too much changes were made to the appointments. Contact secretary for more info.");
                System.Environment.Exit(1);
            }
        }

        public void addApointment(){
            DateTime date = new DateTime();
            while (true){
                Console.WriteLine("Insert appointment date (format dd/mm/yyyy hh:mm)");
                string rawdate = Console.ReadLine();
                date = DateTime.ParseExact(rawdate, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);
                if (date < DateTime.Today){
                    Console.WriteLine("Inserted date has already passed. Try again.");
                }else{
                    break;
                }
            }
            ApointmentType apointmenttype = new ApointmentType();
            RoomType roomtype = new RoomType();
            while (true){
                Console.WriteLine("\n1. Operation");
                Console.WriteLine("2. Checkup");
                Console.WriteLine("Type in a number in front of appointment type: ");
                string reason = Console.ReadLine();
                if (reason == "1"){
                    apointmenttype = ApointmentType.OPERATION;
                    roomtype = RoomType.OPERATION_ROOM;
                    break;
                }else if (reason == "2"){
                    apointmenttype = ApointmentType.CHECKUP;
                    roomtype = RoomType.CHECKUP_ROOM;
                    break;
                }else{
                    Console.WriteLine("Typed value isn't valid. Try again.");
                }
            }
            
            List<Doctor> allDoctors = patientRepositories.patientController.doctorCollection.Find(Item => true).ToList();
            List<Apointment> allApointments = patientRepositories.patientController.apointmentCollection.Find(Item => true).ToList();
            List<Room> allRooms = patientRepositories.patientController.roomCollection.Find(Item => true).ToList();
            List<ObjectId> unavailableRoomId = new List<ObjectId>();
            List<ObjectId> unavailableDoctorId = new List<ObjectId>();
            foreach(Apointment appointment in allApointments){
                DateTime startPoint = appointment.dateTime.AddMinutes(-15);
                DateTime endPoint = appointment.dateTime.AddMinutes(15);
                if(DateTime.Compare(date, startPoint) > 0 && DateTime.Compare(date, endPoint)< 0){
                    unavailableDoctorId.Add(appointment.doctorId);
                    unavailableRoomId.Add(appointment.roomId);
                }
            }
            foreach(ObjectId id in unavailableDoctorId){
                foreach(Doctor doc in allDoctors){
                    if(doc._id == id){
                        allDoctors.Remove(doc);
                    }
                }
            }

            foreach(Room room in allRooms.ToList()){
                foreach(ObjectId id in unavailableRoomId.ToList()){
                    if(room._id == id && room.type == roomtype){
                        allRooms.Remove(room);
                    }
                }
                if(room.type != roomtype){
                    allRooms.Remove(room);
                }
            }
            

            if (allDoctors.Count == 0 || allRooms.Count == 0){
                Console.WriteLine("Sadly, the selected date isn't available.");
            }
            else{
                ObjectId roomsubmit = allRooms[0]._id;
                Console.WriteLine("\nAvailable doctors:");
                for(int i = 0; i < allDoctors.Count; i++){
                    Console.WriteLine("{0}: {1} {2}", i + 1, allDoctors[i].name, allDoctors[i].lastName);
                }
                ObjectId doctorsubmit = new ObjectId();
                while (true){
                    Console.WriteLine("Type in a number in front of the selected doctor:");
                    string option = Console.ReadLine();
                    if (Int16.Parse(option) > allDoctors.Count){
                        Console.WriteLine("Typed value isn't valid. Try again.");
                    }else{
                        doctorsubmit = allDoctors[Int16.Parse(option)-1]._id;
                        break;
                    }
                }
                Apointment appointmentsubmit = new Apointment(date, apointmenttype, doctorsubmit, roomsubmit, loggedUser._id);
                patientRepositories.appointmentController.InsertToCollection(appointmentsubmit);
                Console.WriteLine("Appointment inserted!");
                UserAction userAction = new UserAction(loggedUser._id, appointmentsubmit._id, DateTime.Today, ActionStatus.CREATE);
                patientRepositories.userActionController.InsertToCollection(userAction);
                
            }
        trollCheck();
        }

        public void changeApointment(){
            DateTime appointmentDate = new DateTime();
            Apointment apointmentOld = patientRepositories.appointmentController.getAllAppointments()[0];
            bool isFound = false;
            List<Apointment> allApointments = patientRepositories.patientController.apointmentCollection.Find(Item => true).ToList();
            while (true){
                Console.WriteLine("Insert appointment date (format dd/mm/yyyy hh:mm)");
                string rawdate = Console.ReadLine();
                appointmentDate = DateTime.ParseExact(rawdate, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);
                if (appointmentDate < DateTime.Today){
                    Console.WriteLine("Inserted date has already passed. Try again.");
                }else{
                    List<Apointment> apointmentList = patientRepositories.appointmentController.findAllByUser(loggedUser._id);
                    foreach(Apointment apointmentTemp in apointmentList){
                        if(DateTime.Compare(apointmentTemp.dateTime, appointmentDate) == 0){
                            isFound = true;
                            apointmentOld = apointmentTemp;
                        }
                    }
                    if (isFound == false){
                        Console.WriteLine("Appointment with inserted date doesn't exist. Try again.");
                    }
                }
                if(isFound == true){
                    break;
                }
            }
            if (DateTime.Compare(appointmentDate, DateTime.Today.AddMinutes(1440))<0){
                Console.WriteLine("The period for appointment change has ended.");
            }
            else{
                RoomType roomType = new RoomType();
                if(apointmentOld.type == 0){
                    roomType = RoomType.CHECKUP_ROOM;
                }else{
                    roomType = RoomType.OPERATION_ROOM;
                }
                Console.WriteLine("1. Date and time");
                Console.WriteLine("2. Type of appointment");
                Console.WriteLine("3. Doctor");
                string option;
                while (true){
                    Console.WriteLine("What would you like to change about the appointment?");
                    option = Console.ReadLine();
                    if (option == "1" || option == "2" || option == "3"){
                        break;
                    }
                }
                if(option == "1"){
                    DateTime newAppointmentDate = new DateTime();
                    while (true){
                        Console.WriteLine("Insert new appointment date (format dd/mm/yyyy hh:mm)");
                        string rawNewDate = Console.ReadLine();
                        newAppointmentDate = DateTime.ParseExact(rawNewDate, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);
                        if (newAppointmentDate <= DateTime.Today){
                            Console.WriteLine("Inserted date has already passed. Try again.");
                        }
                        else{
                            break;
                        }
                    }

                    List<Room> allRooms = patientRepositories.patientController.roomCollection.Find(Item => true).ToList();
                    List<ObjectId> unavailableRoomId = new List<ObjectId>();
                    List<ObjectId> unavailableDoctorId = new List<ObjectId>();
                    foreach(Apointment appointment in allApointments){
                        DateTime startPoint = appointment.dateTime.AddMinutes(-15);
                        DateTime endPoint = appointment.dateTime.AddMinutes(15);
                        if(DateTime.Compare(newAppointmentDate, startPoint) > 0 && DateTime.Compare(newAppointmentDate, endPoint) < 0){
                            unavailableDoctorId.Add(appointment.doctorId);
                            unavailableRoomId.Add(appointment.roomId);
                        }
                    }
                    bool isAvailable = true;
                    foreach(ObjectId id in unavailableDoctorId){
                        if(apointmentOld.doctorId == id){
                            isAvailable = false;
                        }
                    }
                    
                    foreach(Room room in allRooms.ToList()){
                        foreach(ObjectId id in unavailableRoomId.ToList()){
                            if(room._id == id && room.type == roomType){
                                allRooms.Remove(room);
                            }
                        }
                        if(room.type != roomType){
                            allRooms.Remove(room);
                        }
                    }
            

                    if (isAvailable == false || allRooms.Count == 0){
                        Console.WriteLine("Sadly, the selected date isn't available.");
                    }
                    else{
                        ObjectId roomSubmit = allRooms[0]._id;
                        Console.WriteLine(apointmentOld.dateTime);
                        Console.WriteLine(DateTime.Now.AddMinutes(2880));
                        if(DateTime.Compare (apointmentOld.dateTime, DateTime.Now.AddMinutes(2880)) <0){
                            AppointmentRequests appointmentRequests = new AppointmentRequests(apointmentOld.dateTime, apointmentOld.type, apointmentOld.doctorId, roomSubmit, loggedUser._id, apointmentOld._id);
                            patientRepositories.appointmentRequestsController.InsertToCollection(appointmentRequests);
                            CheckAppointementRequest checkAppointmentRequest = new CheckAppointementRequest(appointmentRequests._id, RequestState.EDIT);
                            patientRepositories.checkAppointmentRequestController.InsertToCollection(checkAppointmentRequest);
                            Console.WriteLine("The request has been sent to the system.");
                        }else{
                            apointmentOld.dateTime = newAppointmentDate;
                            apointmentOld.roomId = roomSubmit;
                            patientRepositories.appointmentController.replaceApointment(apointmentOld);
                            Console.WriteLine("Apointment edited successfully");
                        }
                        UserAction userAction = new UserAction(loggedUser._id, apointmentOld._id, DateTime.Today, ActionStatus.CHANGE);
                        patientRepositories.userActionController.InsertToCollection(userAction);
                    }
                }
                if(option == "2"){
                    ApointmentType apointmentType = new ApointmentType();
                    while (true){
                        Console.WriteLine("\n1. Operation");
                        Console.WriteLine("2. Checkup");
                        Console.WriteLine("Type in a number in front of appointment type: ");
                        string reason = Console.ReadLine();
                        if (reason == "1"){
                            apointmentType = ApointmentType.OPERATION;
                            roomType = RoomType.OPERATION_ROOM;
                            break;
                        }else if (reason == "2"){
                            apointmentType = ApointmentType.CHECKUP;
                            roomType = RoomType.CHECKUP_ROOM;
                            break;
                        }else{
                            Console.WriteLine("Typed value isn't valid. Try again.");
                        }
                    }
                    List<Room> allRooms = patientRepositories.patientController.roomCollection.Find(Item => true).ToList();
                    List<ObjectId> unavailableRoomId = new List<ObjectId>();
                    foreach(Apointment appointment in allApointments){
                        DateTime startPoint = appointment.dateTime.AddMinutes(-15);
                        DateTime endPoint = appointment.dateTime.AddMinutes(15);
                        if(apointmentOld.dateTime > startPoint && apointmentOld.dateTime < endPoint){
                            unavailableRoomId.Add(appointment.roomId);
                        }
                    }

                    foreach(Room room in allRooms.ToList()){
                        foreach(ObjectId id in unavailableRoomId.ToList()){
                            if(room._id == id && room.type == roomType){
                                allRooms.Remove(room);
                            }
                        }
                        if(room.type != roomType){
                            allRooms.Remove(room);
                        }
                    }

                    if (allRooms.Count == 0){
                        Console.WriteLine("Sadly, the selected option isn't available.");
                    }
                    else{
                        Console.WriteLine(apointmentOld.dateTime);
                        Console.WriteLine(DateTime.Now.AddMinutes(2880));
                        ObjectId roomsubmit = allRooms[0]._id;
                        if(DateTime.Compare (apointmentOld.dateTime, DateTime.Now.AddMinutes(2880)) <0){
                            AppointmentRequests appointmentRequests = new AppointmentRequests(apointmentOld.dateTime, apointmentType, apointmentOld.doctorId, roomsubmit, loggedUser._id, apointmentOld._id);
                            patientRepositories.appointmentRequestsController.InsertToCollection(appointmentRequests);
                            CheckAppointementRequest checkAppointmentRequest = new CheckAppointementRequest(appointmentRequests._id, RequestState.EDIT);
                            patientRepositories.checkAppointmentRequestController.InsertToCollection(checkAppointmentRequest);
                            Console.WriteLine("The request has been sent to the system.");
                        }else{
                            
                            apointmentOld.type = apointmentType;
                            apointmentOld.roomId = roomsubmit;
                            patientRepositories.appointmentController.replaceApointment(apointmentOld);
                            Console.WriteLine("Apointment edited successfully");
                        }
                        UserAction userAction = new UserAction(loggedUser._id, apointmentOld._id, DateTime.Today, ActionStatus.CHANGE);
                        patientRepositories.userActionController.InsertToCollection(userAction);

                    }
                }
                if(option == "3"){
                    List<Doctor> allDoctors = patientRepositories.patientController.doctorCollection.Find(Item => true).ToList();
                    List<ObjectId> unavailableDoctorId = new List<ObjectId>();
                    foreach(Apointment appointment in allApointments){
                        DateTime startPoint = appointment.dateTime.AddMinutes(-15);
                        DateTime endPoint = appointment.dateTime.AddMinutes(15);
                        if(DateTime.Compare(apointmentOld.dateTime, startPoint) > 0 && DateTime.Compare(apointmentOld.dateTime, endPoint) < 0){
                            unavailableDoctorId.Add(appointment.doctorId);
                            
                        }
                    }
                    foreach(ObjectId id in unavailableDoctorId.ToList()){
                        foreach(Doctor doc in allDoctors.ToList()){
                            if(doc._id == id){
                                allDoctors.Remove(doc);
                            }else{
                                Console.WriteLine(doc.lastName);
                            }
                        }
                    }
                    if (allDoctors.Count == 0){
                        Console.WriteLine("Sadly, the selected option isn't available.");
                    }
                    else{
                        Console.WriteLine("\nAvailable doctors:");
                        for(int i = 0; i < allDoctors.Count; i++){
                            Console.WriteLine("{0}: {1} {2}", i + 1, allDoctors[i].name, allDoctors[i].lastName);
                        }
                        ObjectId doctorsubmit = new ObjectId();
                        while (true){
                            Console.WriteLine("Type in a number in front of the selected doctor:");
                            option = Console.ReadLine();
                            if (Int16.Parse(option) > allDoctors.Count){
                                Console.WriteLine("Typed value isn't valid. Try again.");
                            }else{
                                doctorsubmit = allDoctors[Int16.Parse(option)-1]._id;
                                break;
                            }
                        }
                        Console.WriteLine(apointmentOld.dateTime);
                        Console.WriteLine(DateTime.Now.AddMinutes(2880));
                        if(DateTime.Compare (apointmentOld.dateTime, DateTime.Now.AddMinutes(2880)) <0){
                            AppointmentRequests appointmentRequests = new AppointmentRequests(apointmentOld.dateTime, apointmentOld.type, doctorsubmit, apointmentOld.roomId, loggedUser._id, apointmentOld._id);
                            patientRepositories.appointmentRequestsController.InsertToCollection(appointmentRequests);
                            CheckAppointementRequest checkAppointmentRequest = new CheckAppointementRequest(appointmentRequests._id, RequestState.EDIT);
                            patientRepositories.checkAppointmentRequestController.InsertToCollection(checkAppointmentRequest);
                            Console.WriteLine("The request has been sent to the system.");
                        }else{
                            apointmentOld.doctorId = doctorsubmit;
                            patientRepositories.appointmentController.replaceApointment(apointmentOld);
                            Console.WriteLine("Apointment edited successfully");
                        }
                        UserAction userAction = new UserAction(loggedUser._id, apointmentOld._id, DateTime.Today, ActionStatus.CHANGE);
                        patientRepositories.userActionController.InsertToCollection(userAction);

                    }
                }

            }
        trollCheck();
        }

        public void deleteApointment(){
            DateTime appointmentDate = new DateTime();
            Apointment apointmentDelete = patientRepositories.appointmentController.getAllAppointments()[0];
            bool isFound = false;
            List<Apointment> allApointments = patientRepositories.patientController.apointmentCollection.Find(Item => true).ToList();
            while (true){
                Console.WriteLine("Insert appointment date (format dd/mm/yyyy hh:mm)");
                string rawdate = Console.ReadLine();
                appointmentDate = DateTime.ParseExact(rawdate, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);
                if (appointmentDate < DateTime.Today){
                    Console.WriteLine("Inserted date has already passed. Try again.");
                }else{
                    List<Apointment> apointmentList = patientRepositories.appointmentController.findAllByUser(loggedUser._id);
                    foreach(Apointment apointmentTemp in apointmentList){
                        if(DateTime.Compare(apointmentTemp.dateTime, appointmentDate) == 0){
                            isFound = true;
                            apointmentDelete = apointmentTemp;
                        }
                    }
                    if (isFound == false){
                        Console.WriteLine("Appointment with inserted date doesn't exist. Try again.");
                    }
                }
                if(isFound == true){
                    break;
                }
            }
            if(DateTime.Compare (apointmentDelete.dateTime, DateTime.Now.AddMinutes(2880)) <0){
                CheckAppointementRequest checkAppointmentRequest = new CheckAppointementRequest(apointmentDelete._id, RequestState.DELETE);
                patientRepositories.checkAppointmentRequestController.InsertToCollection(checkAppointmentRequest);
                Console.WriteLine("The request has been sent to the system.");
            }else{
                patientRepositories.appointmentController.DeleteApointment(apointmentDelete);
                Console.WriteLine("Appointment has been deleted!");
            }
            UserAction userAction = new UserAction(loggedUser._id, apointmentDelete._id, DateTime.Today, ActionStatus.CREATE);
            patientRepositories.userActionController.InsertToCollection(userAction);
            trollCheck();
        }

        public void readApointment(){
            List<Apointment> selectedApointments = new List<Apointment>();
            List<Apointment> allApointments = patientRepositories.patientController.apointmentCollection.Find(Item => true).ToList();
            foreach(Apointment apointment in allApointments){
                if(apointment.patientId == loggedUser._id){
                    selectedApointments.Add(apointment);
                }
            }
            List<Apointment> sortedList = selectedApointments.OrderBy(item=>item.dateTime).ToList();
            foreach(Apointment apointment in sortedList){
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Date: {0}", apointment.dateTime);
                Console.WriteLine("Doctor: {0} {1}", patientRepositories.doctorController.findById(apointment.doctorId).name, patientRepositories.doctorController.findById(apointment.doctorId).lastName);
                Console.WriteLine("Room: {0}", patientRepositories.roomController.findById(apointment.roomId).name);
                if(apointment.type == ApointmentType.CHECKUP){
                    Console.WriteLine("Type: Checkup");
                }else{
                    Console.WriteLine("Type: Operation");
                }
            }
        }
    }
}