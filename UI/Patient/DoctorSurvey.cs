using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Survey;
using HealthcareSystem.Entity.Survey.DoctorSurvey;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.ApointmentModel;
using Autofac;
using MongoDB.Bson;

namespace HealthcareSystem.UI.Patient
{
    partial class DoctorSurvey : Form
    {
        public CheckService checkService { get; set; }
        public DoctorService doctorService { get; set; }
        public SurveyService surveyService { get; set; }
        public AppointmentService appointmentService { get; set; }
        public User loggedUser { get; set; }
        public DoctorSurvey(User loggedUser)
        {
            checkService = Globals.container.Resolve<CheckService>();
            doctorService = Globals.container.Resolve<DoctorService>();
            surveyService = Globals.container.Resolve<SurveyService>();
            appointmentService = Globals.container.Resolve<AppointmentService>();
            InitializeComponent();
            this.loggedUser = loggedUser;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Mark quality = 0, recommend = 0;
            if (quality1.Checked == true)
            {
                quality = Mark.ONE;
            }
            else if (quality2.Checked == true)
            {
                quality = Mark.TWO;
            }
            else if (quality3.Checked == true)
            {
                quality = Mark.THREE;
            }
            else if (quality4.Checked == true)
            {
                quality = Mark.FOUR;
            }
            else
            {
                quality = Mark.FIVE;
            }

            if (recommendation1.Checked == true)
            {
                recommend = Mark.ONE;
            }
            else if (recommendation2.Checked == true)
            {
                recommend = Mark.TWO;
            }
            else if (recommendation3.Checked == true)
            {
                recommend = Mark.THREE;
            }
            else if (recommendation4.Checked == true)
            {
                recommend = Mark.FOUR;
            }
            else
            {
                recommend = Mark.FIVE;
            }
            ObjectId doctorId = getDoctorId();
            string comment = commentTextBox.Text;
            DoctorSurveys doctorSurvey = new DoctorSurveys(doctorId, quality, recommend, comment);
            surveyService.InsertDoctorSurvey(doctorSurvey);
            successLabel.Visible = true;
        }

        ObjectId getDoctorId()
        {
            string selectedItem = checkBox.GetItemText(this.checkBox.SelectedItem);
            string name = selectedItem.Split(" - ")[1].Split(" ")[0];
            string lastname = selectedItem.Split(" - ")[1].Split(" ")[1];
            return doctorService.GetByNameAndLastName(name, lastname)._id;
        }

        void loadAllChecks()
        {
            List<Check> allChecks = checkService.GetAll();
            List<Appointment> userAppointments = appointmentService.GetAllByUser(loggedUser._id.ToString());
            List<Doctor> allDoctors = doctorService.GetAll();
            List<string> infoList = new List<string>();
            foreach(Appointment appointment in userAppointments)
            {
                foreach(Check check in allChecks)
                {
                    if (check.appointmentId == appointment._id && appointment.patientId == loggedUser._id)
                    {
                        foreach(Doctor doctor in allDoctors)
                        {
                            if (appointment.doctorId == doctor._id)
                            {
                                infoList.Add(appointment.dateTime.ToString("dd/MM/yyyy HH:mm") + " - " + doctor.name + " " + doctor.lastName);
                            }
                        }
                    }
                }
            }
            foreach(string info in infoList)
            {
                checkBox.Items.Add(info);
            }
            checkBox.SelectedIndex = 0;
        }

        private void DoctorSurvey_Load(object sender, EventArgs e)
        {
            loadAllChecks();
            quality5.PerformClick();
            recommendation5.PerformClick();
            getDoctorId();
        }
    }
}
