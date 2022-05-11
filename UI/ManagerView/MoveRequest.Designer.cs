namespace HealthcareSystem.UI.ManagerView
{
    partial class MoveRequest
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.fromRoomComboBox = new System.Windows.Forms.ComboBox();
            this.toRoomComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.createMoveRequestButton = new System.Windows.Forms.Button();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(212, 23);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // fromRoomComboBox
            // 
            this.fromRoomComboBox.FormattingEnabled = true;
            this.fromRoomComboBox.Location = new System.Drawing.Point(12, 69);
            this.fromRoomComboBox.Name = "fromRoomComboBox";
            this.fromRoomComboBox.Size = new System.Drawing.Size(214, 23);
            this.fromRoomComboBox.TabIndex = 2;
            this.fromRoomComboBox.SelectedIndexChanged += new System.EventHandler(this.fromRoomComboBox_SelectedIndexChanged);
            // 
            // toRoomComboBox
            // 
            this.toRoomComboBox.FormattingEnabled = true;
            this.toRoomComboBox.Location = new System.Drawing.Point(12, 124);
            this.toRoomComboBox.Name = "toRoomComboBox";
            this.toRoomComboBox.Size = new System.Drawing.Size(212, 23);
            this.toRoomComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // createMoveRequestButton
            // 
            this.createMoveRequestButton.Location = new System.Drawing.Point(12, 274);
            this.createMoveRequestButton.Name = "createMoveRequestButton";
            this.createMoveRequestButton.Size = new System.Drawing.Size(75, 31);
            this.createMoveRequestButton.TabIndex = 5;
            this.createMoveRequestButton.Text = "Create";
            this.createMoveRequestButton.UseVisualStyleBackColor = true;
            this.createMoveRequestButton.Click += new System.EventHandler(this.createMoveRequestButton_Click);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(78, 235);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(96, 23);
            this.quantityTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Item";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Quantity";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // itemComboBox
            // 
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(12, 180);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(212, 23);
            this.itemComboBox.TabIndex = 7;
            // 
            // MoveRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 320);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.itemComboBox);
            this.Controls.Add(this.createMoveRequestButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toRoomComboBox);
            this.Controls.Add(this.fromRoomComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "MoveRequest";
            this.Text = "MoveRequest";
            this.Load += new System.EventHandler(this.MoveRequest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label label1;
        private ComboBox fromRoomComboBox;
        private ComboBox toRoomComboBox;
        private Label label2;
        private Button createMoveRequestButton;
        private TextBox quantityTextBox;
        private Label label3;
        private Label label5;
        private Button button1;
        private ComboBox itemComboBox;
    }
}