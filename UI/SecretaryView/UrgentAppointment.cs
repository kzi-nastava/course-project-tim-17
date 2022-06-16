using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using MongoDB.Bson;

namespace HealthcareSystem.UI.SecretaryView
{
    internal class UrgentAppointment
    {


        public AppointmentService appointmentService;
        public RoomService roomService;

        public UrgentAppointment() { 
            this.appointmentService = Globals.container.Resolve<AppointmentService>();
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

        public List<Appointment> GetAppointmentsOfDoctors(List<Doctor> doctors)
        {
            List<Appointment> all = appointmentService.GetAll();
            List<Appointment> scheduledAppointments = new List<Appointment>();
            foreach (Doctor d in doctors)
            {
                List<Appointment> doctorsAppointments = appointmentService.GetAllByDoctor(d._id);
                foreach (Appointment a in doctorsAppointments)
                {
                    scheduledAppointments.Add(a);
                }
            }

            return scheduledAppointments;
        }


        public void ResheduleAppointment(Appointment a)
        {
            DateTime suggestedDate = DateTime.Now;
            suggestedDate = suggestedDate.AddDays(2);
            a.dateTime = suggestedDate.Date.Add(new TimeSpan(15, 00, 00));
            appointmentService.Update(a);
            Console.WriteLine("Appointment has been resheduled for: " + a.dateTime);
            Console.WriteLine();
        }

        public List<Appointment> GetAppointmentsInNextTwoHours(List<Appointment> doctorsAppointments)
        {
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
            List<Room> rooms = roomService.GetAll();
            DateTime searchedDate;
            Room searchedRoom;
            doctorsAppointments.Sort((a, b) => a.dateTime.CompareTo(b.dateTime));
            List<Appointment> appointmentsInNextTwoHours = GetAppointmentsInNextTwoHours(doctorsAppointments);
            if (appointmentsInNextTwoHours.Count > 0)
            {
                Console.WriteLine("Doctors are not available! ");
                Console.WriteLine("Here are their appointements: ");
                foreach (Appointment app in doctorsAppointments)
                {
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
                DateTime date = appointmentService.GetById(apId).dateTime;
                ResheduleAppointment(appointmentService.GetById(apId));

                ObjectId roomId = appointmentService.GetById(apId).roomId;
                Appointment a = new Appointment(date, t, doctors[0]._id, roomId, patientId);
                Console.WriteLine("Appointment has been sucessfully made!");
                Console.WriteLine("Room: " + roomService.GetById(roomId).name);
                Console.WriteLine("Date and time: " + date.ToString());
                appointmentService.Insert(a);

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
                        appointmentService.Insert(a);
                        break;
                    }
                }
            }

        }
    }
}
