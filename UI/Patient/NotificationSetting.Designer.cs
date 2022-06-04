namespace HealthcareSystem.UI.Patient
{
    partial class NotificationSetting
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
            this.chooseLabel = new System.Windows.Forms.Label();
            this.hoursNumeric = new System.Windows.Forms.NumericUpDown();
            this.submitBtn = new System.Windows.Forms.Button();
            this.successLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseLabel
            // 
            this.chooseLabel.AutoSize = true;
            this.chooseLabel.Location = new System.Drawing.Point(29, 43);
            this.chooseLabel.Name = "chooseLabel";
            this.chooseLabel.Size = new System.Drawing.Size(141, 15);
            this.chooseLabel.TabIndex = 0;
            this.chooseLabel.Text = "Notify me _ hours before:";
            // 
            // hoursNumeric
            // 
            this.hoursNumeric.Location = new System.Drawing.Point(176, 41);
            this.hoursNumeric.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.hoursNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hoursNumeric.Name = "hoursNumeric";
            this.hoursNumeric.Size = new System.Drawing.Size(120, 23);
            this.hoursNumeric.TabIndex = 1;
            this.hoursNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(132, 111);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 2;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Location = new System.Drawing.Point(96, 81);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(162, 15);
            this.successLabel.TabIndex = 3;
            this.successLabel.Text = "Setting changed successfully!";
            this.successLabel.Visible = false;
            // 
            // NotificationSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 146);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.hoursNumeric);
            this.Controls.Add(this.chooseLabel);
            this.Name = "NotificationSetting";
            this.Text = "NotificationSetting";
            this.Load += new System.EventHandler(this.NotificationSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label chooseLabel;
        private NumericUpDown hoursNumeric;
        private Button submitBtn;
        private Label successLabel;
    }
}