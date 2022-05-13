using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Bson;
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
    partial class ManagerGUI : Form
    {
        public User loggedUser { get; set; }
        public ManagerControllers managerControllers { get; set; }
        public IMongoDatabase database;
        public ManagerGUI(User loggedUser, IMongoDatabase database)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.managerControllers = new ManagerControllers(database);
            this.database = database;
            StartThreads();
            Console.WriteLine(DateTime.Now);
           

            
        }
        public void CheckForMoveEquipment() 
        {
            RoomService rs = new RoomService(database);
            while (true)
            {
                rs.CheckForRenovations();
                rs.MoveEquipment();
                Console.WriteLine("Checked");
                Thread.Sleep(30000);
            }

        }

        public void StartThreads() 
        {
            Thread thread = new Thread(CheckForMoveEquipment);
            thread.IsBackground = true;
            thread.Start();


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
            AddRoom add = new AddRoom(database);
            add.Show();
        }

        private void deleteRoomButton_Click(object sender, EventArgs e)
        {
            RoomService rs = new RoomService(database);
            rs.DeleteRoom(roomListView.SelectedItems[0].Text);

        }

        private void modifyRoomButton_Click(object sender, EventArgs e)
        {
            
            Room room = managerControllers.roomCollection.findById(new ObjectId(roomListView.SelectedItems[0].Text));
            ModifyRoom add = new ModifyRoom(database,room);
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
            ShowEquipment se = new ShowEquipment(database, room);
            se.Show();
        }

        private void moveRequestButton_Click(object sender, EventArgs e)
        {
            MoveRequest mr = new MoveRequest(database);
            mr.Show();
        }

        private void renovationButton_Click(object sender, EventArgs e)
        {
            Room room = managerControllers.roomCollection.findById(new ObjectId(roomListView.SelectedItems[0].Text));
            AddRenovation re = new AddRenovation(database,room);
            re.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RoomService rs = new RoomService(database);
        }

        private void ManagerGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
