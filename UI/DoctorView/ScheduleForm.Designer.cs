namespace HealthcareSystem.UI.DoctorView
{
    partial class ScheduleForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatienName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performBtn = new System.Windows.Forms.Button();
            this.warningMessageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Date,
            this.Time,
            this.PatienName,
            this.PatientLastName});
            this.dataGridView1.Location = new System.Drawing.Point(146, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(545, 321);
            this.dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // PatienName
            // 
            this.PatienName.HeaderText = "Patient Name";
            this.PatienName.Name = "PatienName";
            // 
            // PatientLastName
            // 
            this.PatientLastName.HeaderText = "Patient last name";
            this.PatientLastName.Name = "PatientLastName";
            // 
            // performBtn
            // 
            this.performBtn.Location = new System.Drawing.Point(23, 79);
            this.performBtn.Name = "performBtn";
            this.performBtn.Size = new System.Drawing.Size(75, 23);
            this.performBtn.TabIndex = 1;
            this.performBtn.Text = "Perform";
            this.performBtn.UseVisualStyleBackColor = true;
            this.performBtn.Click += new System.EventHandler(this.performBtn_Click);
            // 
            // warningMessageLabel
            // 
            this.warningMessageLabel.AutoSize = true;
            this.warningMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.warningMessageLabel.Location = new System.Drawing.Point(393, 410);
            this.warningMessageLabel.Name = "warningMessageLabel";
            this.warningMessageLabel.Size = new System.Drawing.Size(38, 15);
            this.warningMessageLabel.TabIndex = 2;
            this.warningMessageLabel.Text = "label1";
            this.warningMessageLabel.Visible = false;
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 466);
            this.Controls.Add(this.warningMessageLabel);
            this.Controls.Add(this.performBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ScheduleForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ScheduleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn PatienName;
        private DataGridViewTextBoxColumn PatientLastName;
        private Button performBtn;
        private Label warningMessageLabel;
    }
}