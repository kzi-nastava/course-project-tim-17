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

namespace HealthcareSystem.UI.DoctorView
{
    partial class ScheduleForm : Form
    {
        Doctor loggedUser { get; set; }
        DoctorRepositories doctorRepositories { get; set; }
        List<Apointment> apointments { get; set; }
        public ScheduleForm(Doctor loggedUser, DoctorRepositories doctorRepositories, List<Apointment> apointments)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.doctorRepositories = doctorRepositories;
            this.apointments = apointments;
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();

            foreach (Apointment appointment in apointments)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                User patient = doctorRepositories.userController.FindById(appointment.patientId);
                Room room = doctorRepositories.roomController.GetById(appointment.roomId);



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
                Apointment certainAppointent = doctorRepositories.apointmentController.FindById(new MongoDB.Bson.ObjectId(selectedAppointmentId));
                User patient = doctorRepositories.userController.FindById(certainAppointent.patientId);
                HealthCard patientsHealthCard = doctorRepositories.healthCardController.FindByPatientId(patient._id);
                CheckForm checkForm = new CheckForm(certainAppointent, patient, doctorRepositories, patientsHealthCard);
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
