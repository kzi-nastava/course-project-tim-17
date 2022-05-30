namespace HealthcareSystem.UI.Patient
{
    partial class RecommendedScheduling
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
            this.priorityLabel = new System.Windows.Forms.Label();
            this.priorityBox = new System.Windows.Forms.ComboBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.doctorLabel = new System.Windows.Forms.Label();
            this.doctorBox = new System.Windows.Forms.ComboBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.recommendLabel = new System.Windows.Forms.Label();
            this.recommendBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(43, 38);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(45, 15);
            this.priorityLabel.TabIndex = 0;
            this.priorityLabel.Text = "Priority";
            // 
            // priorityBox
            // 
            this.priorityBox.FormattingEnabled = true;
            this.priorityBox.Location = new System.Drawing.Point(168, 35);
            this.priorityBox.Name = "priorityBox";
            this.priorityBox.Size = new System.Drawing.Size(200, 23);
            this.priorityBox.TabIndex = 1;
            this.priorityBox.SelectedIndexChanged += new System.EventHandler(this.priorityBox_SelectedIndexChanged);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(43, 77);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(105, 15);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Appointment Date";
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(168, 71);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 23);
            this.datePicker.TabIndex = 3;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // timePicker
            // 
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker.Location = new System.Drawing.Point(374, 71);
            this.timePicker.Name = "timePicker";
            this.timePicker.Size = new System.Drawing.Size(138, 23);
            this.timePicker.TabIndex = 4;
            this.timePicker.ValueChanged += new System.EventHandler(this.timePicker_ValueChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(43, 118);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(119, 15);
            this.typeLabel.TabIndex = 5;
            this.typeLabel.Text = "Type of Appointment";
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(168, 115);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(200, 23);
            this.typeBox.TabIndex = 6;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
            // 
            // doctorLabel
            // 
            this.doctorLabel.AutoSize = true;
            this.doctorLabel.Location = new System.Drawing.Point(45, 161);
            this.doctorLabel.Name = "doctorLabel";
            this.doctorLabel.Size = new System.Drawing.Size(43, 15);
            this.doctorLabel.TabIndex = 7;
            this.doctorLabel.Text = "Doctor";
            // 
            // doctorBox
            // 
            this.doctorBox.FormattingEnabled = true;
            this.doctorBox.Location = new System.Drawing.Point(168, 158);
            this.doctorBox.Name = "doctorBox";
            this.doctorBox.Size = new System.Drawing.Size(200, 23);
            this.doctorBox.TabIndex = 8;
            this.doctorBox.SelectedIndexChanged += new System.EventHandler(this.doctorBox_SelectedIndexChanged);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(187, 263);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(170, 37);
            this.submitBtn.TabIndex = 9;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(187, 193);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(38, 15);
            this.infoLabel.TabIndex = 10;
            this.infoLabel.Text = "label1";
            // 
            // recommendLabel
            // 
            this.recommendLabel.AutoSize = true;
            this.recommendLabel.Location = new System.Drawing.Point(42, 223);
            this.recommendLabel.Name = "recommendLabel";
            this.recommendLabel.Size = new System.Drawing.Size(120, 15);
            this.recommendLabel.TabIndex = 11;
            this.recommendLabel.Text = "Recommended Dates";
            // 
            // recommendBox
            // 
            this.recommendBox.FormattingEnabled = true;
            this.recommendBox.Location = new System.Drawing.Point(168, 220);
            this.recommendBox.Name = "recommendBox";
            this.recommendBox.Size = new System.Drawing.Size(200, 23);
            this.recommendBox.TabIndex = 12;
            this.recommendBox.SelectedIndexChanged += new System.EventHandler(this.recommendBox_SelectedIndexChanged);
            // 
            // RecommendedScheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 327);
            this.Controls.Add(this.recommendBox);
            this.Controls.Add(this.recommendLabel);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.doctorBox);
            this.Controls.Add(this.doctorLabel);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.priorityBox);
            this.Controls.Add(this.priorityLabel);
            this.Name = "RecommendedScheduling";
            this.Text = "RecommendedScheduling";
            this.Load += new System.EventHandler(this.RecommendedScheduling_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label priorityLabel;
        private ComboBox priorityBox;
        private Label dateLabel;
        private DateTimePicker datePicker;
        private DateTimePicker timePicker;
        private Label typeLabel;
        private ComboBox typeBox;
        private Label doctorLabel;
        private ComboBox doctorBox;
        private Button submitBtn;
        private Label infoLabel;
        private Label recommendLabel;
        private ComboBox recommendBox;
    }
}