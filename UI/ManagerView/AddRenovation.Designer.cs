namespace HealthcareSystem.UI.ManagerView
{
    partial class AddRenovation
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
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.mergeRoomCheckBox = new System.Windows.Forms.CheckBox();
            this.addRenovationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitRoomCheckBox = new System.Windows.Forms.CheckBox();
            this.secondRoomComboBox = new System.Windows.Forms.ComboBox();
            this.RoomLabel = new System.Windows.Forms.Label();
            this.mergedRoomNameLabel = new System.Windows.Forms.Label();
            this.mergedRoomNameTextBox = new System.Windows.Forms.TextBox();
            this.quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.firstRoomOption = new System.Windows.Forms.Button();
            this.secondRoomOption = new System.Windows.Forms.Button();
            this.equipmentLabel = new System.Windows.Forms.Label();
            this.firstSplitRoomName = new System.Windows.Forms.TextBox();
            this.secondSplitRoomName = new System.Windows.Forms.TextBox();
            this.splitSecondRoomNameLabel = new System.Windows.Forms.Label();
            this.splitFirstRoomNameLabel = new System.Windows.Forms.Label();
            this.inRoomLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(8, 20);
            this.startDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(222, 23);
            this.startDateTimePicker.TabIndex = 0;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(8, 69);
            this.endDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(222, 23);
            this.endDateTimePicker.TabIndex = 1;
            // 
            // mergeRoomCheckBox
            // 
            this.mergeRoomCheckBox.AutoSize = true;
            this.mergeRoomCheckBox.Location = new System.Drawing.Point(8, 97);
            this.mergeRoomCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.mergeRoomCheckBox.Name = "mergeRoomCheckBox";
            this.mergeRoomCheckBox.Size = new System.Drawing.Size(97, 19);
            this.mergeRoomCheckBox.TabIndex = 2;
            this.mergeRoomCheckBox.Text = "Merge rooms";
            this.mergeRoomCheckBox.UseVisualStyleBackColor = true;
            this.mergeRoomCheckBox.CheckedChanged += new System.EventHandler(this.mergeRoomCheckBox_CheckedChanged);
            // 
            // addRenovationButton
            // 
            this.addRenovationButton.Location = new System.Drawing.Point(75, 130);
            this.addRenovationButton.Margin = new System.Windows.Forms.Padding(2);
            this.addRenovationButton.Name = "addRenovationButton";
            this.addRenovationButton.Size = new System.Drawing.Size(84, 20);
            this.addRenovationButton.TabIndex = 3;
            this.addRenovationButton.Text = "Renovate";
            this.addRenovationButton.UseVisualStyleBackColor = true;
            this.addRenovationButton.Click += new System.EventHandler(this.addRenovationButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Date";
            // 
            // splitRoomCheckBox
            // 
            this.splitRoomCheckBox.AutoSize = true;
            this.splitRoomCheckBox.Location = new System.Drawing.Point(144, 97);
            this.splitRoomCheckBox.Name = "splitRoomCheckBox";
            this.splitRoomCheckBox.Size = new System.Drawing.Size(86, 19);
            this.splitRoomCheckBox.TabIndex = 6;
            this.splitRoomCheckBox.Text = "Split rooms";
            this.splitRoomCheckBox.UseVisualStyleBackColor = true;
            this.splitRoomCheckBox.CheckedChanged += new System.EventHandler(this.splitRoomCheckBox_CheckedChanged);
            // 
            // secondRoomComboBox
            // 
            this.secondRoomComboBox.FormattingEnabled = true;
            this.secondRoomComboBox.Location = new System.Drawing.Point(8, 183);
            this.secondRoomComboBox.Name = "secondRoomComboBox";
            this.secondRoomComboBox.Size = new System.Drawing.Size(218, 23);
            this.secondRoomComboBox.TabIndex = 8;
            this.secondRoomComboBox.Visible = false;
            // 
            // RoomLabel
            // 
            this.RoomLabel.AutoSize = true;
            this.RoomLabel.Location = new System.Drawing.Point(95, 165);
            this.RoomLabel.Name = "RoomLabel";
            this.RoomLabel.Size = new System.Drawing.Size(39, 15);
            this.RoomLabel.TabIndex = 10;
            this.RoomLabel.Text = "Room";
            this.RoomLabel.Visible = false;
            // 
            // mergedRoomNameLabel
            // 
            this.mergedRoomNameLabel.AutoSize = true;
            this.mergedRoomNameLabel.Location = new System.Drawing.Point(57, 209);
            this.mergedRoomNameLabel.Name = "mergedRoomNameLabel";
            this.mergedRoomNameLabel.Size = new System.Drawing.Size(118, 15);
            this.mergedRoomNameLabel.TabIndex = 11;
            this.mergedRoomNameLabel.Text = "Merged Room Name";
            this.mergedRoomNameLabel.Visible = false;
            // 
            // mergedRoomNameTextBox
            // 
            this.mergedRoomNameTextBox.Location = new System.Drawing.Point(8, 227);
            this.mergedRoomNameTextBox.Name = "mergedRoomNameTextBox";
            this.mergedRoomNameTextBox.Size = new System.Drawing.Size(218, 23);
            this.mergedRoomNameTextBox.TabIndex = 12;
            this.mergedRoomNameTextBox.Visible = false;
            this.mergedRoomNameTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.Location = new System.Drawing.Point(86, 276);
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(48, 23);
            this.quantityNumericUpDown.TabIndex = 13;
            this.quantityNumericUpDown.Visible = false;
            // 
            // firstRoomOption
            // 
            this.firstRoomOption.Location = new System.Drawing.Point(140, 276);
            this.firstRoomOption.Name = "firstRoomOption";
            this.firstRoomOption.Size = new System.Drawing.Size(40, 23);
            this.firstRoomOption.TabIndex = 14;
            this.firstRoomOption.Text = "1";
            this.firstRoomOption.UseVisualStyleBackColor = true;
            this.firstRoomOption.Visible = false;
            this.firstRoomOption.Click += new System.EventHandler(this.firstRoomOption_Click);
            // 
            // secondRoomOption
            // 
            this.secondRoomOption.Location = new System.Drawing.Point(186, 276);
            this.secondRoomOption.Name = "secondRoomOption";
            this.secondRoomOption.Size = new System.Drawing.Size(40, 23);
            this.secondRoomOption.TabIndex = 15;
            this.secondRoomOption.Text = "2";
            this.secondRoomOption.UseVisualStyleBackColor = true;
            this.secondRoomOption.Visible = false;
            this.secondRoomOption.Click += new System.EventHandler(this.secondRoomOption_Click);
            // 
            // equipmentLabel
            // 
            this.equipmentLabel.AutoSize = true;
            this.equipmentLabel.Location = new System.Drawing.Point(24, 280);
            this.equipmentLabel.Name = "equipmentLabel";
            this.equipmentLabel.Size = new System.Drawing.Size(31, 15);
            this.equipmentLabel.TabIndex = 16;
            this.equipmentLabel.Text = "item";
            this.equipmentLabel.Visible = false;
            // 
            // firstSplitRoomName
            // 
            this.firstSplitRoomName.Location = new System.Drawing.Point(12, 183);
            this.firstSplitRoomName.Name = "firstSplitRoomName";
            this.firstSplitRoomName.Size = new System.Drawing.Size(214, 23);
            this.firstSplitRoomName.TabIndex = 17;
            this.firstSplitRoomName.Visible = false;
            // 
            // secondSplitRoomName
            // 
            this.secondSplitRoomName.Location = new System.Drawing.Point(12, 227);
            this.secondSplitRoomName.Name = "secondSplitRoomName";
            this.secondSplitRoomName.Size = new System.Drawing.Size(214, 23);
            this.secondSplitRoomName.TabIndex = 18;
            this.secondSplitRoomName.Visible = false;
            // 
            // splitSecondRoomNameLabel
            // 
            this.splitSecondRoomNameLabel.AutoSize = true;
            this.splitSecondRoomNameLabel.Location = new System.Drawing.Point(57, 209);
            this.splitSecondRoomNameLabel.Name = "splitSecondRoomNameLabel";
            this.splitSecondRoomNameLabel.Size = new System.Drawing.Size(136, 15);
            this.splitSecondRoomNameLabel.TabIndex = 19;
            this.splitSecondRoomNameLabel.Text = "Second new room name";
            this.splitSecondRoomNameLabel.Visible = false;
            // 
            // splitFirstRoomNameLabel
            // 
            this.splitFirstRoomNameLabel.AutoSize = true;
            this.splitFirstRoomNameLabel.Location = new System.Drawing.Point(61, 165);
            this.splitFirstRoomNameLabel.Name = "splitFirstRoomNameLabel";
            this.splitFirstRoomNameLabel.Size = new System.Drawing.Size(119, 15);
            this.splitFirstRoomNameLabel.TabIndex = 20;
            this.splitFirstRoomNameLabel.Text = "First new room name";
            this.splitFirstRoomNameLabel.Visible = false;
            // 
            // inRoomLabel
            // 
            this.inRoomLabel.AutoSize = true;
            this.inRoomLabel.Location = new System.Drawing.Point(144, 258);
            this.inRoomLabel.Name = "inRoomLabel";
            this.inRoomLabel.Size = new System.Drawing.Size(77, 15);
            this.inRoomLabel.TabIndex = 21;
            this.inRoomLabel.Text = "In new Room";
            this.inRoomLabel.Visible = false;
            // 
            // AddRenovation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 164);
            this.Controls.Add(this.inRoomLabel);
            this.Controls.Add(this.splitFirstRoomNameLabel);
            this.Controls.Add(this.splitSecondRoomNameLabel);
            this.Controls.Add(this.secondSplitRoomName);
            this.Controls.Add(this.firstSplitRoomName);
            this.Controls.Add(this.equipmentLabel);
            this.Controls.Add(this.secondRoomOption);
            this.Controls.Add(this.firstRoomOption);
            this.Controls.Add(this.quantityNumericUpDown);
            this.Controls.Add(this.mergedRoomNameTextBox);
            this.Controls.Add(this.mergedRoomNameLabel);
            this.Controls.Add(this.RoomLabel);
            this.Controls.Add(this.secondRoomComboBox);
            this.Controls.Add(this.splitRoomCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addRenovationButton);
            this.Controls.Add(this.mergeRoomCheckBox);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddRenovation";
            this.Text = "AddRenovation";
            this.Load += new System.EventHandler(this.AddRenovation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker startDateTimePicker;
        private DateTimePicker endDateTimePicker;
        private CheckBox mergeRoomCheckBox;
        private Button addRenovationButton;
        private Label label1;
        private Label label2;
        private CheckBox splitRoomCheckBox;
        private ComboBox secondRoomComboBox;
        private Label RoomLabel;
        private Label mergedRoomNameLabel;
        private TextBox mergedRoomNameTextBox;
        private NumericUpDown quantityNumericUpDown;
        private Button firstRoomOption;
        private Button secondRoomOption;
        private Label equipmentLabel;
        private TextBox firstSplitRoomName;
        private TextBox secondSplitRoomName;
        private Label splitSecondRoomNameLabel;
        private Label splitFirstRoomNameLabel;
        private Label inRoomLabel;
    }
}