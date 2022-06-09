namespace HealthcareSystem.UI.DoctorView
{
    partial class FreeDayRequestForm
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
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FromLabel = new System.Windows.Forms.Label();
            this.UrgentCheckBox = new System.Windows.Forms.CheckBox();
            this.ToTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.finishBtn = new System.Windows.Forms.Button();
            this.invalidDateLabel = new System.Windows.Forms.Label();
            this.warningMessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Location = new System.Drawing.Point(40, 69);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(200, 23);
            this.fromDatePicker.TabIndex = 0;
            this.fromDatePicker.ValueChanged += new System.EventHandler(this.FromDatePicker_ValueChanged);
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(115, 36);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(35, 15);
            this.FromLabel.TabIndex = 1;
            this.FromLabel.Text = "From";
            // 
            // UrgentCheckBox
            // 
            this.UrgentCheckBox.AutoSize = true;
            this.UrgentCheckBox.Location = new System.Drawing.Point(104, 123);
            this.UrgentCheckBox.Name = "UrgentCheckBox";
            this.UrgentCheckBox.Size = new System.Drawing.Size(62, 19);
            this.UrgentCheckBox.TabIndex = 2;
            this.UrgentCheckBox.Text = "Urgent";
            this.UrgentCheckBox.UseVisualStyleBackColor = true;
            this.UrgentCheckBox.CheckedChanged += new System.EventHandler(this.UrgentCheckBox_CheckedChanged);
            // 
            // ToTimePicker
            // 
            this.ToTimePicker.Location = new System.Drawing.Point(40, 195);
            this.ToTimePicker.Name = "ToTimePicker";
            this.ToTimePicker.Size = new System.Drawing.Size(200, 23);
            this.ToTimePicker.TabIndex = 3;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(131, 166);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(19, 15);
            this.toLabel.TabIndex = 4;
            this.toLabel.Text = "To";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(40, 287);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(200, 96);
            this.DescriptionTextBox.TabIndex = 5;
            this.DescriptionTextBox.Text = "";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(99, 245);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(67, 15);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Description";
            // 
            // finishBtn
            // 
            this.finishBtn.Location = new System.Drawing.Point(99, 447);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(75, 23);
            this.finishBtn.TabIndex = 7;
            this.finishBtn.Text = "Finish";
            this.finishBtn.UseVisualStyleBackColor = true;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // invalidDateLabel
            // 
            this.invalidDateLabel.AutoSize = true;
            this.invalidDateLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidDateLabel.Location = new System.Drawing.Point(12, 95);
            this.invalidDateLabel.Name = "invalidDateLabel";
            this.invalidDateLabel.Size = new System.Drawing.Size(38, 15);
            this.invalidDateLabel.TabIndex = 8;
            this.invalidDateLabel.Text = "label1";
            this.invalidDateLabel.Visible = false;
            // 
            // warningMessageLabel
            // 
            this.warningMessageLabel.AutoSize = true;
            this.warningMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.warningMessageLabel.Location = new System.Drawing.Point(72, 414);
            this.warningMessageLabel.Name = "warningMessageLabel";
            this.warningMessageLabel.Size = new System.Drawing.Size(38, 15);
            this.warningMessageLabel.TabIndex = 9;
            this.warningMessageLabel.Text = "label1";
            this.warningMessageLabel.Visible = false;
            // 
            // FreeDayRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 482);
            this.Controls.Add(this.warningMessageLabel);
            this.Controls.Add(this.invalidDateLabel);
            this.Controls.Add(this.finishBtn);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.ToTimePicker);
            this.Controls.Add(this.UrgentCheckBox);
            this.Controls.Add(this.FromLabel);
            this.Controls.Add(this.fromDatePicker);
            this.Name = "FreeDayRequestForm";
            this.Text = "FreeDayRequestForm";
            this.Load += new System.EventHandler(this.FreeDayRequestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker fromDatePicker;
        private Label FromLabel;
        private CheckBox UrgentCheckBox;
        private DateTimePicker ToTimePicker;
        private Label toLabel;
        private RichTextBox DescriptionTextBox;
        private Label descriptionLabel;
        private Button finishBtn;
        private Label invalidDateLabel;
        private Label warningMessageLabel;
    }
}