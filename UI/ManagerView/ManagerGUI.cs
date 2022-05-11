using HealthcareSystem.Entity.RoomModel;
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

namespace HealthcareSystem.UI.ManagerView

{
    partial class ManagerGUI : Form
    {
        public User loggedUser { get; set; }
        public ManagerControllers managerControllers { get; set; }
        public ManagerGUI(User loggedUser, ManagerControllers managerControllers)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.managerControllers = managerControllers;
           

            
        }

        private void ManagerGUI_Load(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)


        {
            roomListView.Items.Clear();    
            foreach (Room r in managerControllers.roomCollection.GetAllRooms()) { 
                ListViewItem item = new ListViewItem(r._id.ToString());
                item.SubItems.Add(r.name);
                item.SubItems.Add(r.type.ToString());
                roomListView.Items.Add(item);
                Console.WriteLine(r.InRenovation);
                
            
            }
            
        }

        
    

        private void addRoomButton_Click(object sender, EventArgs e)
        {
            AddRoom add = new AddRoom(managerControllers);
            add.Show();
        }

        private void deleteRoomButton_Click(object sender, EventArgs e)
        {
            RoomService rs = new RoomService(managerControllers.roomCollection);
            rs.DeleteRoom(roomListView.SelectedItems[0].Text);

        }

        private void modifyRoomButton_Click(object sender, EventArgs e)
        {
            
            Room room = managerControllers.roomCollection.findById(new ObjectId(roomListView.SelectedItems[0].Text));
            ModifyRoom add = new ModifyRoom(managerControllers,room);
            add.Show();
        }

        private void equipmentButton_Click(object sender, EventArgs e)
        {
            Room room;
            try
            {
                room = managerControllers.roomCollection.findById(new ObjectId(roomListView.SelectedItems[0].Text));
            }
            catch (Exception ex)
            {
                room = null;
            }
            ShowEquipment se = new ShowEquipment(managerControllers, room);
            se.Show();
        }

        private void moveRequestButton_Click(object sender, EventArgs e)
        {
            MoveRequest mr = new MoveRequest(managerControllers.roomCollection,managerControllers.moveCollection);
            mr.Show();
        }
    }
}
