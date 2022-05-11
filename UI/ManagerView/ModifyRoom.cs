using HealthcareSystem.Entity.Enumerations;
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

namespace HealthcareSystem.UI.ManagerView
{
    partial class ModifyRoom : Form
    {
        public ManagerControllers managerControllers { get; set; }
        public Room room;
        public ModifyRoom(ManagerControllers managerControllers,Room room)
        {
            InitializeComponent();
            this.managerControllers = managerControllers;
            this.room = room;
            loadRoomTypes();
        }

        void loadRoomTypes()
        {
            roomName.Text = room.name;
            List<Entity.Enumerations.RoomType> rooms = Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList();
            //roomTypeComboBox.ValueMember = null;
            roomTypeComboBox.DataSource = rooms;
            roomTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roomTypeComboBox.SelectedItem = room.type;
            roomTypeComboBox.SelectedText = room.type.ToString();
            

        }

        private void modifyRoom_Load(object sender, EventArgs e)
        {

        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            room.name = roomName.Text;
            Enum.TryParse(roomTypeComboBox.SelectedItem.ToString(), out RoomType roomType);
            room.type = roomType;
            RoomService rs = new RoomService(managerControllers.roomCollection);
            rs.UpdateRoom(room);
            MessageBox.Show("Room Updated!");
            this.Dispose();
        }
    }
}
