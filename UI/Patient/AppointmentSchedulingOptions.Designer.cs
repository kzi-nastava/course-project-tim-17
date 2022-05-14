namespace HealthcareSystem.UI.Patient
{
    partial class AppointmentSchedulingOptions
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
            this.regularBtn = new System.Windows.Forms.Button();
            this.recommendedBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // regularBtn
            // 
            this.regularBtn.Location = new System.Drawing.Point(46, 59);
            this.regularBtn.Name = "regularBtn";
            this.regularBtn.Size = new System.Drawing.Size(166, 34);
            this.regularBtn.TabIndex = 0;
            this.regularBtn.Text = "Regular Scheduling";
            this.regularBtn.UseVisualStyleBackColor = true;
            this.regularBtn.Click += new System.EventHandler(this.regularBtn_Click);
            // 
            // recommendedBtn
            // 
            this.recommendedBtn.Location = new System.Drawing.Point(246, 59);
            this.recommendedBtn.Name = "recommendedBtn";
            this.recommendedBtn.Size = new System.Drawing.Size(166, 34);
            this.recommendedBtn.TabIndex = 1;
            this.recommendedBtn.Text = "Recommended Scheduling";
            this.recommendedBtn.UseVisualStyleBackColor = true;
            this.recommendedBtn.Click += new System.EventHandler(this.recommendedBtn_Click);
            // 
            // AppointmentSchedulingOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 170);
            this.Controls.Add(this.recommendedBtn);
            this.Controls.Add(this.regularBtn);
            this.Name = "AppointmentSchedulingOptions";
            this.Text = "AppointmentSchedulingOptions";
            this.Load += new System.EventHandler(this.AppointmentSchedulingOptions_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button regularBtn;
        private Button recommendedBtn;
    }
}