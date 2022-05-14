using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.ReferralModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Driver;
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
    partial class MakeReferralForm : Form
    {
        public DoctorRepositories doctorRepositories;
        public HealthCard patientHealthCard;
        public MakeReferralForm(DoctorRepositories doctorRepositories, HealthCard patientHealthCard)
        {
            InitializeComponent();
            this.doctorRepositories = doctorRepositories;
            this.patientHealthCard = patientHealthCard;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void createReferralBtn_Click(object sender, EventArgs e)
        {
            Doctor doctorReferredTo = doctorRepositories.doctorController.doctorCollection.Find(Item => Item.name == nameTextBox.Text && Item.lastName == lastNameTextBox.Text).FirstOrDefault();
            if(doctorReferredTo == null)
            {
                warningMessageLabel.Text = "Entered Doctor does not exist!";
            }
            else
            {
                Referral referral = new Referral(doctorReferredTo._id, patientHealthCard.patientId, doctorReferredTo.specialisation);
                doctorRepositories.referralController.InsertToCollection(referral);
                patientHealthCard.referrals.Add(referral._id);
                doctorRepositories.healthCardController.update(patientHealthCard);
                MessageBox.Show("Referral created sucessfuly");
                this.Dispose();
            }
        }
    }
}
