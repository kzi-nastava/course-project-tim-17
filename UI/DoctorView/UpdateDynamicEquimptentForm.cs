using HealthcareSystem.Entity;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.MoveEquipmentFiles;
using HealthcareSystem.Entity.RoomModel.RenovationFiles;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
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
    partial class UpdateDynamicEquimptentForm : Form
    {
        public RoomService roomService;
        public Appointment appointment { get; set; }
        public UpdateDynamicEquimptentForm( Appointment appointment)
        {
            this.roomService = Globals.container.Resolve<RoomService>();
            this.appointment = appointment;
            InitializeComponent();
        }

        private void quantityLabel_Click(object sender, EventArgs e)
        {

        }



        private void finishBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sucessfuly updated!");
            this.Dispose();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            Room room = GetRoomFromAppointment();
            foreach(Equipment equipment in room.equipments)
            {
                if(equipment.item == equipmentNameTextBox.Text)
                {
                    equipment.quantity -= Int32.Parse(quantityTextBox.Text);
                }
            }
            roomService.Update(room);
            MessageBox.Show("Selected equipment updated!");


        }

        private void loadEquipmentBtn_Click(object sender, EventArgs e)
        {
            Room room = GetRoomFromAppointment();
            List<Equipment> dynamicEquipment = GetDynamicEquipmentFromRoom(room);
            this.dataGridView1.Rows.Clear();

            foreach (Equipment equipment in dynamicEquipment)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                
                row.Cells[0].Value = equipment.item;
                row.Cells[1].Value = equipment.quantity.ToString();
                dataGridView1.Rows.Add(row);

            }
        }

        private List<Equipment> GetDynamicEquipmentFromRoom(Room room)
        {   List<Equipment> dynamicEquipment = new List<Equipment>();
            foreach(Equipment equipment in room.equipments){
                if (equipment.isDynamic)
                {
                    dynamicEquipment.Add(equipment);
                }
            }
            return dynamicEquipment;
        }

        private Room GetRoomFromAppointment()
        {
            return roomService.GetById(appointment.roomId.ToString());
        }

        private void UpdateDynamicEquimptentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
