using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.ApointmentModel
{
    class AppointmentService
    {
        public DoctorRepositories doctorRepositories { get; set; }


        public AppointmentService(DoctorRepositories doctorRepositories )
        {
            this.doctorRepositories = doctorRepositories;
        }

        public void AddAppointment(Doctor doctor)
        {
            Console.WriteLine("Choose the type of appointment : 1-Operation or 2-Checkup: ");
            string choice = Console.ReadLine();
            ApointmentType apointmentType;
            if (choice == "1")
            {
                apointmentType = ApointmentType.OPERATION;
            }
            else
            {
                apointmentType = ApointmentType.CHECKUP;
            }

            RoomType roomType;
            if (apointmentType == ApointmentType.CHECKUP)
            {
                roomType = RoomType.CHECKUP_ROOM;
            }
            else
            {
                roomType = RoomType.OPERATION_ROOM;
            }

            DateTime dateTime = EnterDate();
            Room room = EnterRoom(dateTime, roomType);
            
            Console.WriteLine("Enter patient name: ");
            string patientName = Console.ReadLine();
            Console.WriteLine("Enter patient last name: ");
            string patientLastName = Console.ReadLine();

            User user = doctorRepositories.userController.userCollection
                .Find(item => item.name == patientName & item.lastName == patientLastName).FirstOrDefault();
            while (user == null)
            {
                Console.WriteLine("Entered patient does not exist in system!");
                Console.WriteLine("Enter patient name: ");
                patientName = Console.ReadLine();
                Console.WriteLine("Enter patient last name: ");
                patientLastName = Console.ReadLine();
                user = doctorRepositories.userController.userCollection
                    .Find(item => item.name == patientName & item.lastName == patientLastName).FirstOrDefault();
                
            }

            Apointment apointment = new Apointment(dateTime, apointmentType, doctor._id, room._id, user._id);
            doctorRepositories.apointmentController.InsertToCollection(apointment);
            

        }

        public bool DateTimeFree(DateTime dateTime)
        {
            DateTime currentDateTime = DateTime.Now;
            //DateTime.Compare(date1, date2) returns:
            // <0 − If date1 is earlier than date2
            // 0 − If date1 is the same as date2
            // >0 − If date1 is later than date2
            int resultOfComparison = DateTime.Compare(dateTime, currentDateTime);
            if (resultOfComparison < 0)
            {
                return false;
            }

            Apointment unavailableApointment = doctorRepositories.apointmentController.apointmentCollection
                .Find(item => item.dateTime == dateTime).FirstOrDefault();
            if (unavailableApointment != null)
            {
                return false;
            }
            
            return true;
        }

        public bool RoomFree(Room room, DateTime dateTime)
        {
            Apointment apointment = doctorRepositories.apointmentController.apointmentCollection
                .Find(item => item.dateTime == dateTime & item.roomId == room._id).FirstOrDefault();
            if (apointment != null)
            {
                return false;
            }

            return true;
        }

        public void PrintApointments(Doctor doctor)
        {
            Console.WriteLine("ID     |Type     |Date and time  |Doctor    |Patient    |Room");
            Console.WriteLine();
            List<Apointment> apointments = doctorRepositories.apointmentController.apointmentCollection
                .Find(item => item.doctorId == doctor._id).ToList();


            foreach (Apointment apointment in apointments)
            {
                User patient = doctorRepositories.userController.findById(apointment.patientId);
                Room room = doctorRepositories.roomController.findById(apointment.roomId);
                Console.WriteLine(apointment._id.ToString() + "|" +apointment.type.ToString() + "|" + apointment.dateTime.ToString("MM/dd/yyyy") + " "
                                  + apointment.dateTime.ToString("t") + "|" + doctor.name + " " + doctor.lastName
                                  + "|" + patient.name + " " + patient.lastName + "|" + room.name);


            }
        }

        public DateTime EnterDate()
        {
            Console.WriteLine("Enter year: ");
            string year = Console.ReadLine();
            Console.WriteLine("Enter month: ");
            string month = Console.ReadLine();
            Console.WriteLine("Enter day: ");
            string day = Console.ReadLine();
            Console.WriteLine("Enter Hour: ");
            string hour = Console.ReadLine();
            Console.WriteLine("Enter minute: ");
            string minute = Console.ReadLine();

            DateTime dateTime = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day), Int32.Parse(hour), Int32.Parse(minute), 0);
            while (!DateTimeFree(dateTime))
            {
                Console.WriteLine("Date is invalid or unavailable! ");
                Console.WriteLine("Enter year: ");
                year = Console.ReadLine();
                Console.WriteLine("Enter month: ");
                month = Console.ReadLine();
                Console.WriteLine("Enter day: ");
                day = Console.ReadLine();
                Console.WriteLine("Enter Hour: ");
                hour = Console.ReadLine();
                Console.WriteLine("Enter minute: ");
                minute = Console.ReadLine();

                dateTime = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day), Int32.Parse(hour), Int32.Parse(minute), 0);
            }

            return dateTime.AddHours(1);
        }

        public Room EnterRoom(DateTime dateTime,RoomType roomType)
        {
            Console.WriteLine("Enter room name: ");
            string roomName = Console.ReadLine();
            Room room = doctorRepositories.roomController.roomCollection.Find(item => item.name == roomName & item.type == roomType).FirstOrDefault();
            while (room == null)
            {
                Console.WriteLine("Entered room does not exist!");
                Console.WriteLine("Enter room name: ");
                roomName = Console.ReadLine();
                room = doctorRepositories.roomController.roomCollection.Find(item => item.name == roomName & item.type == roomType).FirstOrDefault();
                
            }

            while (!RoomFree(room, dateTime))
            {
                Console.WriteLine("Room is not available at that time!");
                Console.WriteLine("Enter room name: ");
                roomName = Console.ReadLine();
                room = doctorRepositories.roomController.roomCollection.Find(item => item.name == roomName).FirstOrDefault();
            }

            return room;
        }
        
        public void UpdateApointmentDate(Apointment apointment)
        {
            DateTime newDateTime = EnterDate();
            apointment.dateTime = newDateTime;
            doctorRepositories.apointmentController.UpdateApointment(apointment);
        }

        public void UpdateApointmentRoom(Apointment apointment)
        {
            RoomType roomType;
            if (apointment.type == ApointmentType.CHECKUP)
            {
                roomType = RoomType.CHECKUP_ROOM;
            }
            else
            {
                roomType = RoomType.OPERATION_ROOM;
            }
            Room newRoom = EnterRoom(apointment.dateTime, roomType);
            apointment.roomId = newRoom._id;
            doctorRepositories.apointmentController.UpdateApointment(apointment);

        }
        public void PrintSchedule(Doctor doctor)
        {
            Console.WriteLine("Enter year: ");
            string year = Console.ReadLine();
            Console.WriteLine("Enter month: ");
            string month = Console.ReadLine();
            Console.WriteLine("Enter day: ");
            string day = Console.ReadLine();
           

            DateTime enteredDateTime = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
            List<Apointment> certainDoctorsApointments = doctorRepositories.apointmentController.apointmentCollection
                .Find(item => item.doctorId == doctor._id & item.dateTime>enteredDateTime).ToList(); //Fix to show for certain date and next 3 days
            foreach (Apointment apointment in certainDoctorsApointments)
            {
                User patient = doctorRepositories.userController.findById(apointment.patientId);
                Room room = doctorRepositories.roomController.findById(apointment.roomId);
                Console.WriteLine(apointment._id.ToString() + "|" +apointment.type.ToString() + "|" + apointment.dateTime.ToString("MM/dd/yyyy") + " "
                                  + apointment.dateTime.ToString("t") + "|" + doctor.name + " " + doctor.lastName
                                  + "|" + patient.name + " " + patient.lastName + "|" + room.name);


            }
        }
        
    }
    
    
}

