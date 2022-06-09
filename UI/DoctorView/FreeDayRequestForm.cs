using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DoctorModel;
using MongoDB.Driver;
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
    partial class FreeDayRequestForm : Form
    {
        public Doctor doctor;
        public FreeDayRequestController freeDayRequestRepository;
        public IMongoDatabase database;
        public FreeDayRequestForm(IMongoDatabase database, Doctor doctor)
        {
            this.doctor = doctor;
            this.freeDayRequestRepository = new FreeDayRequestController(database);
            this.database = database;
            InitializeComponent();
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {

            DateTime dateFrom = fromDatePicker.Value;
            string description = DescriptionTextBox.Text;
            DateTime dateTo = new DateTime();
            if (UrgentCheckBox.Checked)
            {
                dateTo = dateFrom.AddDays(5);
                if (IsScheduleFree(dateFrom, dateTo))
                {
                    FreeDayRequest freeDayRequest = new FreeDayRequest(dateFrom, dateTo, doctor._id, description);
                    freeDayRequest.status = Entity.Enumerations.Status.ACCEPTED;
                    freeDayRequestRepository.InsertToCollection(freeDayRequest);
                    MessageBox.Show("Request created succesfully");
                    this.Dispose();
                }
                else
                {
                    warningMessageLabel.Text = "Scedule is not free!";
                    warningMessageLabel.Visible = true;
                }
                
            }
            else
            {
                dateTo = ToTimePicker.Value;
                if (IsScheduleFree(dateFrom, dateTo))
                {
                    FreeDayRequest freeDayRequest = new FreeDayRequest(dateFrom, dateTo, doctor._id, description);
                    freeDayRequestRepository.InsertToCollection(freeDayRequest);
                    MessageBox.Show("Request created succesfully");
                    this.Dispose();
                }
                else
                {
                    warningMessageLabel.Text = "Scedule is not free!";
                    warningMessageLabel.Visible = true;
                }
            }

        }

        private void UrgentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UrgentCheckBox.Checked)
            {
                ToTimePicker.Enabled = false;
            }
            else
            {
                ToTimePicker.Enabled = true;
            }
        }

        private void FreeDayRequestForm_Load(object sender, EventArgs e)
        {

        }

        private void FromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if(fromDatePicker.Value < DateTime.Now.AddDays(2))
            {
                invalidDateLabel.Text = "Request must be created minimum 2 days before!";
                invalidDateLabel.Visible = true;
            }
            else
            {
                invalidDateLabel.Visible = false;
            }
        }
        private bool IsScheduleFree(DateTime from, DateTime to)
        {
            ApointmentController apointmentController = new ApointmentController(database);
            List<Apointment> apointments = new List<Apointment>();
            apointments = apointmentController.apointmentCollection.Find(item => item.dateTime >= from & item.dateTime <= to).ToList();
            if (apointments.Count == 0)
            {
                return true;
            }
            
            return false;
        }
    }
}
