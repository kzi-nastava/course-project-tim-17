using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserActionModel;
using HealthcareSystem.Entity.Enumerations;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Globalization;
using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthcareSystem.Entity.RoomModel.RoomFiles;

namespace HealthcareSystem.UI.Patient
{
    partial class RecommendedScheduling : Form
    {
        public User loggedUser { get; set; }
        public UserActionService userActionService { get; set; }
        public AppointmentService appointmentService { get; set; }
        public RoomService roomService { get; set; }
        public BlockedUserService blockedUserService { get; set; }
        public DoctorService doctorService { get; set; }
        public string Method { get; set; }
        public ObjectId mainDoctorId { get; set; }
        public RecommendedScheduling(User loggedUser)
        {
            roomService = Globals.container.Resolve<RoomService>();
            userActionService = Globals.container.Resolve<UserActionService>();
            appointmentService = Globals.container.Resolve<AppointmentService>();
            blockedUserService = Globals.container.Resolve<BlockedUserService>();
            doctorService = Globals.container.Resolve<DoctorService>();
            InitializeComponent();
            this.loggedUser = loggedUser;
        }

        public void trollCheck()
        {
            int create = 0, change = 0;
            List<UserAction> userActions = userActionService.GetAllById(loggedUser._id);
            foreach (UserAction userAction in userActions)
            {
                if (DateTime.Compare(userAction.dateTime, DateTime.Today.AddMinutes(-43200)) > 0)
                {
                    if (userAction.actionStatus == ActionStatus.CREATE)
                    {
                        create = create + 1;
                    }
                    else
                    {
                        change = change + 1;
                    }
                }
            }
            if (create >= 8 || change >= 5)
            {
                BlockedUser blockedUser = new BlockedUser(loggedUser._id, BlockedBy.SYSTEM);
                blockedUserService.Insert(blockedUser);
                this.Hide();
                Console.WriteLine("The account is blocked because too much changes were made to the appointments. Contact secretary for more info.");
                System.Environment.Exit(1);
            }
        }

        bool EverythingFilledCheck()
        {
            if(string.IsNullOrEmpty(doctorBox.Text) || string.IsNullOrEmpty(typeBox.Text) || string.IsNullOrEmpty(priorityBox.Text))
            {
                return false;
            }
            return true;
        }

        void PriorityDoctor()
        {
            Method = "Doctor";
            DateTime date = datePicker.Value.Date + timePicker.Value.TimeOfDay;
            List<Doctor> allDoctors = doctorService.GetAll();
            List<Appointment> allApointments = appointmentService.GetAll();
            List<DateTime> busyDates = new List<DateTime>();
            List<DateTime> availableDates = new List<DateTime>();
            int datecount = 0;
            ObjectId doctorId = allDoctors[0]._id;
            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.name == doctorBox.SelectedItem.ToString().Split(" ")[0] && doctor.lastName == doctorBox.SelectedItem.ToString().Split(" ")[1])
                {
                    doctorId = doctor._id;
                }
            }

