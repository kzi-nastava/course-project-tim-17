using System.Data;
using Autofac;
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
        public RoomService roomService { get; set; }
        public AppointmentService appointmentService { get; set; }
        public DoctorService doctorService { get; set; }
        public AppointmentRead(User loggedUser)
        {
            roomService = Globals.container.Resolve<RoomService>();
            appointmentService = Globals.container.Resolve<AppointmentService>();
            doctorService = Globals.container.Resolve<DoctorService>();
            InitializeComponent();
            this.loggedUser = loggedUser;
        }

        private void dataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AppointmentRead_Load(object sender, EventArgs e)
        {
            
            List<Appointment> selectedApointments = new List<Appointment>();
            List<Appointment> allApointments = appointmentService.GetAll();
            foreach (Appointment apointment in allApointments)
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
            foreach (Appointment apointment in selectedApointments)
            {
                string date = apointment.dateTime.ToString("dd/MM/yyyy HH:mm");
                string type = apointment.type.ToString();
                Doctor doctor = doctorService.GetById(apointment.doctorId);
                string doctorName = doctor.name + " " + doctor.lastName;
                Room room = roomService.GetById(apointment.roomId.ToString());
                string roomName = room.name;
                dataTable.Rows.Add(date, type, doctorName, roomName);
            }
            dataGridView.DataSource = dataTable;

        }
    }
}
