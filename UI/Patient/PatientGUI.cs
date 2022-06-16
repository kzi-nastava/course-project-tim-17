using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.NotificationModel;
using HealthcareSystem.Entity.HealthCardModel;
using Autofac;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HealthcareSystem.Entity.CheckModel;

namespace HealthcareSystem.UI.Patient
{
    partial class PatientGUI : Form
    {
        public User loggedUser { get; set; }
        public NotificationSettingsService notificationSettingsService { get; set; }
        public DrugService drugService { get; set; }
        public HealthCardService healthCardService { get; set; }
        public CheckService checkService { get; set; }
        public PatientGUI(User loggedUser)
        {
            notificationSettingsService = Globals.container.Resolve<NotificationSettingsService>();
            drugService = Globals.container.Resolve<DrugService>();
            healthCardService = Globals.container.Resolve<HealthCardService>();
            checkService = Globals.container.Resolve<CheckService>();
            InitializeComponent();
            this.loggedUser = loggedUser;
        }

        void AddNotification()
        {
            List<ObjectId> listChecks = healthCardService.GetByPatientId(loggedUser._id).checks;
            List<Check> checkList = new List<Check>();
            foreach(ObjectId checkId in listChecks)
            {
                checkList.Add(checkService.GetById(checkId.ToString()));
            }
            string finalPrint = "";
            List<DateTime> clockList = new List<DateTime>();
            DateTime prescriptionDate;
            TimeSpan prescriptionTime;
            int hourCheck = notificationSettingsService.GetById(loggedUser._id).time;
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
                        string drugName = drugService.GetById(check.prescription.drug.ToString()).name;
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
            AppointmentSchedulingOptions appointmentSchedulingOptions = new AppointmentSchedulingOptions(loggedUser);
            appointmentSchedulingOptions.Show();
        }

        private void readAppointmentBtn_Click(object sender, EventArgs e)
        {
            AppointmentRead appointmentRead = new AppointmentRead(loggedUser);
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
            AnamnesisSearch anamnesisSearch = new AnamnesisSearch(loggedUser);
            anamnesisSearch.Show();
        }
        private void searchDoctorBtn_Click(object sender, EventArgs e)
        {
            DoctorSearch doctorSearch = new DoctorSearch(loggedUser);
            doctorSearch.Show();
        }
        private void surveyDoctorBtn_Click(object sender, EventArgs e)
        {
            DoctorSurvey doctorSurvey = new DoctorSurvey(loggedUser);
            doctorSurvey.Show();
        }
        private void surveyHospitalBtn_Click(object sender, EventArgs e)
        {
            HospitalSurvey hospitalSurvey = new HospitalSurvey(loggedUser);
            hospitalSurvey.Show();
        }

        private void notificationBtn_Click(object sender, EventArgs e)
        {
            NotificationSetting notificationSetting = new NotificationSetting(loggedUser);
            notificationSetting.Show();
        }
    }
}
