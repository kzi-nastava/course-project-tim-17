using HealthcareSystem.Entity.Survey;
using HealthcareSystem.Entity.Survey.DoctorSurvey;
using HealthcareSystem.Entity.Survey.HospitalSurvey;
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

namespace HealthcareSystem.UI.ManagerView
{
    partial class SurveysForm : Form
    {
        public SurveyService surveyService;
        public SurveysForm()
        {
            surveyService = new SurveyService(Globals.database);
            InitializeComponent();
        }
        private void loadDoctorSurveyView() 
        {
            List<DoctorSurveysAverages> dsa = surveyService.GetAllDoctorSurveysAverages();

            foreach (DoctorSurveysAverages ds in dsa)
            {

                ListViewItem item = new ListViewItem(ds.DoctorName);
                item.Tag = ds;
                item.SubItems.Add(ds.DoctorSurname);
                item.SubItems.Add(String.Format("{0:0.00}", ds.AverageQuality));
                item.SubItems.Add(String.Format("{0:0.00}", ds.AverageReccomendation));
                doctorSurveyView.Items.Add(item);

            }
        }
        private void SurveysForm_Load(object sender, EventArgs e)
        {
            loadDoctorSurveyView();
            loadHospitalSurveyView();

        }

        public void loadHospitalSurveyView()
        {
            HospitalSurveysAverages hsa = surveyService.GetHospitalSurveysAverages();

            ListViewItem item = new ListViewItem(String.Format("{0:0.00}", hsa.AverageQuality));
            item.Tag = hsa;
            item.SubItems.Add(String.Format("{0:0.00}", hsa.AverageCleanliness));
            item.SubItems.Add(String.Format("{0:0.00}", hsa.AverageSatisfaction));
            hospitalSurveyView.Items.Add(item);

        }

        private void doctorSurveyView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void reccomendationButton_Click(object sender, EventArgs e)
        {
            DoctorSurveysAverages ds = (DoctorSurveysAverages)doctorSurveyView.SelectedItems[0].Tag;
            showMoreInfo(ds.marksForReccomendation);
        }

        private void showMoreInfo(List<double> inputMarks)
        {
            
            double[] marks = surveyService.GetNumberOfMarks(inputMarks);
            
            oneLabel.Text = marks[0].ToString();
            twoLabel.Text = marks[1].ToString();
            threeLabel.Text = marks[2].ToString();
            fourLabel.Text = marks[3].ToString();
            fiveLabel.Text = marks[4].ToString();
        }

        private void qualityButton_Click(object sender, EventArgs e)
        {
            DoctorSurveysAverages ds = (DoctorSurveysAverages)doctorSurveyView.SelectedItems[0].Tag;
            showMoreInfo(ds.marksForQuality);
        }

        private void hospitalQualityButton_Click(object sender, EventArgs e)
        {
            HospitalSurveysAverages hsa = surveyService.GetHospitalSurveysAverages();
            showMoreInfo(hsa.marksForQuality);
        }

        private void hopistalCleanlinessButton_Click(object sender, EventArgs e)
        {
            HospitalSurveysAverages hsa = surveyService.GetHospitalSurveysAverages();
            showMoreInfo(hsa.marksForCleanliness);
        }

        private void hospitalSatisfactionButton_Click(object sender, EventArgs e)
        {
            HospitalSurveysAverages hsa = surveyService.GetHospitalSurveysAverages();
            showMoreInfo(hsa.marksForSatisfaction);
        }

        private void hospitalCommentsButton_Click(object sender, EventArgs e)
        {
            commentsView.Items.Clear();
            List<HospitalSurveys> hs = surveyService.GetAllHospitalSurveys();

            foreach (HospitalSurveys survey in hs) 
            {
                ListViewItem item = new ListViewItem(survey.comment);
                
                commentsView.Items.Add(item);
            }
        }

        private void doctorCommentsButton_Click(object sender, EventArgs e)
        {
            commentsView.Items.Clear();
            DoctorSurveysAverages ds = (DoctorSurveysAverages)doctorSurveyView.SelectedItems[0].Tag;
            foreach (string comment in ds.comments)
            {
                ListViewItem item = new ListViewItem(comment);

                commentsView.Items.Add(item);
            }

        }
    }
}
