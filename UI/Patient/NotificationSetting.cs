using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.NotificationModel;
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

namespace HealthcareSystem.UI.Patient
{
    partial class NotificationSetting : Form
    {
        public User loggedUser { get; set; }
        public NotificationSettingsService notificationSettingsService {get; set;}
        public NotificationSetting(User loggedUser)
        {
            notificationSettingsService = Globals.container.Resolve<NotificationSettingsService>();
            InitializeComponent();
            this.loggedUser = loggedUser;
        }

        private void NotificationSetting_Load(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(Math.Round(hoursNumeric.Value, 0));
            notificationSettingsService.ChangeTimeById(loggedUser._id, count);
            successLabel.Visible = true;
        }
    }
}
