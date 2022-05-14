namespace HealthcareSystem.UI.DoctorView
{
    partial class UpdateAppointment
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.hour = new System.Windows.Forms.Label();
            this.houTextBox = new System.Windows.Forms.TextBox();
            this.minuteTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.roomTextBox = new System.Windows.Forms.TextBox();
            this.updateBtn = new System.Windows.Forms.Button();
            this.warningMessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(56, 30);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker.TabIndex = 0;
            // 
            // hour
            // 
            this.hour.AutoSize = true;
            this.hour.Location = new System.Drawing.Point(12, 65);
            this.hour.Name = "hour";
            this.hour.Size = new System.Drawing.Size(34, 15);
            this.hour.TabIndex = 1;
            this.hour.Text = "Hour";
            // 
            // houTextBox
            // 
            this.houTextBox.Location = new System.Drawing.Point(56, 59);
            this.houTextBox.Name = "houTextBox";
            this.houTextBox.Size = new System.Drawing.Size(32, 23);
            this.houTextBox.TabIndex = 2;
            // 
            // minuteTextBox
            // 
            this.minuteTextBox.Location = new System.Drawing.Point(156, 59);
            this.minuteTextBox.Name = "minuteTextBox";
            this.minuteTextBox.Size = new System.Drawing.Size(31, 23);
            this.minuteTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Minute";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Room";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // roomTextBox
            // 
            this.roomTextBox.Location = new System.Drawing.Point(56, 108);
            this.roomTextBox.Name = "roomTextBox";
            this.roomTextBox.Size = new System.Drawing.Size(100, 23);
            this.roomTextBox.TabIndex = 6;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(137, 190);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 7;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // warningMessageLabel
            // 
            this.warningMessageLabel.AutoSize = true;
            this.warningMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.warningMessageLabel.Location = new System.Drawing.Point(156, 172);
            this.warningMessageLabel.Name = "warningMessageLabel";
            this.warningMessageLabel.Size = new System.Drawing.Size(38, 15);
            this.warningMessageLabel.TabIndex = 8;
            this.warningMessageLabel.Text = "label3";
            this.warningMessageLabel.Visible = false;
            // 
            // UpdateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 225);
            this.Controls.Add(this.warningMessageLabel);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.roomTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minuteTextBox);
            this.Controls.Add(this.houTextBox);
            this.Controls.Add(this.hour);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "UpdateAppointment";
            this.Text = "ChangdeAppointmentDateTimeForm";
            this.Load += new System.EventHandler(this.UpdateAppointment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker dateTimePicker;
        private Label hour;
        private TextBox houTextBox;
        private TextBox minuteTextBox;
        private Label label1;
        private Label label2;
        private TextBox roomTextBox;
        private Button updateBtn;
        private Label warningMessageLabel;
    }
}