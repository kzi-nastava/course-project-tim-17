using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
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

    }


   


}

