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
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(17, 20);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(301, 31);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // fromRoomComboBox
            // 
            this.fromRoomComboBox.FormattingEnabled = true;
            this.fromRoomComboBox.Location = new System.Drawing.Point(17, 115);
            this.fromRoomComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fromRoomComboBox.Name = "fromRoomComboBox";
            this.fromRoomComboBox.Size = new System.Drawing.Size(304, 33);
            this.fromRoomComboBox.TabIndex = 2;
            this.fromRoomComboBox.SelectedIndexChanged += new System.EventHandler(this.fromRoomComboBox_SelectedIndexChanged);
            // 
            // toRoomComboBox
            // 
            this.toRoomComboBox.FormattingEnabled = true;
            this.toRoomComboBox.Location = new System.Drawing.Point(17, 207);
            this.toRoomComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toRoomComboBox.Name = "toRoomComboBox";
            this.toRoomComboBox.Size = new System.Drawing.Size(301, 33);
            this.toRoomComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 177);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // createMoveRequestButton
            // 
            this.createMoveRequestButton.Location = new System.Drawing.Point(119, 458);
            this.createMoveRequestButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.createMoveRequestButton.Name = "createMoveRequestButton";
            this.createMoveRequestButton.Size = new System.Drawing.Size(107, 52);
            this.createMoveRequestButton.TabIndex = 5;
            this.createMoveRequestButton.Text = "Create";
            this.createMoveRequestButton.UseVisualStyleBackColor = true;
            this.createMoveRequestButton.Click += new System.EventHandler(this.createMoveRequestButton_Click);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(111, 392);
            this.quantityTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(135, 31);
            this.quantityTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 270);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Item";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 362);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Quantity";
            // 
            // itemComboBox
            // 
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(17, 300);
            this.itemComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(301, 33);
            this.itemComboBox.TabIndex = 7;
            // 
            // MoveRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 533);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private ComboBox itemComboBox;
    }
}