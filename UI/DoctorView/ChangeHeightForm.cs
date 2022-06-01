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
    partial class ChangeHeightForm : Form
    {
        public DoctorRepositories doctorRepositories { get; set; }
        public HealthCard patientsHealthCard { get; set; }
        public ChangeHeightForm(DoctorRepositories doctorRepositories, HealthCard patientsHealthCard)
        {
            InitializeComponent();
            this.doctorRepositories = doctorRepositories;
            this.patientsHealthCard = patientsHealthCard;
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            double newHeight = Convert.ToDouble(newHeightTextBox.Text);
            patientsHealthCard.height = newHeight;
            doctorRepositories.healthCardController.update(patientsHealthCard);
            MessageBox.Show("Height changed succesfully!");
            this.Dispose();
        }
    }
}
