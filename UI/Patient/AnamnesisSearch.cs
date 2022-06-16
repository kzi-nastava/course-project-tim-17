using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.Enumerations;
using MongoDB.Driver;
using MongoDB.Bson;
using Autofac;
using System.Data;
using HealthcareSystem.Entity.RoomModel.RoomFiles;

namespace HealthcareSystem.UI.Patient
{

    partial class AnamnesisSearch : Form
    {
        public class InputData
        {
            public DateTime appointmentDate;
            public string appointmentType;
            public string doctor;
            public string room;
            public string anamnesisDescription;
            public string anamnesisSymptoms;
            public string anamnesisDiagnosis;

        }
        public User loggedUser { get; set; }
        public RoomService roomService { get; set; }
        public AppointmentService appointmentService { get; set; }
        public HealthCardService healthCardService { get; set; }
        public CheckService checkService { get; set; }
        public DoctorService doctorService { get; set; }
        public HealthCard userHealthCard { get; set; }
        public List<InputData> checkData { get; set; } = new List<InputData>();
        public DataTable dataTable { get; set; } = new DataTable();
        public AnamnesisSearch(User loggedUser)
        {
            appointmentService = Globals.container.Resolve<AppointmentService>();
            roomService = Globals.container.Resolve<RoomService>();
            healthCardService = Globals.container.Resolve<HealthCardService>();
            checkService = Globals.container.Resolve<CheckService>();
            doctorService = Globals.container.Resolve<DoctorService>();
            InitializeComponent();
            this.loggedUser = loggedUser;
        }


        void findHealthCardId()
        {
            List<HealthCard> allHealthCards = healthCardService.GetAll();
            foreach (HealthCard healthCard in allHealthCards)
            {
                if (healthCard.patientId == loggedUser._id)
                {
                    userHealthCard = healthCard;
                }
            }
        }

        void insertNew(List<InputData> newData)
        {
            dataTable.Rows.Clear();
            foreach (InputData data in newData)
            {
                string date = data.appointmentDate.ToString("dd/MM/yyyy HH:mm");
                dataTable.Rows.Add(data.appointmentDate, data.appointmentType, data.doctor, data.room, data.anamnesisDescription, data.anamnesisSymptoms, data.anamnesisDiagnosis);
            }
            dataGridView.DataSource = dataTable;
            dataGridView.Refresh();
        }

        void sortDate()
        {
            List<InputData> listSorted = checkData.OrderBy(x => x.appointmentDate).ToList();
            insertNew(listSorted);
        }

        void sortAnamnesis()
        {
            List<InputData> listSorted = checkData.OrderBy(x => x.anamnesisDiagnosis).ToList();
            insertNew(listSorted);
        }
        
        void sortDoctor()
        {
            List<InputData> listSorted = checkData.OrderBy(x => x.doctor).ToList();
            insertNew(listSorted);
        }

        void keywordFill()
        {
            if(keywordBox.Text != "")
            {
                List<InputData> newData = new List<InputData>();
                foreach(InputData data in checkData)
                {
                    if (data.anamnesisDiagnosis.ToLower().Contains(keywordBox.Text.ToLower()))
                    {
                        newData.Add(data);
                    }
                }
                insertNew(newData);
            }
        }

        private void AnamnesisSearch_Load(object sender, EventArgs e)
        {
            findHealthCardId();
            sortBox.Items.Add("Date");
            sortBox.Items.Add("Doctor");
            sortBox.Items.Add("Anamnesis");

            List<Appointment> selectedApointments = new List<Appointment>();
            List<Appointment> allApointments = appointmentService.GetAll();
            List<Check> allChecks = checkService.GetAll();
            List<Check> userChecks = new List<Check>();
            foreach (Appointment apointment in allApointments)
            {
                if (apointment.patientId == loggedUser._id)
                {
                    selectedApointments.Add(apointment);
                }
            }
            if (!userHealthCard.checks.Any())
            {
                keywordLabel.Text = "Patient does not have any checks available at the moment";
                keywordBox.Visible = false;
                sortBox.Visible = false;
                submitBtn.Visible = false;
                sortLabel.Visible = false;
                dataGridView.Visible = false;
            }
            else
            {
                foreach (ObjectId checkId in userHealthCard.checks)
                {
                    foreach (Check check in allChecks.ToList())
                    {
                        if (check._id == checkId)
                        {
                            userChecks.Add(check);
                        }
                    }
                }

                dataTable.Columns.Add("Appointment Date", typeof(string));
                dataTable.Columns.Add("Appointment Type", typeof(string));
                dataTable.Columns.Add("Doctor", typeof(string));
                dataTable.Columns.Add("Room", typeof(string));
                dataTable.Columns.Add("Anamnesis Description", typeof(string));
                dataTable.Columns.Add("Anamnesis Symptoms", typeof(string));
                dataTable.Columns.Add("Anamnesis Diagnosis", typeof(string));
                
                string anamnesisDescription = userChecks[0].anamnesis.description, anamnesisSymptoms = userChecks[0].anamnesis.symptoms, anamnesisDiagnosis = userChecks[0].anamnesis.diagnosis;
                foreach (Check check in userChecks)
                {
                    foreach(Appointment apointment in selectedApointments)
                    {
                        if(apointment._id == check.appointmentId)
                        {
                            InputData data = new InputData();
                            string date = apointment.dateTime.ToString("dd/MM/yyyy HH:mm");
                            string type = apointment.type.ToString();
                            Doctor doctor = doctorService.GetById(apointment.doctorId);
                            string doctorName = doctor.name + " " + doctor.lastName;
                            Room room = roomService.GetById(apointment.roomId.ToString());
                            string roomName = room.name;
                            anamnesisDescription = check.anamnesis.description;
                            anamnesisSymptoms = check.anamnesis.symptoms;
                            anamnesisDiagnosis = check.anamnesis.diagnosis;
                            dataTable.Rows.Add(date, type, doctorName, roomName, anamnesisDescription, anamnesisSymptoms, anamnesisDiagnosis);

                            data.appointmentDate = apointment.dateTime;
                            data.appointmentType = apointment.type.ToString();
                            data.doctor = doctorName;
                            data.room = roomName;
                            data.anamnesisDescription = anamnesisDescription;
                            data.anamnesisSymptoms = anamnesisSymptoms;
                            data.anamnesisDiagnosis = anamnesisDiagnosis;
                            checkData.Add(data);
                        }
                    }
                }
                dataGridView.DataSource = dataTable;
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            keywordFill();
        }

        private void sortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sortBox.SelectedItem.ToString() == "Date")
            {
                sortDate();
            }else if (sortBox.SelectedItem.ToString() == "Doctor")
            {
                sortDoctor();
            }
            else
            {
                sortAnamnesis();
            }
        }
    }
}
