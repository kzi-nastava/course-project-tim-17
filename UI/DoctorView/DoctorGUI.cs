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

namespace HealthcareSystem.UI.DoctorView
{
partial class DoctorGUI : Form
    {
        public Doctor loggedUser { get; set; }
        public DoctorRepositories doctorRepositories { get; set; }


        public DoctorGUI(Doctor loggedUser, DoctorRepositories doctorRepositories)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.doctorRepositories = doctorRepositories;
        }

        private void DoctorGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
