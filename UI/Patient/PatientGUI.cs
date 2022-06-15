using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.DrugModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.CheckModel;

namespace HealthcareSystem.UI.Patient
{
    partial class PatientGUI : Form
    {
        public User loggedUser { get; set; }
        public PatientRepositories patientRepositories { get; set; }
        public PatientGUI(User loggedUser, PatientRepositories patientRepositories)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.patientRepositories = patientRepositories;
        }

        void AddNotification()
        {
            List<ObjectId> listChecks = patientRepositories.healthCardController.FindByPatientId(loggedUser._id).checks;
            List<Check> checkList = new List<Check>();
            foreach(ObjectId checkId in listChecks)
            {
                checkList.Add(patientRepositories.checkController.findById(checkId));
            }
            string finalPrint = "";
            List<DateTime> clockList = new List<DateTime>();
            DateTime prescriptionDate;
            TimeSpan prescriptionTime;
            int hourCheck = patientRepositories.notificationSettingsController.FindById(loggedUser._id).time;
            foreach(Check check in checkList)
            {
                clockList.Clear();
                string[] timeList = check.prescription.when.Split(";");
                for(int i = 0; i < check.prescription.quantityPerDay; i++)
                {
                    prescriptionDate = DateTime.Today;
                    prescriptionTime = new TimeSpan(Int32.Parse(timeList[i].Split(":")[0]), Int32.Parse(timeList[i].Split(":")[1]), 0);
                    prescriptionDate=prescriptionDate.Add(prescriptionTime);
                    clockList.Add(prescriptionDate);
                }
                foreach(DateTime time in clockList)
                {
                    double timeDistance = (time - DateTime.Now).TotalHours;
                    if(hourCheck > timeDistance && timeDistance > 0)
                    {
                        string drugName = patientRepositories.drugController.GetById(check.prescription.drug).name;
                        finalPrint += "You should take " + drugName + " at " + time.ToString("HH:mm") + "\n";
                    }
                }
            }
            notificationLabel.Text = finalPrint;
        }


        private void PatientGUI_Load(object sender, EventArgs e)
        {
           AddNotification();
        }

        private void schedulingBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppointmentSchedulingOptions appointmentSchedulingOptions = new AppointmentSchedulingOptions(loggedUser, patientRepositories);
            appointmentSchedulingOptions.Show();
        }

        private void readAppointmentBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppointmentRead appointmentRead = new AppointmentRead(loggedUser, patientRepositories);
            appointmentRead.Show();
        }

        private void changeAppointmentBtn_Click(object sender, EventArgs e)
        {

        }
        private void deleteAppointmentBtn_Click(object sender, EventArgs e)
        {

        }
        private void searchAnamnsesisBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnamnesisSearch anamnesisSearch = new AnamnesisSearch(loggedUser, patientRepositories);
            anamnesisSearch.Show();
        }
        private void searchDoctorBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorSearch doctorSearch = new DoctorSearch(loggedUser, patientRepositories);
            doctorSearch.Show();
        }
        private void surveyDoctorBtn_Click(object sender, EventArgs e)
        {

        }
        private void surveyHospitalBtn_Click(object sender, EventArgs e)
        {

        }

        private void notificationBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            NotificationSetting notificationSetting = new NotificationSetting(loggedUser, patientRepositories);
            notificationSetting.Show();
        }
    }
}
