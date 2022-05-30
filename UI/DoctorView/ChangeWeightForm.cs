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

namespace HealthcareSystem.UI.DoctorView
{
    partial class ChangeWeightForm : Form
    {
        public DoctorRepositories doctorRepositories { get; set; }
        public HealthCard patientsHealthCard { get; set; }
        public ChangeWeightForm(DoctorRepositories doctorRepositories, HealthCard patientsHealthCard)
        {
            InitializeComponent();
            this.doctorRepositories = doctorRepositories;
            this.patientsHealthCard = patientsHealthCard;
        }

        private void newWeightTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            double newWeight = Convert.ToDouble(newWeightTextBox.Text);
            patientsHealthCard.weight = newWeight;
            doctorRepositories.healthCardController.update(patientsHealthCard);
            MessageBox.Show("Weight changed succesfully!");
            this.Dispose();
        }
    }
}
