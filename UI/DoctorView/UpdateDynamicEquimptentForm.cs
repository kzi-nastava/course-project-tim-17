using HealthcareSystem.Entity;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.RoomModel;
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
    partial class UpdateDynamicEquimptentForm : Form
    {

    public DoctorRepositories doctorRepositories { get; set; }
    public Apointment appointment { get; set; }
        public UpdateDynamicEquimptentForm(DoctorRepositories doctorRepositories, Apointment appointment)
        {
            this.doctorRepositories = doctorRepositories;
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
            doctorRepositories.roomController.UpdateRoom(room);
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
            return doctorRepositories.roomController.findById(appointment.roomId);
        }

        private void UpdateDynamicEquimptentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