            foreach (Appointment apointment in allApointments.ToList())
            {
                if(apointment.doctorId == doctorId)
                {
                    busyDates.Add(apointment.dateTime);
                }
            }
            bool datePrevious = true, dateNext = true;
            int i = 1;
            while(i != 0)
            {
                DateTime datePreviousStart = date, datePreviousEnd = date, dateNextStart = date, dateNextEnd = date;
                datePreviousStart = datePreviousStart.AddMinutes(-i - 15);
                datePreviousEnd = datePreviousEnd.AddMinutes(-i + 15);
                dateNextStart = dateNextStart.AddMinutes(i - 15);
                dateNextEnd = dateNextEnd.AddMinutes(i + 15);
                foreach(DateTime busyDate in busyDates)
                {
                    if (DateTime.Compare(busyDate, datePreviousStart) >= 0 && DateTime.Compare(busyDate, datePreviousEnd) <= 0)
                    {
                        datePrevious = false;
                    }
                    if (DateTime.Compare(busyDate, dateNextStart) >= 0 && DateTime.Compare(busyDate, dateNextEnd) <= 0)
                    {
                        dateNext = false;
                    }
                }
                if (datePrevious == true && datecount < 3)
                {
                    availableDates.Add(datePreviousStart.AddMinutes(15));
                    datecount++;
                }
                if(dateNext == true && datecount < 3)
                {
                    availableDates.Add(dateNextStart.AddMinutes(15));
                    datecount++;
                }
                if(datecount >= 3)
                {
                    i = 0;
                }
                else
                {
                    datePrevious = true;
                    dateNext = true;
                    i++;
                }
            }
            recommendBox.Items.Add(availableDates[0].ToString("dd/MM/yyyy HH:mm"));
            recommendBox.Items.Add(availableDates[1].ToString("dd/MM/yyyy HH:mm"));
            recommendBox.Items.Add(availableDates[2].ToString("dd/MM/yyyy HH:mm"));
            recommendBox.Visible = true;
            infoLabel.Text = "Selected date isn't available. Choose one of the 3 recommended ones";
            infoLabel.Visible = true;

        }

        void PriorityDate()
        {
            Method = "Date";
            DateTime date = datePicker.Value.Date + timePicker.Value.TimeOfDay;
            List<Doctor> allDoctors = doctorService.GetAll();
            List<Appointment> allApointments = appointmentService.GetAll();
            List<ObjectId> unavailableDoctors = new List<ObjectId>();
            foreach(Appointment appointment in allApointments)
            {
                DateTime startPoint = appointment.dateTime.AddMinutes(-15);
                DateTime endPoint = appointment.dateTime.AddMinutes(15);
                if (DateTime.Compare(date, startPoint) > 0 && DateTime.Compare(date, endPoint) < 0)
                {
                    unavailableDoctors.Add(appointment.doctorId);
                }
            }
            foreach(Doctor doctor in allDoctors.ToList())
            {
                foreach(ObjectId unavailableId in unavailableDoctors)
                {
                    if(doctor._id == unavailableId)
                    {
                        allDoctors.Remove(doctor);
                    }
                }
            }
            if(allDoctors.Count == 0)
            {
                infoLabel.Text = "None of the doctors is available at that date.";
            }
            else
            {
                Doctor mainDoctor = allDoctors[0];
                infoLabel.Text = "Selected Doctor isn't available. System chose " + mainDoctor.name + " " + mainDoctor.lastName + " instead";
                mainDoctorId = mainDoctor._id;
                submitBtn.Visible = true;
            }
            infoLabel.Visible = true;
        }

        void submit(DateTime dateTime, ObjectId doctor)
        {
            List<Room> allRooms = roomService.GetAll();
            List<Appointment> allApointments = appointmentService.GetAll();
            foreach (Appointment appointment in allApointments)
            {
                DateTime startPoint = appointment.dateTime.AddMinutes(-15);
                DateTime endPoint = appointment.dateTime.AddMinutes(15);
                if (DateTime.Compare(dateTime, startPoint) > 0 && DateTime.Compare(dateTime, endPoint) < 0)
                {
                    foreach (Room room in allRooms.ToList())
                    {
                        if (room._id == appointment.roomId)
                        {
                            allRooms.Remove(room);
                        }
                    }

                }
            }
            string roomType;
            ApointmentType apointmentType;
            if (typeBox.SelectedItem.ToString() == "Operation")
            {
                roomType = "OPERATION_ROOM";
                apointmentType = ApointmentType.OPERATION;
            }
            else
            {
                roomType = "CHECKUP_ROOM";
                apointmentType = ApointmentType.CHECKUP;
            }
            foreach (Room room in allRooms.ToList())
            {
                if (room.type.ToString() != roomType)
                {
                    allRooms.Remove(room);
                    
                }
            }
            ObjectId roomSubmit = allRooms[0]._id;
            Appointment appointmentSubmit = new Appointment(dateTime, apointmentType ,doctor, roomSubmit, loggedUser._id);
            appointmentService.Insert(appointmentSubmit);
            UserAction userAction = new UserAction(loggedUser._id, appointmentSubmit._id, DateTime.Today, ActionStatus.CREATE);
            userActionService.Insert(userAction);
            trollCheck();
            infoLabel.Text = "Appointment added successfully";
        }
        int CheckAvailability()
        {
            DateTime date = datePicker.Value.Date + timePicker.Value.TimeOfDay;
            List<Doctor> allDoctors = doctorService.GetAll();
            List<Room> allRooms = roomService.GetAll();
            ObjectId doctorId = allDoctors[0]._id;
            foreach(Doctor doctor in allDoctors)
            {
                if(doctor.name == doctorBox.SelectedItem.ToString().Split(" ")[0] && doctor.lastName == doctorBox.SelectedItem.ToString().Split(" ")[1])
                {
                    doctorId = doctor._id;
                }
            }

            List<Appointment> allApointments = appointmentService.GetAll();
            foreach(Appointment apointment in allApointments)
            {
                DateTime startPoint = apointment.dateTime.AddMinutes(-15);
                DateTime endPoint = apointment.dateTime.AddMinutes(15);
                if (apointment.doctorId == doctorId && DateTime.Compare(date, startPoint) > 0 && DateTime.Compare(date, endPoint) < 0)
                {
                    return 1;
                }else if (DateTime.Compare(date, startPoint) > 0 && DateTime.Compare(date, endPoint) < 0)
                {
                    foreach(Room room in allRooms.ToList())
                    {
                        if(room._id == apointment.roomId)
                        {
                            allRooms.Remove(room);
                        }
                    }
                    
                }
            }
            string roomType;
            if(typeBox.SelectedItem.ToString() == "Operation")
            {
                roomType = "OPERATION_ROOM";
            }
            else
            {
                roomType = "CHECKUP_ROOM";
            }
            foreach(Room room in allRooms.ToList())
            {
                if(room.type.ToString() != roomType)
                {
                    allRooms.Remove(room);
                }
            }
            if (!allRooms.Any())
            {
                return 2;
            }
            return 3;
        }

        void loadDoctor()
        {
            doctorBox.Items.Clear();
            List<Doctor> allDoctors = doctorService.GetAll();
            foreach (Doctor doctor in allDoctors)
            {
                string doctorName = doctor.name + " " + doctor.lastName;
                doctorBox.Items.Add(doctorName);
            }
        }

        private void RecommendedScheduling_Load(object sender, EventArgs e)
        {
            typeBox.Items.Clear();
            priorityBox.Items.Clear();
            typeBox.Items.Add("Operation");
            typeBox.Items.Add("Checkup");
            priorityBox.Items.Add("Date");
            priorityBox.Items.Add("Doctor");
            datePicker.MinDate = DateTime.Today;
            timePicker.CustomFormat = "HH:mm";
            timePicker.Format = DateTimePickerFormat.Custom;
            submitBtn.Visible = false;
            infoLabel.Visible = false;
            recommendBox.Visible = false;
            recommendLabel.Visible = false;
            loadDoctor();
        }

        void boxChange()
        {
            if (EverythingFilledCheck())
            {
                if (CheckAvailability() == 1)
                {
                    if (priorityBox.SelectedItem.ToString() == "Doctor")
                    {
                        PriorityDoctor();
                    }
                    else
                    {
                        PriorityDate();
                    }
                }
                else if (CheckAvailability() == 2)
                {
                    infoLabel.Text = "There are no available rooms for the selected date.";
                    infoLabel.Visible = true;
                }
                else
                {
                    submitBtn.Visible = true;
                }
            }
        }

        private void priorityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxChange();
        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxChange();
        }

        private void doctorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxChange();
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateChosen = datePicker.Value.Date;
            if (dateChosen == DateTime.Today.Date)
            {
                timePicker.MinDate = DateTime.Now;
            }
            else
            {
                timePicker.MinDate = DateTime.Parse("00:00:00");
            }
            boxChange();
        }

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            boxChange();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            List<Doctor> allDoctors = doctorService.GetAll();
            ObjectId doctorId = allDoctors[0]._id;
            DateTime date;
            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.name == doctorBox.SelectedItem.ToString().Split(" ")[0] && doctor.lastName == doctorBox.SelectedItem.ToString().Split(" ")[1])
                {
                    doctorId = doctor._id;
                }
            }
            if(Method == "Date")
            {
                date = datePicker.Value.Date + timePicker.Value.TimeOfDay;
                doctorId = mainDoctorId;
            }
            else
            {
                date = DateTime.ParseExact(recommendBox.SelectedItem.ToString(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            }
            submit(date, doctorId);
        }

        private void recommendBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            submitBtn.Visible = true;
        }
    }
}
