using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Bson;
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
    partial class AppointmentsTableForm : Form
    {
        public Doctor loggedUser { get; set; }
        public AppointmentService appointmentService;
        public UserService userService;
        public RoomService roomService;

        public AppointmentsTableForm(Doctor loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.appointmentService = Globals.container.Resolve<AppointmentService>();
            this.userService = Globals.container.Resolve<UserService>();
            this.roomService = Globals.container.Resolve<RoomService>();
        }

        private void AppointmentsTableForm_Load(object sender, EventArgs e)
        {
            
            
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            AppointmentCreationForm appointmentCreationForm = new AppointmentCreationForm(loggedUser);
            appointmentCreationForm.Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentRow.Index;
            string selectedAppointmentId = (string)dataGridView1.Rows[rowindex].Cells[0].Value;
            if (dataGridView1.Rows[rowindex].Cells[0].Value != null)
            {
                Appointment appointmentForDelete = appointmentService.GetById(new MongoDB.Bson.ObjectId(selectedAppointmentId));
                appointmentService.Delete(appointmentForDelete);
                MessageBox.Show("Appointment deleted succesfully!");
            }
            else
            {
                messageLabel.Text = "Appointment is not selected!";
                messageLabel.Visible = true;

            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            List<Appointment> allAppointments = appointmentService.GetAll();

            foreach (Appointment appointment in allAppointments)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                User patient = userService.GetById(appointment.patientId);
                Room room = roomService.GetById(appointment.roomId.ToString());
                
                
               
                row.Cells[0].Value = appointment._id.ToString();

                row.Cells[1].Value = appointment.dateTime.ToString("dd/MM/yyyy");
                row.Cells[2].Value = appointment.dateTime.ToString("t");
                row.Cells[3].Value = appointment.type.ToString();
                row.Cells[4].Value = room.name;

                if (patient == null)
                {
                    row.Cells[5].Value = "Obrisan";
                    row.Cells[6].Value = "Obrisan";
                }
                else
                {
                    row.Cells[5].Value = patient.name;
                    row.Cells[6].Value = patient.lastName;
                }
                
                dataGridView1.Rows.Add(row);

            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

            
            int rowindex = dataGridView1.CurrentRow.Index;
            string selectedAppointmentId = (string)dataGridView1.Rows[rowindex].Cells[0].Value;
            if (dataGridView1.Rows[rowindex].Cells[0].Value != null)
            {
                Appointment apointment = appointmentService.GetById(new ObjectId(selectedAppointmentId));
                UpdateAppointment changdeAppointmentDateTimeForm = new UpdateAppointment(apointment);
                changdeAppointmentDateTimeForm.Show();
            }
            else
            {
                messageLabel.Text = "Appointment is not selected!";
                messageLabel.Visible = true;

            }
        }
    }
}
