using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.RoleControllers;
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
    partial class ChangdeAppointmentDateTimeForm : Form
    {
        DoctorRepositories doctorRepositories { get; set; }
        Apointment appointment { get; set; }
        public ChangdeAppointmentDateTimeForm(DoctorRepositories doctorRepositories, Apointment appointment)
        {
            InitializeComponent();
            this.doctorRepositories = doctorRepositories;
            this.appointment = appointment;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
