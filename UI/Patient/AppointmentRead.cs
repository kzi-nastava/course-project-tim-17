using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.RoomModel.RoomFiles;

namespace HealthcareSystem.UI.Patient
{
    partial class AppointmentRead : Form
    {
        public User loggedUser { get; set; }
        public PatientRepositories patientRepositories { get; set; }
        public AppointmentRead(User loggedUser, PatientRepositories patientRepositories)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.patientRepositories = patientRepositories;
        }

        private void dataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AppointmentRead_Load(object sender, EventArgs e)
        {
            
            List<Apointment> selectedApointments = new List<Apointment>();
            List<Apointment> allApointments = patientRepositories.appointmentController.getAllAppointments().ToList();
            foreach (Apointment apointment in allApointments)
            {
                if (apointment.patientId == loggedUser._id)
                {
                    selectedApointments.Add(apointment);
                }
            }
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Appointment Date", typeof(string));
            dataTable.Columns.Add("Appointment Type", typeof(string));
            dataTable.Columns.Add("Doctor", typeof(string));
            dataTable.Columns.Add("Room", typeof(string));
            foreach (Apointment apointment in selectedApointments)
            {
                string date = apointment.dateTime.ToString("dd/MM/yyyy HH:mm");
                string type = apointment.type.ToString();
                Doctor doctor = patientRepositories.doctorController.findById(apointment.doctorId);
                string doctorName = doctor.name + " " + doctor.lastName;
                Room room = patientRepositories.roomController.GetById(apointment.roomId);
                string roomName = room.name;
                dataTable.Rows.Add(date, type, doctorName, roomName);
            }
            dataGridView.DataSource = dataTable;

        }
    }
}
