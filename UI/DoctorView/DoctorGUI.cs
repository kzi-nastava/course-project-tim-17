using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Driver;

namespace HealthcareSystem.UI.DoctorView
{
partial class DoctorGUI : Form
    {
        public Doctor loggedUser { get; set; }
        public DoctorRepositories doctorRepositories { get; set; }
        public IMongoDatabase database;


        public DoctorGUI(Doctor loggedUser, IMongoDatabase database)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.database = database;
            this.doctorRepositories = new DoctorRepositories(database);
        }

        private void DoctorGUI_Load(object sender, EventArgs e)
        {

        }

        private void listAllAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppointmentsTableForm appointmentsTableForm = new AppointmentsTableForm(loggedUser, doctorRepositories);
            appointmentsTableForm.Show();
        }

        private void viewScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatePickerForm datePickerForm = new DatePickerForm(loggedUser, doctorRepositories);
            datePickerForm.Show();
        }

        private void drugRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RevisionForm revisionForm = new RevisionForm();
            revisionForm.Show();
        }

        private void makeRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FreeDayRequestForm freeDayRequestForm = new FreeDayRequestForm(loggedUser);
            freeDayRequestForm.Show();
        }
    }
}
