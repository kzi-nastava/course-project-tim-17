using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthcareSystem.UI.DoctorView
{
    partial class AppointmentCreationForm : Form
    {
        public Doctor loggedUser { get; set; }
        public DoctorRepositories doctorRepositories { get; set; }
        public AppointmentCreationForm(Doctor loggedUser, DoctorRepositories doctorRepositories)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.doctorRepositories = doctorRepositories;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AppointmentCreationForm_Load(object sender, EventArgs e)
        {

        }
        private void createBtn_Click(object sender, EventArgs e)
        {
            DateTime dateTime = GetDateTime();
            ApointmentType apointmentType = GetApointmentType();
            RoomType roomType = RoomType.CHECKUP_ROOM;
            if(apointmentType == ApointmentType.OPERATION)
            {
                roomType = RoomType.OPERATION_ROOM;
            }
            Room room = GetRoom(roomType);
            User patient = GetPatient();
            if (InvalidDateTime(dateTime))
            {
                messageLabel.Text = "Entered Date is Invalid!";
                messageLabel.Visible = true;
            }
            else if (InvalidRoom(room, dateTime))
            {
                messageLabel.Text = "Entered Room is Invalid!";
                messageLabel.Visible = true;
            }
            else if (InvalidPatient(patient))
            {
                messageLabel.Text = "Entered Patient is Invalid!";
                messageLabel.Visible = true;
            }
            else
            {
                doctorRepositories.apointmentController.Insert(new Appointment(dateTime, apointmentType, loggedUser._id, room._id, patient._id));
                MessageBox.Show("Appointment deleted succesfully!");
                this.Dispose();
                
            }
        }
        public ApointmentType GetApointmentType()
        {
            if (CheckupRadioBtn.Checked)
            {
                return ApointmentType.CHECKUP;
            }
            return ApointmentType.OPERATION;
        }
        public DateTime GetDateTime()
        {
            int year = Int32.Parse(yearTextBox.Text);
            int month = Int32.Parse(monthTextBox.Text);
            int day = Int32.Parse(dayTextBox.Text);
            int hour = Int32.Parse(hourTextBox.Text);
            int minute = Int32.Parse(minuteTextBox.Text);
            return new DateTime(year, month, day, hour, minute, 0);
        }
        public Room GetRoom(RoomType roomType)
        {
            Room room = doctorRepositories.roomController.roomCollection.Find(item => item.name == roomNameTextBox.Text && item.type == roomType).FirstOrDefault();
            return room;
        }
        public User GetPatient()
        {
            User patient = doctorRepositories.userController.userCollection.Find(item => item.name == patientNameTextBox.Text && item.lastName == patientLastNameTextBox.Text).FirstOrDefault();
            return patient;
        }

        public Boolean InvalidDateTime(DateTime dateTime)
        {
            DateTime currentDateTime = DateTime.Now;
            //DateTime.Compare(date1, date2) returns:
            // <0 − If date1 is earlier than date2
            // 0 − If date1 is the same as date2
            // >0 − If date1 is later than date2
            int resultOfComparison = DateTime.Compare(dateTime, currentDateTime);
            if (resultOfComparison < 0)
            {
                return true;
            }

            Appointment unavailableApointment = doctorRepositories.apointmentController.appointmentCollection
                .Find(item => item.dateTime == dateTime).FirstOrDefault();
            if (unavailableApointment != null)
            {
                return true;
            }

            return false;
        }
        public Boolean InvalidRoom(Room room, DateTime dateTime)
        {
            if (room == null)
            {
                return true;
            }
            Appointment apointment = doctorRepositories.apointmentController.appointmentCollection
                .Find(item => item.dateTime == dateTime & item.roomId == room._id).FirstOrDefault();
            if (apointment != null)
            {
                return true;
            }

            return false;
        }
        public Boolean InvalidPatient(User patient)
        {
            if (patient == null)
            {
                return true;
            }
            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
