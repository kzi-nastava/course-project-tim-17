using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Driver;
using MongoDB.Bson;
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
    partial class AppointmentSchedulingOptions : Form
    {
        public User loggedUser { get; set; }
        public AppointmentSchedulingOptions(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
        }

        private void regularBtn_Click(object sender, EventArgs e)
        {
            ObjectId doctorId = new ObjectId();
            this.Hide();
            RegularScheduling regularScheduling = new RegularScheduling(loggedUser, doctorId);
            regularScheduling.Show();
        }

        private void recommendedBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            RecommendedScheduling recommendedScheduling = new RecommendedScheduling(loggedUser);
            recommendedScheduling.Show();
        }

        private void AppointmentSchedulingOptions_Load(object sender, EventArgs e)
        {

        }
    }
}
