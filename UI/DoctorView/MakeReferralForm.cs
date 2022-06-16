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
using Autofac;

namespace HealthcareSystem.UI.DoctorView
{
    partial class MakeReferralForm : Form
    {
        public HealthCard patientHealthCard;
        public HealthCardService healthCardService;
        public ReferralService referralService;
        public DoctorService doctorService;
        public MakeReferralForm(HealthCard patientHealthCard)
        {
            InitializeComponent();
            this.patientHealthCard = patientHealthCard;
            this.healthCardService = Globals.container.Resolve<HealthCardService>();
            this.referralService = Globals.container.Resolve<ReferralService>();
            this.doctorService = Globals.container.Resolve<DoctorService>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void createReferralBtn_Click(object sender, EventArgs e)
        {
            Doctor doctorReferredTo = doctorService.GetByNameAndLastName(nameTextBox.Text, lastNameTextBox.Text);
            if (doctorReferredTo == null)
            {
                warningMessageLabel.Text = "Entered Doctor does not exist!";
            }
            else
            {
                Referral referral = new Referral(doctorReferredTo._id, patientHealthCard.patientId, doctorReferredTo.specialisation);
                referralService.Insert(referral);
                patientHealthCard.referrals.Add(referral._id);
                healthCardService.Update(patientHealthCard);
                MessageBox.Show("Referral created sucessfuly");
                this.Dispose();
            }
        }
    }
}
