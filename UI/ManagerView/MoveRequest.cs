using HealthcareSystem.Entity;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.RoomModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthcareSystem.UI.ManagerView
{
    
    partial class MoveRequest : Form
    {
        public RoomController roomController;
        public MoveEquipmentRequestController moveEquipmentRequestController;
        public MoveRequest(RoomController rc, MoveEquipmentRequestController merc)
        {
            InitializeComponent();
            this.roomController = rc;
            this.moveEquipmentRequestController = merc;
            loadComboBoxes();

        }
        public void loadComboBoxes() 
        { 
            List<Room> roomsFrom = roomController.GetAllRooms();
            List<Room> roomsTo = roomController.GetAllRooms();

            fromRoomComboBox.DataSource = roomsFrom;
            toRoomComboBox.DataSource = roomsTo;

            List<EquipmentType> equipment = Enum.GetValues(typeof(EquipmentType)).Cast<EquipmentType>().ToList();

            Room room = fromRoomComboBox.SelectedValue as Room;
            itemComboBox.DataSource = room.equipments;




        }

        private void createMoveRequestButton_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value.Date;
            Room roomFrom = fromRoomComboBox.SelectedValue as Room;
            Room roomTo = toRoomComboBox.SelectedValue as Room;
            Equipment item = itemComboBox.SelectedValue as Equipment;
            item.quantity = int.Parse(quantityTextBox.Text);
              

            MoveEquipmentService mes = new MoveEquipmentService(moveEquipmentRequestController, roomController);
            mes.CreateMoveEquipmentRequest(date, roomFrom._id, roomTo._id, item);
            MessageBox.Show("Move Request Created!");
            this.Dispose();


        }

        private void MoveRequest_Load(object sender, EventArgs e)
        {

        }

        private void isDynamicCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveEquipmentService mes = new MoveEquipmentService(moveEquipmentRequestController, roomController);
            mes.MoveEquipment();
        }

        private void fromRoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Room room = fromRoomComboBox.SelectedValue as Room;
            itemComboBox.DataSource = room.equipments;
        }
    }
}
