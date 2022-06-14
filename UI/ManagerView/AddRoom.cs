using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.MoveEquipmentFiles;
using HealthcareSystem.Entity.RoomModel.RenovationFiles;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.RoleControllers;
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
    partial class AddRoom : Form
    {
        public RoomService roomService;
        

        public AddRoom()
        {
            InitializeComponent();
            roomService = new RoomService(new MoveEquipmentRepository(), new RoomRepository(), new RenovationRepository());
            loadRoomTypes();
        }

        void loadRoomTypes() 
        {
            List<RoomType> rooms = Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList();
            roomTypeComboBox.ValueMember = null;
            roomTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roomTypeComboBox.DisplayMember = "Room Type";
            roomTypeComboBox.DataSource = rooms;

        }

        private void AddRoom_Load(object sender, EventArgs e)
        {

        }

        private void addRoomButton_Click(object sender, EventArgs e)
        {
            string roomName = roomNameBox.Text;
            
            Enum.TryParse(roomTypeComboBox.SelectedItem.ToString(), out RoomType roomType);
            Console.WriteLine(roomType);
            
            roomService.Add(roomName, roomType);
            MessageBox.Show("Room added!");
            this.Dispose();
        }

        
    }
}
