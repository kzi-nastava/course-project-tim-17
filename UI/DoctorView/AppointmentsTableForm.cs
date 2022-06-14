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

namespace HealthcareSystem.UI.DoctorView
{
    partial class AppointmentsTableForm : Form
    {
        public Doctor loggedUser { get; set; }
        public DoctorRepositories doctorRepositories { get; set; }

        public AppointmentsTableForm(Doctor loggedUser, DoctorRepositories doctorRepositories)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.doctorRepositories = doctorRepositories;
        }

        private void AppointmentsTableForm_Load(object sender, EventArgs e)
        {
            
            
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            AppointmentCreationForm appointmentCreationForm = new AppointmentCreationForm(loggedUser, doctorRepositories);
            appointmentCreationForm.Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentRow.Index;
            string selectedAppointmentId = (string)dataGridView1.Rows[rowindex].Cells[0].Value;
            if (dataGridView1.Rows[rowindex].Cells[0].Value != null)
            {
                Apointment appointmentForDelete = doctorRepositories.apointmentController.FindById(new MongoDB.Bson.ObjectId(selectedAppointmentId));
                doctorRepositories.apointmentController.DeleteApointment(appointmentForDelete);
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
            List<Apointment> allAppointments = doctorRepositories.apointmentController.getAllAppointments();

            foreach (Apointment appointment in allAppointments)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                User patient = doctorRepositories.userController.FindById(appointment.patientId);
                Room room = doctorRepositories.roomController.GetById(appointment.roomId);
                
                
               
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
                Apointment apointment = doctorRepositories.apointmentController.FindById(new ObjectId(selectedAppointmentId));
                UpdateAppointment changdeAppointmentDateTimeForm = new UpdateAppointment(doctorRepositories, apointment);
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
