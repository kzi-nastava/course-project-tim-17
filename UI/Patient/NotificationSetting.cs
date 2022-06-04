using HealthcareSystem.Entity.UserModel;
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

namespace HealthcareSystem.UI.Patient
{
    partial class NotificationSetting : Form
    {
        public User loggedUser { get; set; }
        public PatientRepositories patientRepositories { get; set; }
        public NotificationSetting(User loggedUser, PatientRepositories patientRepositories)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.patientRepositories = patientRepositories;
        }

        private void NotificationSetting_Load(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(Math.Round(hoursNumeric.Value, 0));
            patientRepositories.notificationSettingsController.ChangeTimeById(loggedUser._id, count);
            successLabel.Visible = true;
        }
    }
}
