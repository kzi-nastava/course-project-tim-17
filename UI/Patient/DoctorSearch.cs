using MongoDB.Driver;
using MongoDB.Bson;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.Survey.DoctorSurvey;
using HealthcareSystem.Entity.DoctorModel;
using System.Data;

namespace HealthcareSystem.UI.Patient
{
    
    partial class DoctorSearch : Form
    {
        
        public User loggedUser { get; set; }
        public PatientRepositories patientRepositories { get; set; }
        public List<DoctorInfo> doctorList { get; set; } = new List<DoctorInfo>();
        public DataTable dataTable { get; set; } = new DataTable();
        public DoctorSearch(User loggedUser, PatientRepositories patientRepositories)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.patientRepositories = patientRepositories;
        }

        //Klasa sa svim atributima za prikaz
        public class DoctorInfo
        {
            public String name { get; set; }
            public String lastname { get; set; }
            public float avgQuality { get; set; }
            public float avgRecommendation { get; set; }
            public Specialisation specialisation { get; set; }

            public DoctorInfo() { }

            public DoctorInfo(String name, String lastname, float avgQuality, float avgRecommendation, Specialisation specialisation)
            {
                this.name = name;
                this.lastname = lastname;
                this.avgQuality = avgQuality;
                this.avgRecommendation = avgRecommendation;
                this.specialisation = specialisation;
            }
        }

        //Dobijanje prosecnog ratinga, prima kao parametar ID doktora
        List<float> getAverageRating(ObjectId doctorId)
        {
            List<float> avgRating = new List<float>();
            List<float> totalRating = new List<float>();
            for (int i = 0; i < 2; i++)
            {
                float rating = 0;
                avgRating.Add(rating);
                totalRating.Add(rating);
            }
            int size = 0;
            List<DoctorSurveys> allSurveys = patientRepositories.doctorSurveysController.GetAll();
            foreach(DoctorSurveys survey in allSurveys)
            {
                if(doctorId == survey.doctorId)
                {
                    totalRating[0] = totalRating[0] + (int)survey.quality + 1;
                    totalRating[1] = totalRating[1] + (int)survey.recommendation + 1;
                    size += 1;
                }
            }
            if(size == 0)
            {
                avgRating[0] = 0;
                avgRating[1] = 0;
                return avgRating;
            }
            else
            {
                avgRating[0] = totalRating[0] / size;
                avgRating[1] = totalRating[1] / size;
                return avgRating;
            }
        }

        //Trazi sve informacije i dodaje u glavnu listu sa informacijama
        void findInfo()
        {
            List<Doctor> allDoctors = patientRepositories.doctorController.GetAll();
            DoctorInfo doctorInfo = new DoctorInfo();
            foreach (Doctor doctor in allDoctors)
            {
                doctorInfo.name = doctor.name;
                doctorInfo.lastname = doctor.lastName;
                List<float> avgRating = getAverageRating(doctor._id);
                doctorInfo.avgQuality = avgRating[0];
                doctorInfo.avgRecommendation = avgRating[1];
                doctorInfo.specialisation = doctor.specialisation;
                doctorList.Add(doctorInfo);
            }
        }

        //Dodaje sve iteme na pocetku u boxeve potrebne
        void addItems()
        {
            searchComboBox.Items.Add("");
            searchComboBox.Items.Add("Name");
            searchComboBox.Items.Add("Last name");
            searchComboBox.Items.Add("Specialisation");
            searchComboBox.SelectedIndex = 0;

            sortComboBox.Items.Add("");
            sortComboBox.Items.Add("Quality Rating");
            sortComboBox.Items.Add("Recommendation Rating");
            sortComboBox.SelectedIndex = 0;

            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Last name", typeof(string));
            dataTable.Columns.Add("Quality rating", typeof(string));
            dataTable.Columns.Add("Recommendation rating", typeof(string));
            dataTable.Columns.Add("Specialisation", typeof(string));

            foreach(DoctorInfo doctor in doctorList)
            {
                doctorComboBox.Items.Add(doctor.name + " " + doctor.lastname);
            }
            doctorComboBox.SelectedIndex = 0;
        }

