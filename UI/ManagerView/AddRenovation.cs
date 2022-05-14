using HealthcareSystem.Entity;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Driver;


namespace HealthcareSystem.UI.ManagerView
{
    partial class AddRenovation : Form
    {

        public ManagerControllers managerControllers;
        public Room room;
        public ApointmentController apointmentController;
        public IMongoDatabase database;
        public bool sizeChanged;
        Equipment currentItem = null;
        int iter  = 0;
        List<Equipment> firstRoomEquipment = new List<Equipment>();
        List<Equipment> secondRoomEquipment = new List<Equipment>();


        public AddRenovation(IMongoDatabase database,Room room)
        {
            InitializeComponent();
            managerControllers = new ManagerControllers(database);
            this.room = room;
            this.apointmentController = new ApointmentController(database);
            this.database = database;
            sizeChanged = false;
            
        }

        private void addRenovationButton_Click(object sender, EventArgs e)
        {
            DateTime dateStart = startDateTimePicker.Value.Date;
            DateTime dateEnd = endDateTimePicker.Value.Date;
            if (dateStart < dateEnd) 
            {
                AppointmentService aps = new AppointmentService(new DoctorRepositories(database));
                if (aps.CheckIfRoomIsAvaliableForRenovation(room._id, dateStart, dateEnd)) 
                {
                    Renovation r = new Renovation(room._id, dateStart, dateEnd);
                    if (!mergeRoomCheckBox.Checked && !splitRoomCheckBox.Checked)
                    {
                        r.RenovationType = 0;
                        managerControllers.renovationCollection.InsertToCollection(r);

                    }
                    else if (mergeRoomCheckBox.Checked)
                    {
                        Room secondRoom = secondRoomComboBox.SelectedValue as Room;
                        MergeRoomRenovation mr = new MergeRoomRenovation(mergedRoomNameTextBox.Text, r._id, room._id, secondRoom._id);
                        r.RenovationType = 1;
                        managerControllers.renovationCollection.InsertToCollectionMergeRenovation(r, mr);
                        secondRoom.InRenovation = true;
                        managerControllers.roomCollection.UpdateRoom(secondRoom);

                    }
                    else if (splitRoomCheckBox.Checked)
                    {
                        SplitRoomRenovation sr = new SplitRoomRenovation(room._id,r._id,firstSplitRoomName.Text, secondSplitRoomName.Text, firstRoomEquipment, secondRoomEquipment);
                        r.RenovationType = 2;
                        managerControllers.renovationCollection.InsertToCollectionSplitRenovation(r, sr);
                    }
                    
                    room.InRenovation = true;
                    managerControllers.roomCollection.UpdateRoom(room);
                    this.Dispose();
                }
            
            }

        }

        private void AddRenovation_Load(object sender, EventArgs e)
        {

        }

        public void ChangeFrameSize(int move) 
        {
            this.Size = new Size(this.Width, this.Height + move);
            addRenovationButton.Location = new Point(addRenovationButton.Location.X, addRenovationButton.Location.Y + move);
            
        }

        public void ChangeFrameToMergeRenovation(bool visibility) 
        {
            secondRoomComboBox.Visible = visibility;
            mergedRoomNameLabel.Visible = visibility;
            RoomLabel.Visible = visibility;
            mergedRoomNameTextBox.Visible = visibility;
            

            if (visibility) 
            {
                loadMergeRoomComboBoxes();
            
            }
        }
        public void loadMergeRoomComboBoxes() 
        { 
            List<Room> Rooms = managerControllers.roomCollection.GetAllRooms();
            secondRoomComboBox.DataSource = Rooms;
            


        }
        

        private void mergeRoomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mergeRoomCheckBox.Checked == true && sizeChanged == false)
            {
                splitRoomCheckBox.Checked = false;
                ChangeFrameSize(250);
                ChangeFrameToMergeRenovation(true);
                sizeChanged = true;



            }
            else if (mergeRoomCheckBox.Checked == false)
            {
                ChangeFrameSize(-250);
                ChangeFrameToMergeRenovation(false);
                
            }
            sizeChanged = false;

        }

        public void ChangeFrameToSplitRenovation(bool visibility)
        {
            firstSplitRoomName.Visible = visibility;
            secondSplitRoomName.Visible = visibility;
            quantityNumericUpDown.Visible = visibility;
            firstRoomOption.Visible = visibility;
            secondRoomOption.Visible = visibility;
            equipmentLabel.Visible = visibility;
            inRoomLabel.Visible = visibility;
            splitFirstRoomNameLabel.Visible = visibility;
            splitSecondRoomNameLabel.Visible = visibility;
            addRenovationButton.Enabled = !visibility;

            if (visibility)
            InitEquipmentSplit();
        }

        public void InitEquipmentSplit() {

            try
            {
                currentItem = room.equipments[iter];
                equipmentLabel.Text = currentItem.item;
                quantityNumericUpDown.Maximum = currentItem.quantity;
                quantityNumericUpDown.Minimum = 0;
                quantityNumericUpDown.Value = currentItem.quantity;
            }
            catch (Exception) 
            {
                firstRoomOption.Enabled = false;
                secondRoomOption.Enabled = false;
                addRenovationButton.Enabled = true;

            }
        }

        private void splitRoomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (splitRoomCheckBox.Checked && sizeChanged == false)
            {
                mergeRoomCheckBox.Checked = false;
                ChangeFrameSize(300);
                ChangeFrameToSplitRenovation(true);
                sizeChanged = true;
                
            }
            if (splitRoomCheckBox.Checked == false)
            {
                ChangeFrameSize(-300);
                ChangeFrameToSplitRenovation(false);

            }
            sizeChanged = false;



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstRoomOption_Click(object sender, EventArgs e)
        {
            iter++;
            if (quantityNumericUpDown.Value != currentItem.quantity)
            {
                Equipment itemOne = new Equipment(currentItem.type, currentItem.item, ((int)quantityNumericUpDown.Value), currentItem.isDynamic);
                Equipment itemTwo = new Equipment(currentItem.type, currentItem.item, currentItem.quantity - ((int)quantityNumericUpDown.Value), currentItem.isDynamic);
                firstRoomEquipment.Add(itemOne);
                secondRoomEquipment.Add(itemTwo);
            }
            else 
            {
                firstRoomEquipment.Add(currentItem);
            }
            InitEquipmentSplit();
        }

        private void secondRoomOption_Click(object sender, EventArgs e)
        {
            iter++;
            if (quantityNumericUpDown.Value != currentItem.quantity)
            {
                Equipment itemOne = new Equipment(currentItem.type, currentItem.item, ((int)quantityNumericUpDown.Value), currentItem.isDynamic);
                Equipment itemTwo = new Equipment(currentItem.type, currentItem.item, currentItem.quantity - ((int)quantityNumericUpDown.Value), currentItem.isDynamic);
                secondRoomEquipment.Add(itemOne);
                firstRoomEquipment.Add(itemTwo);
            }
            else
            {
                secondRoomEquipment.Add(currentItem);
            }
            InitEquipmentSplit();

        }
    }
}
