using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
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
    partial class ScheduleForm : Form
    {
        public Doctor loggedUser { get; set; }
        public List<Appointment> apointments { get; set; }

        public RoomService roomService;
        public HealthCardService healthCardService;
        public UserService userService;
        public AppointmentService appointmentService;

        public ScheduleForm(Doctor loggedUser, List<Appointment> apointments)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.apointments = apointments;
            this.roomService = Globals.container.Resolve<RoomService>();
            this.healthCardService = Globals.container.Resolve<HealthCardService>();
            this.userService = Globals.container.Resolve<UserService>();
            this. appointmentService = Globals.container.Resolve<AppointmentService>();
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();

            foreach (Appointment appointment in apointments)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                User patient = userService.GetById(appointment.patientId);
                Room room = roomService.GetById(appointment.roomId.ToString());



                row.Cells[0].Value = appointment._id.ToString();

                row.Cells[1].Value = appointment.dateTime.ToString("dd/MM/yyyy");
                row.Cells[2].Value = appointment.dateTime.ToString("t");

                if (patient == null)
                {
                    row.Cells[3].Value = "Obrisan";
                    row.Cells[4].Value = "Obrisan";
                }
                else
                {
                    row.Cells[3].Value = patient.name;
                    row.Cells[4].Value = patient.lastName;
                }

                dataGridView1.Rows.Add(row);

            }
        }

        private void performBtn_Click(object sender, EventArgs e)
        {
           
            int rowindex = dataGridView1.CurrentRow.Index;
            string selectedAppointmentId = (string)dataGridView1.Rows[rowindex].Cells[0].Value;
            if (dataGridView1.Rows[rowindex].Cells[0].Value != null)
            {
                Appointment certainAppointent = appointmentService.GetById(new MongoDB.Bson.ObjectId(selectedAppointmentId));
                User patient = userService.GetById(certainAppointent.patientId);
                HealthCard patientsHealthCard = healthCardService.GetByPatientId(patient._id);
                CheckForm checkForm = new CheckForm(certainAppointent, patient, patientsHealthCard);
                checkForm.Show();
            }
            else
            {
                warningMessageLabel.Text = "Appointment is not selected!";
                warningMessageLabel.Visible = true;

            }
            
        }
    }
}
