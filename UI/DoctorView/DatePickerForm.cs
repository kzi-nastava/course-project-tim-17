using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DoctorModel;
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
    partial class DatePickerForm : Form
    {
        public Doctor loggedUser { get; set; }
        public DoctorRepositories doctorRepositories { get; set; }
        public DatePickerForm(Doctor LoggedUser, DoctorRepositories doctorRepositories)
        {
            InitializeComponent();
            this.loggedUser = LoggedUser; 
            this.doctorRepositories = doctorRepositories;
        
        }

        private void DatePickerForm_Load(object sender, EventArgs e)
        {

        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            DateTime pickedDateTime = GetDate();
            List<Apointment> certanAppointments = GetCertainAppointments(pickedDateTime);
        }

        private List<Apointment> GetCertainAppointments(DateTime pickedDateTime)
        {
            return doctorRepositories.apointmentController.apointmentCollection
               .Find(item => item.doctorId == loggedUser._id & item.dateTime > pickedDateTime & item.dateTime < pickedDateTime.AddDays(4)).ToList();
        }

        private DateTime GetDate()
        {
            return dateTimePicker1.Value.Date;
        }
    }
}
