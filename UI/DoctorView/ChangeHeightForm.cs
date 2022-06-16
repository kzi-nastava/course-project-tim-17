using HealthcareSystem.Entity.HealthCardModel;
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
using Autofac;

namespace HealthcareSystem.UI.DoctorView
{
    partial class ChangeHeightForm : Form
    {
        public HealthCard patientsHealthCard { get; set; }
        public HealthCardService healthCardService;
        public ChangeHeightForm(HealthCard patientsHealthCard)
        {
            InitializeComponent();
            this.patientsHealthCard = patientsHealthCard;
            this. healthCardService = Globals.container.Resolve<HealthCardService>();
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            double newHeight = Convert.ToDouble(newHeightTextBox.Text);
            patientsHealthCard.height = newHeight;
            healthCardService.Update(patientsHealthCard);
            MessageBox.Show("Height changed succesfully!");
            this.Dispose();
        }
    }
}
