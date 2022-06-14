using HealthcareSystem.Entity;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.MoveEquipmentFiles;
using HealthcareSystem.Entity.RoomModel.RenovationFiles;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
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

namespace HealthcareSystem.UI.ManagerView
{
    
    partial class MoveRequest : Form
    {
        public RoomService roomService;
        
        public MoveRequest()
        {
            InitializeComponent();
            roomService = new RoomService(new MoveEquipmentRepository(), new RoomRepository(), new RenovationRepository());
            loadComboBoxes();

        }
        public void loadComboBoxes() 
        { 
            List<Room> roomsFrom = roomService.GetAll();
            List<Room> roomsTo = roomService.GetAll();

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

            
            roomService.CreateMoveEquipmentRequest(date, roomFrom._id, roomTo._id, item);
            MessageBox.Show("Move Request Created!");
            this.Dispose();


        }

        private void MoveRequest_Load(object sender, EventArgs e)
        {

        }

        private void isDynamicCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        

        private void fromRoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Room room = fromRoomComboBox.SelectedValue as Room;
            itemComboBox.DataSource = room.equipments;
        }
    }
}
