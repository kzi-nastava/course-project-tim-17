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

namespace HealthcareSystem.UI.Secretary

{
    partial class SecretaryGUI : Form
    {
        public User loggedUser { get; set; }
        public SecretaryControllers secretaryControllers { get; set; }
        public SecretaryGUI(User loggedUser, SecretaryControllers secretaryControllers)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.secretaryControllers = secretaryControllers;



        }

        private void SecretaryGUI_Load(object sender, EventArgs e)
        {

        }
    }
}