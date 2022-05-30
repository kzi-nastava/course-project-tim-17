using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

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
        public bool CheckIfRoomIsAvaliableForRenovation(ObjectId roomId, DateTime startDate, DateTime endDate)
        {
            List<Apointment> apointments = doctorRepositories.apointmentController.getAllAppointments();
            foreach (Apointment apointment in apointments)
            {
                if (roomId == apointment.roomId)
                {
                    if (apointment.dateTime > startDate && apointment.dateTime < endDate) return false;
                }
                
            }
            return true;
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
                User patient = doctorRepositories.userController.FindById(apointment.patientId);
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
                .Find(item => item.doctorId == doctor._id & item.dateTime>enteredDateTime & item.dateTime < enteredDateTime.AddDays(4)).ToList(); 
            foreach (Apointment apointment in certainDoctorsApointments)
            {
                User patient = doctorRepositories.userController.FindById(apointment.patientId);
                Room room = doctorRepositories.roomController.findById(apointment.roomId);
                Console.WriteLine(apointment._id.ToString() + "|" +apointment.type.ToString() + "|" + apointment.dateTime.ToString("MM/dd/yyyy") + " "
                                  + apointment.dateTime.ToString("t") + "|" + doctor.name + " " + doctor.lastName
                                  + "|" + patient.name + " " + patient.lastName + "|" + room.name);


            }
        }

        public void PerformCheckup(Apointment apointment)
        {
            if (ApointmentStarted(apointment))
            {
                User patient = doctorRepositories.userController.userCollection
                    .Find(item => item._id == apointment.patientId).FirstOrDefault();
                HealthCard patientHealthCard = doctorRepositories.healthCardController.healthCardCollection
                    .Find(item => item.patientId == patient._id).FirstOrDefault();

                string option = "";
                Console.WriteLine(patient.name + " " + patient.lastName + " " + patientHealthCard.height + " " + patientHealthCard.weight);
                Console.WriteLine("1 -> Change height");
                Console.WriteLine("2 -> Change weight");
                Console.WriteLine("3 -> Enter amnesis and perscription");
                Console.WriteLine("Choose option: ");
                option = Console.ReadLine();
                if (option == "1")
                {
                    Console.WriteLine("Enter new height");
                    string newHeight = Console.ReadLine();
                    patientHealthCard.height = Convert.ToDouble(newHeight);
                    doctorRepositories.healthCardController.update(patientHealthCard);
                }
                else if (option == "2")
                {
                    Console.WriteLine("Enter new weight");
                    string newWeight = Console.ReadLine();
                    patientHealthCard.weight = Convert.ToDouble(newWeight);
                    doctorRepositories.healthCardController.update(patientHealthCard);
                }
                else if (option == "3")
                {
                    Anamnesis anamnesis = enterAnamnesis();
                    Prescription prescription = enterPresciption();
                    Check check = new Check(apointment._id, anamnesis, prescription);
                    doctorRepositories.checkController.InsertToCollection(check);
                }

            }
            else
            {
                Console.WriteLine("Apointment has not started yet.");
            }
        }

        public bool ApointmentStarted(Apointment apointment)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime endOfApointment= apointment.dateTime.AddMinutes(15);
            if (apointment.dateTime<currentDateTime & endOfApointment > currentDateTime)
            {
                return true;
            }
            
            
            return false;
        }

        public Anamnesis enterAnamnesis()
        {
            Console.WriteLine("Enter description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter sypmtons: ");
            string sypmtons = Console.ReadLine();
            Console.WriteLine("Enter diagnosis: ");
            string diagnosis = Console.ReadLine();
            Anamnesis anamnesis = new Anamnesis(description, sypmtons, diagnosis);
            return anamnesis;
        }

        public Prescription enterPresciption()
        {
            Console.WriteLine("Enter drug name: ");
            string drugName = Console.ReadLine();
            Drug drug = doctorRepositories.drugController.drugCollection.Find(item => item.name == drugName)
                .FirstOrDefault();
            
            Console.WriteLine("Enter when to take drug: ");
            string when = Console.ReadLine();
            Console.WriteLine("Enter how many times to take drug per day: ");
            string quantity = Console.ReadLine();
            
            Console.WriteLine("How to take drug based on meal - 1)Before 2)After 3)During 4)does not matter");
            string option = Console.ReadLine();
            
            
            Meal meal = Meal.BEFORE;
            if (option == "1")
            {
                meal = Meal.BEFORE;
            }
            else if (option == "2")
            {
                meal = Meal.AFTER;
            }
            else if (option == "3")
            {
                meal = Meal.DURING;
            }
            else if (option == "4")
            {
                meal = Meal.DOESNOTMATTER;
            }

            Prescription prescription = new Prescription(drug._id, when, Int32.Parse(quantity), meal);
            return prescription;
        }
    }


   


}

