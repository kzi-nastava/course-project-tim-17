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
    partial class ChangeWeightForm : Form
    {
        public HealthCard patientsHealthCard { get; set; }
        public HealthCardService healthCardService;
        public ChangeWeightForm(HealthCard patientsHealthCard)
        {
            InitializeComponent();
            this.patientsHealthCard = patientsHealthCard;
            this.healthCardService = Globals.container.Resolve<HealthCardService>();
        }

        private void newWeightTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            double newWeight = Convert.ToDouble(newWeightTextBox.Text);
            patientsHealthCard.weight = newWeight;
            healthCardService.Update(patientsHealthCard);
            MessageBox.Show("Weight changed succesfully!");
            this.Dispose();
        }
    }
}
