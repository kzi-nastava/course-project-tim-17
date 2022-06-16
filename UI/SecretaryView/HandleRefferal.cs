using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.ReferralModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using MongoDB.Bson;

namespace HealthcareSystem.UI.SecretaryView
{

    internal class HandleRefferal
    {

        public AppointmentService appointmentService;
        public RoomService roomService;
        public ReferralService referralService;
        public HandleRefferal() {
            appointmentService = Globals.container.Resolve<AppointmentService>();
            roomService = Globals.container.Resolve<RoomService>(); 
            referralService = Globals.container.Resolve<ReferralService>();
        }

        public bool IsRoomAvailable(Room r, DateTime time)
        {
            List<Appointment> apointments = appointmentService.GetAll();
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
            List<Appointment> doctorsAppointments = appointmentService.GetAllByDoctor(doctorId);   // dobila listu svih appointmenta od doktora
            foreach (Appointment ap in doctorsAppointments)
            {
                doctorTimes.Add(ap.dateTime);
            }
            DateTime suggestedDate = DateTime.Now.AddDays(3);                     // stavljam kao prjedlog da je ovo datum
            suggestedDate = suggestedDate.Date.Add(new TimeSpan(12, 00, 00));
            DateTime doctorAvailable = suggestedDate;
            List<Room> allRooms = roomService.GetAll();
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
            appointmentService.Insert(a);
            referralService.Delete(r);
            Console.WriteLine("Date of appointment: " + suggestedDate.ToString());
            Console.WriteLine("Room: " + availableRoom.name);
        }

    }
}
