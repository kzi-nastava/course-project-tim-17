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
using Autofac;

namespace HealthcareSystem.UI.DoctorView
{
    partial class DatePickerForm : Form
    {
        public Doctor loggedUser { get; set; }
        public AppointmentService appointmentService;
        public DatePickerForm(Doctor LoggedUser)
        {
            InitializeComponent();
            this.loggedUser = LoggedUser;
            this.appointmentService = Globals.container.Resolve<AppointmentService>();

        
        }

        private void DatePickerForm_Load(object sender, EventArgs e)
        {

        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            DateTime pickedDateTime = GetDate();
            List<Appointment> certanAppointments = appointmentService.GetDoctorSchedule(loggedUser._id, pickedDateTime, pickedDateTime.AddDays(4));
            ScheduleForm scheduleForm = new ScheduleForm(loggedUser, certanAppointments);
            scheduleForm.Show();
            this.Dispose();
        }


        private DateTime GetDate()
        {
            return dateTimePicker1.Value.Date;
        }
    }
}
