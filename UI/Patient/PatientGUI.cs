using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthcareSystem.UI.Patient
{
    partial class PatientGUI : Form
    {
    
        public User loggedUser { get; set; }
        public PatientRepositories patientRepositories { get; set; }
        public PatientGUI(User loggedUser, PatientRepositories patientRepositories)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.patientRepositories = patientRepositories;
        }

        private void PatientGUI_Load(object sender, EventArgs e)
        {

        }

        private void schedulingBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppointmentSchedulingOptions appointmentSchedulingOptions = new AppointmentSchedulingOptions(loggedUser, patientRepositories);
            appointmentSchedulingOptions.Show();
        }

        private void readAppointmentBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppointmentRead appointmentRead = new AppointmentRead(loggedUser, patientRepositories);
            appointmentRead.Show();
        }

        private void changeAppointmentBtn_Click(object sender, EventArgs e)
        {

        }
        private void deleteAppointmentBtn_Click(object sender, EventArgs e)
        {

        }
        private void searchAnamnsesisBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnamnesisSearch anamnesisSearch = new AnamnesisSearch(loggedUser, patientRepositories);
            anamnesisSearch.Show();
        }
        private void searchDoctorBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorSearch doctorSearch = new DoctorSearch(loggedUser, patientRepositories);
            doctorSearch.Show();
        }
        private void surveyDoctorBtn_Click(object sender, EventArgs e)
        {

        }
        private void surveyHospitalBtn_Click(object sender, EventArgs e)
        {

        }

        private void notificationBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            NotificationSetting notificationSetting = new NotificationSetting(loggedUser, patientRepositories);
            notificationSetting.Show();
        }
    }
}
