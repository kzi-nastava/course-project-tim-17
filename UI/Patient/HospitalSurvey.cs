using System;
using System.Collections.Generic;
using System.ComponentModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.Survey;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.Survey.HospitalSurvey;
using Autofac;

namespace HealthcareSystem.UI.Patient
{
    partial class HospitalSurvey : Form
    {
        public User loggedUser { get; set; }
        public SurveyService surveyService { get; set; }
        public HospitalSurvey(User loggedUser)
        {
            surveyService = Globals.container.Resolve<SurveyService>();
            this.loggedUser = loggedUser;
            InitializeComponent();
        }

        private void HospitalSurvey_Load(object sender, EventArgs e)
        {
            quality5.PerformClick();
            cleanliness5.PerformClick();
            satisfaction5.PerformClick();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            Mark quality = 0, cleanliness = 0, satisfaction = 0;
            if (quality1.Checked == true)
            {
                quality = Mark.ONE;
            }else if (quality2.Checked == true)
            {
                quality = Mark.TWO;
            }
            else if(quality3.Checked == true)
            {
                quality = Mark.THREE;
            }
            else if(quality4.Checked == true)
            {
                quality = Mark.FOUR;
            }
            else
            {
                quality = Mark.FIVE;
            }

            if (satisfaction1.Checked == true)
            {
                satisfaction = Mark.ONE;
            }
            else if (satisfaction2.Checked == true)
            {
                satisfaction = Mark.TWO;
            }
            else if (satisfaction3.Checked == true)
            {
                satisfaction = Mark.THREE;
            }
            else if (satisfaction4.Checked == true)
            {
                satisfaction = Mark.FOUR;
            }
            else
            {
                satisfaction = Mark.FIVE;
            }

            if (cleanliness1.Checked == true)
            {
                cleanliness = Mark.ONE;
            }
            else if (cleanliness2.Checked == true)
            {
                cleanliness = Mark.TWO;
            }
            else if (cleanliness3.Checked == true)
            {
                cleanliness = Mark.THREE;
            }
            else if (cleanliness4.Checked == true)
            {
                cleanliness = Mark.FOUR;
            }
            else
            {
                cleanliness = Mark.FIVE;
            }

            string comment = commentTextBox.Text;

            HospitalSurveys survey = new HospitalSurveys(quality, cleanliness, satisfaction, comment);
            surveyService.InsertHospitalSurvey(survey);
            successLabel.Visible = true;
        }
    }
}
