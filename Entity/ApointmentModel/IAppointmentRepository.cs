using HealthcareSystem.Entity.RoomModel.RoomFiles;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.ApointmentModel
{
    internal interface IAppointmentRepository : IRepository<Appointment>
    {
        List<Appointment> GetAllByUser(ObjectId id);
        List<Appointment> GetAllByDoctor(ObjectId id);
        void DeleteApointmentByPatientId(ObjectId id);
        Appointment GetAppointmentByDateTime(DateTime dateTime);
        Appointment GetAppointmentByDateTimeAndRoom(Room room, DateTime dateTime);

        List<Appointment> GetDoctorSchedule(ObjectId doctorId, DateTime startingDate, DateTime endingDate);
    }
}
