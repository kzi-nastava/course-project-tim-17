namespace HealthcareSystem.UI.ManagerView
{
    partial class ShowEquipment
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
            this.equipmentListView = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.item = new System.Windows.Forms.ColumnHeader();
            this.itemType = new System.Windows.Forms.ColumnHeader();
            this.quantity = new System.Windows.Forms.ColumnHeader();
            this.isDynamic = new System.Windows.Forms.ColumnHeader();
            this.inRoom = new System.Windows.Forms.ColumnHeader();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.itemNameButton = new System.Windows.Forms.Button();
            this.itemTypeComboBox = new System.Windows.Forms.ComboBox();
            this.roomTypeComboBox = new System.Windows.Forms.ComboBox();
            this.itemTypeButton = new System.Windows.Forms.Button();
            this.roomTypeButton = new System.Windows.Forms.Button();
            this.quantityButton = new System.Windows.Forms.Button();
            this.quantityComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // equipmentListView
            // 
            this.equipmentListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.item,
            this.itemType,
            this.quantity,
            this.isDynamic,
            this.inRoom});
            this.equipmentListView.Location = new System.Drawing.Point(12, 12);
            this.equipmentListView.Name = "equipmentListView";
            this.equipmentListView.Size = new System.Drawing.Size(776, 362);
            this.equipmentListView.TabIndex = 0;
            this.equipmentListView.UseCompatibleStateImageBehavior = false;
            this.equipmentListView.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 200;
            // 
            // item
            // 
            this.item.Text = "Item";
            this.item.Width = 115;
            // 
            // itemType
            // 
            this.itemType.Text = "Item Type";
            this.itemType.Width = 115;
            // 
            // quantity
            // 
            this.quantity.Text = "Quantity";
            this.quantity.Width = 115;
            // 
            // isDynamic
            // 
            this.isDynamic.Text = "isDynamic";
            this.isDynamic.Width = 110;
            // 
            // inRoom
            // 
            this.inRoom.Text = "inRoom";
            this.inRoom.Width = 115;
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Location = new System.Drawing.Point(12, 391);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.PlaceholderText = "Enter item name";
            this.itemNameTextBox.Size = new System.Drawing.Size(111, 23);
            this.itemNameTextBox.TabIndex = 1;
            // 
            // itemNameButton
            // 
            this.itemNameButton.Location = new System.Drawing.Point(129, 391);
            this.itemNameButton.Name = "itemNameButton";
            this.itemNameButton.Size = new System.Drawing.Size(58, 23);
            this.itemNameButton.TabIndex = 2;
            this.itemNameButton.Text = "Search";
            this.itemNameButton.UseVisualStyleBackColor = true;
            this.itemNameButton.Click += new System.EventHandler(this.itemNameButton_Click);
            // 
            // itemTypeComboBox
            // 
            this.itemTypeComboBox.FormattingEnabled = true;
            this.itemTypeComboBox.Location = new System.Drawing.Point(206, 391);
            this.itemTypeComboBox.Name = "itemTypeComboBox";
            this.itemTypeComboBox.Size = new System.Drawing.Size(135, 23);
            this.itemTypeComboBox.TabIndex = 4;
            // 
            // roomTypeComboBox
            // 
            this.roomTypeComboBox.FormattingEnabled = true;
            this.roomTypeComboBox.Location = new System.Drawing.Point(430, 389);
            this.roomTypeComboBox.Name = "roomTypeComboBox";
            this.roomTypeComboBox.Size = new System.Drawing.Size(129, 23);
            this.roomTypeComboBox.TabIndex = 5;
            // 
            // itemTypeButton
            // 
            this.itemTypeButton.Location = new System.Drawing.Point(347, 388);
            this.itemTypeButton.Name = "itemTypeButton";
            this.itemTypeButton.Size = new System.Drawing.Size(66, 23);
            this.itemTypeButton.TabIndex = 3;
            this.itemTypeButton.Text = "Search";
            this.itemTypeButton.UseVisualStyleBackColor = true;
            this.itemTypeButton.Click += new System.EventHandler(this.itemTypeButton_Click);
            // 
            // roomTypeButton
            // 
            this.roomTypeButton.Location = new System.Drawing.Point(565, 390);
            this.roomTypeButton.Name = "roomTypeButton";
            this.roomTypeButton.Size = new System.Drawing.Size(67, 23);
            this.roomTypeButton.TabIndex = 6;
            this.roomTypeButton.Text = "Search";
            this.roomTypeButton.UseVisualStyleBackColor = true;
            this.roomTypeButton.Click += new System.EventHandler(this.roomTypeButton_Click);
            // 
            // quantityButton
            // 
            this.quantityButton.Location = new System.Drawing.Point(721, 390);
            this.quantityButton.Name = "quantityButton";
            this.quantityButton.Size = new System.Drawing.Size(67, 23);
            this.quantityButton.TabIndex = 7;
            this.quantityButton.Text = "Search";
            this.quantityButton.UseVisualStyleBackColor = true;
            this.quantityButton.Click += new System.EventHandler(this.quantityButton_Click);
            // 
            // quantityComboBox
            // 
            this.quantityComboBox.FormattingEnabled = true;
            this.quantityComboBox.Location = new System.Drawing.Point(651, 390);
            this.quantityComboBox.Name = "quantityComboBox";
            this.quantityComboBox.Size = new System.Drawing.Size(64, 23);
            this.quantityComboBox.TabIndex = 8;
            // 
            // ShowEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 431);
            this.Controls.Add(this.quantityComboBox);
            this.Controls.Add(this.quantityButton);
            this.Controls.Add(this.roomTypeComboBox);
            this.Controls.Add(this.itemTypeComboBox);
            this.Controls.Add(this.itemTypeButton);
            this.Controls.Add(this.itemNameTextBox);
            this.Controls.Add(this.equipmentListView);
            this.Controls.Add(this.itemNameButton);
            this.Controls.Add(this.roomTypeButton);
            this.Name = "ShowEquipment";
            this.Text = "ShowEquipment";
            this.Load += new System.EventHandler(this.showEquipment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView equipmentListView;
        private ColumnHeader id;
        private ColumnHeader item;
        private ColumnHeader itemType;
        private ColumnHeader quantity;
        private ColumnHeader isDynamic;
        private TextBox itemNameTextBox;
        private Button itemNameButton;
        private ComboBox itemTypeComboBox;
        private ComboBox roomTypeComboBox;
        private Button itemTypeButton;
        private Button roomTypeButton;
        private Button quantityButton;
        private ComboBox quantityComboBox;
        private ColumnHeader inRoom;
    }
}