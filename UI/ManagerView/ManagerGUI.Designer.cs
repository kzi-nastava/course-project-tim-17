namespace HealthcareSystem.UI.ManagerView
{
    partial class ManagerGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.loadRoomsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roomListView = new System.Windows.Forms.ListView();
            this.idColum = new System.Windows.Forms.ColumnHeader();
            this.nameColum = new System.Windows.Forms.ColumnHeader();
            this.roomTypeColum = new System.Windows.Forms.ColumnHeader();
            this.addRoomButton = new System.Windows.Forms.Button();
            this.deleteRoomButton = new System.Windows.Forms.Button();
            this.modifyRoomButton = new System.Windows.Forms.Button();
            this.equipmentButton = new System.Windows.Forms.Button();
            this.moveRequestButton = new System.Windows.Forms.Button();
            this.renovationButton = new System.Windows.Forms.Button();
            this.addDrugButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadRoomsButton
            // 
            this.loadRoomsButton.Location = new System.Drawing.Point(12, 12);
            this.loadRoomsButton.Name = "loadRoomsButton";
            this.loadRoomsButton.Size = new System.Drawing.Size(93, 23);
            this.loadRoomsButton.TabIndex = 0;
            this.loadRoomsButton.Text = "Load rooms";
            this.loadRoomsButton.UseVisualStyleBackColor = true;
            this.loadRoomsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.roomListView);
            this.panel1.Location = new System.Drawing.Point(111, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 338);
            this.panel1.TabIndex = 4;
            // 
            // roomListView
            // 
            this.roomListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColum,
            this.nameColum,
            this.roomTypeColum});
            this.roomListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.roomListView.Location = new System.Drawing.Point(0, 0);
            this.roomListView.Name = "roomListView";
            this.roomListView.Size = new System.Drawing.Size(606, 335);
            this.roomListView.TabIndex = 0;
            this.roomListView.UseCompatibleStateImageBehavior = false;
            this.roomListView.View = System.Windows.Forms.View.Details;
            this.roomListView.SelectedIndexChanged += new System.EventHandler(this.roomListView_SelectedIndexChanged);
            // 
            // idColum
            // 
            this.idColum.Text = "ID";
            this.idColum.Width = 200;
            // 
            // nameColum
            // 
            this.nameColum.Text = "Name";
            this.nameColum.Width = 200;
            // 
            // roomTypeColum
            // 
            this.roomTypeColum.Text = "RoomType";
            this.roomTypeColum.Width = 200;
            // 
            // addRoomButton
            // 
            this.addRoomButton.Location = new System.Drawing.Point(12, 41);
            this.addRoomButton.Name = "addRoomButton";
            this.addRoomButton.Size = new System.Drawing.Size(93, 23);
            this.addRoomButton.TabIndex = 5;
            this.addRoomButton.Text = "Add room";
            this.addRoomButton.UseVisualStyleBackColor = true;
            this.addRoomButton.Click += new System.EventHandler(this.addRoomButton_Click);
            // 
            // deleteRoomButton
            // 
            this.deleteRoomButton.Location = new System.Drawing.Point(12, 70);
            this.deleteRoomButton.Name = "deleteRoomButton";
            this.deleteRoomButton.Size = new System.Drawing.Size(93, 23);
            this.deleteRoomButton.TabIndex = 6;
            this.deleteRoomButton.Text = "Delete room";
            this.deleteRoomButton.UseVisualStyleBackColor = true;
            this.deleteRoomButton.Click += new System.EventHandler(this.deleteRoomButton_Click);
            // 
            // modifyRoomButton
            // 
            this.modifyRoomButton.Location = new System.Drawing.Point(12, 99);
            this.modifyRoomButton.Name = "modifyRoomButton";
            this.modifyRoomButton.Size = new System.Drawing.Size(93, 23);
            this.modifyRoomButton.TabIndex = 7;
            this.modifyRoomButton.Text = "Modify";
            this.modifyRoomButton.UseVisualStyleBackColor = true;
            this.modifyRoomButton.Click += new System.EventHandler(this.modifyRoomButton_Click);
            // 
            // equipmentButton
            // 
            this.equipmentButton.Location = new System.Drawing.Point(12, 128);
            this.equipmentButton.Name = "equipmentButton";
            this.equipmentButton.Size = new System.Drawing.Size(93, 23);
            this.equipmentButton.TabIndex = 8;
            this.equipmentButton.Text = "Equipment";
            this.equipmentButton.UseVisualStyleBackColor = true;
            this.equipmentButton.Click += new System.EventHandler(this.equipmentButton_Click);
            // 
            // moveRequestButton
            // 
            this.moveRequestButton.Location = new System.Drawing.Point(12, 293);
            this.moveRequestButton.Name = "moveRequestButton";
            this.moveRequestButton.Size = new System.Drawing.Size(75, 57);
            this.moveRequestButton.TabIndex = 9;
            this.moveRequestButton.Text = "Create move request";
            this.moveRequestButton.UseVisualStyleBackColor = true;
            this.moveRequestButton.Click += new System.EventHandler(this.moveRequestButton_Click);
            // 
            // renovationButton
            // 
            this.renovationButton.Location = new System.Drawing.Point(12, 156);
            this.renovationButton.Margin = new System.Windows.Forms.Padding(2);
            this.renovationButton.Name = "renovationButton";
            this.renovationButton.Size = new System.Drawing.Size(93, 24);
            this.renovationButton.TabIndex = 10;
            this.renovationButton.Text = "Renovate";
            this.renovationButton.UseVisualStyleBackColor = true;
            this.renovationButton.Click += new System.EventHandler(this.renovationButton_Click);
            // 
            // addDrugButton
            // 
            this.addDrugButton.Location = new System.Drawing.Point(12, 185);
            this.addDrugButton.Name = "addDrugButton";
            this.addDrugButton.Size = new System.Drawing.Size(93, 23);
            this.addDrugButton.TabIndex = 11;
            this.addDrugButton.Text = "Add Drug";
            this.addDrugButton.UseVisualStyleBackColor = true;
            this.addDrugButton.Click += new System.EventHandler(this.addDrugButton_Click);
            // 
            // ManagerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 362);
            this.Controls.Add(this.addDrugButton);
            this.Controls.Add(this.renovationButton);
            this.Controls.Add(this.moveRequestButton);
            this.Controls.Add(this.equipmentButton);
            this.Controls.Add(this.modifyRoomButton);
            this.Controls.Add(this.deleteRoomButton);
            this.Controls.Add(this.addRoomButton);
            this.Controls.Add(this.loadRoomsButton);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManagerGUI";
            this.Text = "ManagerGUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagerGUI_FormClosed);
            this.Load += new System.EventHandler(this.ManagerGUI_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }




        #endregion

        private Button loadRoomsButton;
        private Panel panel1;
        private Button addRoomButton;
        private Button deleteRoomButton;
        private Button modifyRoomButton;
        private Button equipmentButton;
        private Button moveRequestButton;
        private Button renovationButton;
        private Button asd;
        private ListView roomListView;
        private ColumnHeader idColum;
        private ColumnHeader nameColum;
        private ColumnHeader roomTypeColum;
        private Button addDrugButton;
    }
}