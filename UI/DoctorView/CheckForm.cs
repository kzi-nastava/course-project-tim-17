using HealthcareSystem.Entity;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.HealthCardModel;
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

namespace HealthcareSystem.UI.DoctorView
{
    partial class CheckForm : Form
    {
        public User patient { get; set; }

        public HealthCard patientsHealthCard { get; set; }
        public Appointment appointment { get; set; }


        public CheckForm(Appointment apointment,User patient, HealthCard patientsHealthCard)
        {
            InitializeComponent();
            this.appointment = apointment;
            this.patient = patient;
            this.patientsHealthCard = patientsHealthCard;
        }

        private void CheckForm_Load(object sender, EventArgs e)
        {
            nameLabel.Text += " " + patient.name;
            lastNamelabel.Text += " " + patient.lastName;
            weightLabel.Text += " " + patientsHealthCard.weight.ToString()+"kg";
            heightLabel.Text += " " + patientsHealthCard.height.ToString()+"cm";
            if(patientsHealthCard.allergies.Count == 0)
            {
                allergiesLabeel.Text += " Nema";
            }
            else
            {
                foreach (Ingredient ingredient in patientsHealthCard.allergies)
                {
                    allergiesLabeel.Text += "" + ingredient.name;
                }
            }
            


        }

        private void changeWeightBtn_Click(object sender, EventArgs e)
        {
            ChangeWeightForm changeWeightForm = new ChangeWeightForm(patientsHealthCard);
            changeWeightForm.Show();
        }

        private void changeHeightBtn_Click(object sender, EventArgs e)
        {
            ChangeHeightForm changeHeightForm = new ChangeHeightForm(patientsHealthCard);
            changeHeightForm.Show();
        }

        private void makeReferralBtn_Click(object sender, EventArgs e)
        {
            MakeReferralForm makeReferralForm = new MakeReferralForm(patientsHealthCard);
            makeReferralForm.Show();
        }

        private void performCheckupBtn_Click(object sender, EventArgs e)
        {
            
            PerfomeCheckupForm perfomeCheckupForm = new PerfomeCheckupForm(appointment, patientsHealthCard);
            perfomeCheckupForm.Show();
        }
    }
}
