namespace HealthcareSystem.UI.DoctorView
{
    partial class CheckForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.lastNamelabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.allergiesLabel = new System.Windows.Forms.Label();
            this.allergiesLabeel = new System.Windows.Forms.Label();
            this.changeWeightBtn = new System.Windows.Forms.Button();
            this.changeHeightBtn = new System.Windows.Forms.Button();
            this.makeReferralBtn = new System.Windows.Forms.Button();
            this.performCheckupBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 28);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // lastNamelabel
            // 
            this.lastNamelabel.AutoSize = true;
            this.lastNamelabel.Location = new System.Drawing.Point(12, 59);
            this.lastNamelabel.Name = "lastNamelabel";
            this.lastNamelabel.Size = new System.Drawing.Size(66, 15);
            this.lastNamelabel.TabIndex = 1;
            this.lastNamelabel.Text = "Last Name:";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(12, 87);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(51, 15);
            this.weightLabel.TabIndex = 2;
            this.weightLabel.Text = "Weight: ";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(12, 116);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(46, 15);
            this.heightLabel.TabIndex = 3;
            this.heightLabel.Text = "Height:";
            // 
            // allergiesLabel
            // 
            this.allergiesLabel.AutoSize = true;
            this.allergiesLabel.Location = new System.Drawing.Point(12, 144);
            this.allergiesLabel.Name = "allergiesLabel";
            this.allergiesLabel.Size = new System.Drawing.Size(0, 15);
            this.allergiesLabel.TabIndex = 4;
            // 
            // allergiesLabeel
            // 
            this.allergiesLabeel.AutoSize = true;
            this.allergiesLabeel.Location = new System.Drawing.Point(12, 144);
            this.allergiesLabeel.Name = "allergiesLabeel";
            this.allergiesLabeel.Size = new System.Drawing.Size(55, 15);
            this.allergiesLabeel.TabIndex = 5;
            this.allergiesLabeel.Text = "Allergies:";
            // 
            // changeWeightBtn
            // 
            this.changeWeightBtn.Location = new System.Drawing.Point(96, 192);
            this.changeWeightBtn.Name = "changeWeightBtn";
            this.changeWeightBtn.Size = new System.Drawing.Size(110, 23);
            this.changeWeightBtn.TabIndex = 6;
            this.changeWeightBtn.Text = "Change Weight";
            this.changeWeightBtn.UseVisualStyleBackColor = true;
            this.changeWeightBtn.Click += new System.EventHandler(this.changeWeightBtn_Click);
            // 
            // changeHeightBtn
            // 
            this.changeHeightBtn.Location = new System.Drawing.Point(96, 247);
            this.changeHeightBtn.Name = "changeHeightBtn";
            this.changeHeightBtn.Size = new System.Drawing.Size(110, 23);
            this.changeHeightBtn.TabIndex = 7;
            this.changeHeightBtn.Text = "Change Height";
            this.changeHeightBtn.UseVisualStyleBackColor = true;
            this.changeHeightBtn.Click += new System.EventHandler(this.changeHeightBtn_Click);
            // 
            // makeReferralBtn
            // 
            this.makeReferralBtn.Location = new System.Drawing.Point(96, 300);
            this.makeReferralBtn.Name = "makeReferralBtn";
            this.makeReferralBtn.Size = new System.Drawing.Size(110, 23);
            this.makeReferralBtn.TabIndex = 8;
            this.makeReferralBtn.Text = "Make Referral";
            this.makeReferralBtn.UseVisualStyleBackColor = true;
            this.makeReferralBtn.Click += new System.EventHandler(this.makeReferralBtn_Click);
            // 
            // performCheckupBtn
            // 
            this.performCheckupBtn.Location = new System.Drawing.Point(96, 354);
            this.performCheckupBtn.Name = "performCheckupBtn";
            this.performCheckupBtn.Size = new System.Drawing.Size(110, 23);
            this.performCheckupBtn.TabIndex = 9;
            this.performCheckupBtn.Text = "Perform Checkup";
            this.performCheckupBtn.UseVisualStyleBackColor = true;
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 445);
            this.Controls.Add(this.performCheckupBtn);
            this.Controls.Add(this.makeReferralBtn);
            this.Controls.Add(this.changeHeightBtn);
            this.Controls.Add(this.changeWeightBtn);
            this.Controls.Add(this.allergiesLabeel);
            this.Controls.Add(this.allergiesLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.lastNamelabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "CheckForm";
            this.Text = "CheckForm";
            this.Load += new System.EventHandler(this.CheckForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label nameLabel;
        private Label lastNamelabel;
        private Label weightLabel;
        private Label heightLabel;
        private Label allergiesLabel;
        private Label allergiesLabeel;
        private Button changeWeightBtn;
        private Button changeHeightBtn;
        private Button makeReferralBtn;
        private Button performCheckupBtn;
    }
}