        //Dodaje elemente iz liste u tabelu
        void insertItems(List<DoctorInfo> selectedDoctors)
        {
            dataTable.Rows.Clear();
            foreach (DoctorInfo doctorInfo in selectedDoctors)
            {
                string quality, recommendation;
                if (doctorInfo.avgQuality == 0)
                {
                    quality = "No Ratings Available";
                    recommendation = "No Ratings Available";
                }
                else
                {
                    quality = doctorInfo.avgQuality.ToString();
                    recommendation = doctorInfo.avgRecommendation.ToString();
                }
                dataTable.Rows.Add(doctorInfo.name, doctorInfo.lastname, quality, recommendation, doctorInfo.specialisation);
            }
            dataGridView.DataSource = dataTable;
            dataGridView.Refresh();
        }

        //Filtriranje kroz listu preko selektovane kljucne reci
        List<DoctorInfo> selectKeyword()
        {
            if(string.IsNullOrEmpty(searchComboBox.Text))
            {
                return doctorList;
            }
            List<DoctorInfo> selectedDoctors = new List<DoctorInfo>();
            foreach(DoctorInfo doctor in doctorList)
            {
                switch (searchComboBox.SelectedItem.ToString())
                {
                    case "Name":
                        if(doctor.name.ToLower().Contains(searchTextBox.Text.ToLower()))
                        {
                            selectedDoctors.Add(doctor);
                        }
                    break;
                    case "Last name":
                        if (doctor.lastname.ToLower().Contains(searchTextBox.Text.ToLower()))
                        {
                            selectedDoctors.Add(doctor);
                        }
                    break;
                    case "Specialisation":
                        if (doctor.specialisation.ToString().ToLower().Contains(searchTextBox.Text.ToLower()))
                        {
                            selectedDoctors.Add(doctor);
                        }
                    break;
                }
            }
            return selectedDoctors;
        }

        //Sortiranje liste doktora prema odredjenom parametru
        List<DoctorInfo> sortDoctors(List<DoctorInfo> selectedDoctors)
        {
            List<DoctorInfo> doctorListSorted = new List<DoctorInfo>();
            if (string.IsNullOrEmpty(sortComboBox.Text))
            {
                return selectedDoctors;
            }
            switch (this.sortComboBox.GetItemText(sortComboBox.SelectedItem))
            {
                case "Quality Rating":
                    doctorListSorted = doctorList.OrderBy(x => x.avgQuality).ToList();
                break;
                case "Recommendation Rating":
                    doctorListSorted = doctorList.OrderBy(x => x.avgRecommendation).ToList();
                break;
                case "Name":
                    doctorListSorted = doctorList.OrderBy(x => x.name).ToList();
                    break;
                case "Last name":
                    doctorListSorted = doctorList.OrderBy(x => x.lastname).ToList();
                break;
                case "Specialisation":
                    doctorListSorted = doctorList.OrderBy(x => x.specialisation).ToList();
                break;
            }
            return selectedDoctors;
        }

        private void DoctorSearch_Load(object sender, EventArgs e)
        {
            
            findInfo();
            addItems();

            foreach (DoctorInfo doctorInfo in doctorList)
            {
                string quality, recommendation;
                if (doctorInfo.avgQuality == 0)
                {
                    quality = "No Ratings Available";
                    recommendation = "No Ratings Available";
                }
                else
                {
                    quality = doctorInfo.avgQuality.ToString();
                    recommendation = doctorInfo.avgRecommendation.ToString();
                }
                dataTable.Rows.Add(doctorInfo.name, doctorInfo.lastname, quality, recommendation, doctorInfo.specialisation);
            }
            dataGridView.DataSource = dataTable;
            dataGridView.Refresh();
        }

        //Ukoliko se odabir selektovanja po kljucnoj reci promeni, promeni se i moguce sortiranje
        private void searchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sortComboBox.Items.Clear();
            sortComboBox.Items.Add("");
            sortComboBox.Items.Add("Quality Rating");
            sortComboBox.Items.Add("Recommendation Rating");
            if (string.IsNullOrEmpty(searchComboBox.Text))
            {
                sortComboBox.Items.Add(searchComboBox.SelectedItem.ToString());
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            List<DoctorInfo> tableData = new List<DoctorInfo>();
            tableData = selectKeyword();
            tableData = sortDoctors(tableData);
            insertItems(tableData);
        }

        private void appointmentBtn_Click(object sender, EventArgs e)
        {
            string[] a = this.sortComboBox.GetItemText(doctorComboBox.SelectedItem).Split(" ");
            Doctor doctor = patientRepositories.doctorController.GetByNameAndLastName(a[0], a[1]);
            this.Hide();
            RegularScheduling regularScheduling = new RegularScheduling(loggedUser, patientRepositories, doctor._id);
            regularScheduling.Show();
        }
    }
}
