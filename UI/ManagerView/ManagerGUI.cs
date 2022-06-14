using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.MoveEquipmentFiles;
using HealthcareSystem.Entity.RoomModel.RenovationFiles;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
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
        public RoomService roomService { get; set; }

        public IMongoDatabase db;
        
        public ManagerGUI(User loggedUser,IMongoDatabase database)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            roomService = new RoomService(new MoveEquipmentRepository(),new RoomRepository(),new RenovationRepository());
            StartThreads();
            Console.WriteLine(DateTime.Now);
            this.db = database;
           

            
        }
        public void CheckForMoveEquipment() 
        {
            
            while (true)
            {
                roomService.CheckForRenovations();
                roomService.MoveEquipment();
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
            foreach (Room r in roomService.GetAll()) 
            { 
                ListViewItem item = new ListViewItem(r._id.ToString());
                item.SubItems.Add(r.name);
                item.SubItems.Add(r.type.ToString());
                roomListView.Items.Add(item);
                Console.WriteLine(r.InRenovation);
            }
            
        }

        
    

        private void addRoomButton_Click(object sender, EventArgs e)
        {
            AddRoom add = new AddRoom();
            add.Show();
        }

        private void deleteRoomButton_Click(object sender, EventArgs e)
        {

            roomService.Delete(roomListView.SelectedItems[0].Text);

        }

        private void modifyRoomButton_Click(object sender, EventArgs e)
        {
            
            Room room = roomService.GetById(roomListView.SelectedItems[0].Text);
            ModifyRoom add = new ModifyRoom(room);
            add.Show();
        }

        private void equipmentButton_Click(object sender, EventArgs e)
        {
            Room room;
            try
            {
                room = roomService.GetById(roomListView.SelectedItems[0].Text);
            }
            catch (Exception ex)
            {
                room = null;
            }
            ShowEquipment se = new ShowEquipment(room);
            se.Show();
        }

        private void moveRequestButton_Click(object sender, EventArgs e)
        {
            MoveRequest mr = new MoveRequest();
            mr.Show();
        }

        private void renovationButton_Click(object sender, EventArgs e)
        {
            Room room = roomService.GetById(roomListView.SelectedItems[0].Text);
            AddRenovation re = new AddRenovation(db,room);
            re.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void ManagerGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void roomListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addDrugButton_Click(object sender, EventArgs e)
        {
            AddDrug ad = new AddDrug(db);
            ad.Show();
        }

        private void revisionButton_Click(object sender, EventArgs e)
        {
            RevisionsForm rf = new RevisionsForm(db);
            rf.Show();

        }

        private void surveysButton_Click(object sender, EventArgs e)
        {
            SurveysForm sf = new SurveysForm(db);
            sf.Show();
        }
    }
}
