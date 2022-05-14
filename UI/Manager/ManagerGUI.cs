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

namespace HealthcareSystem.UI.Manager

{
    partial class ManagerGUI : Form
    {
        public User loggedUser { get; set; }
        public ManagerControllers managerControllers { get; set; }
        public ManagerGUI(User loggedUser, ManagerControllers managerControllers)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.managerControllers = managerControllers;
            label1.Text = loggedUser.name;

            
        }

        private void ManagerGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
