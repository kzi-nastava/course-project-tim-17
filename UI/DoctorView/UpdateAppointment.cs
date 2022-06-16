using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.RoleControllers;
using MongoDB.Driver;
using Autofac;
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
    partial class UpdateAppointment : Form
    {

        public Appointment appointment { get; set; }
        public RoomService roomService;
        public UpdateAppointment(Appointment appointment)
        {
            InitializeComponent();
            this.appointment = appointment;
            this.roomService = Globals.container.Resolve<RoomService>();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            AppointmentService appointmentService = Globals.container.Resolve<AppointmentService>();
            DateTime newDateTime = GetDateTime();
            Room room = GetRoom();
            if (!appointmentService.DateTimeFree(newDateTime) && !appointmentService.RoomFree(room, newDateTime))
            {
                warningMessageLabel.Text = "Invalid Room or Date";
                warningMessageLabel.Visible = true;
            }
            else
            {
                appointment.dateTime = newDateTime;
                appointment.roomId = room._id;
                appointmentService.Update(appointment);
                MessageBox.Show("Appointment succesfully updated!");
                this.Dispose();
            }
        }

        
        private void UpdateAppointment_Load(object sender, EventArgs e)
        {

        }
        public DateTime GetDateTime()
        {
            DateTime dateTime = dateTimePicker.Value.Date;
            dateTime.AddHours(Int32.Parse(houTextBox.Text));
            dateTime.AddMinutes(Int32.Parse(minuteTextBox.Text));
            return dateTime;

        }
        private Room GetRoom()
        {
            RoomType roomType = RoomType.CHECKUP_ROOM;
            if(appointment.type == ApointmentType.OPERATION)
            {
                roomType = RoomType.OPERATION_ROOM;
            }
            Room room = roomService.GetByNameAndType(roomTextBox.Text, roomType);
            return room;
        }

    }
}
