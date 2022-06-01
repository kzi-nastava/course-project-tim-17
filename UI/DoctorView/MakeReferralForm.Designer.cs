namespace HealthcareSystem.UI.DoctorView
{
    partial class MakeReferralForm
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
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.createReferralBtn = new System.Windows.Forms.Button();
            this.warningMessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 29);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            this.nameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(12, 69);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(66, 15);
            this.lastNameLabel.TabIndex = 1;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(84, 61);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(100, 23);
            this.lastNameTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(84, 21);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 23);
            this.nameTextBox.TabIndex = 3;
            // 
            // createReferralBtn
            // 
            this.createReferralBtn.Location = new System.Drawing.Point(84, 134);
            this.createReferralBtn.Name = "createReferralBtn";
            this.createReferralBtn.Size = new System.Drawing.Size(100, 23);
            this.createReferralBtn.TabIndex = 4;
            this.createReferralBtn.Text = "Create Referral";
            this.createReferralBtn.UseVisualStyleBackColor = true;
            this.createReferralBtn.Click += new System.EventHandler(this.createReferralBtn_Click);
            // 
            // warningMessageLabel
            // 
            this.warningMessageLabel.AutoSize = true;
            this.warningMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.warningMessageLabel.Location = new System.Drawing.Point(114, 107);
            this.warningMessageLabel.Name = "warningMessageLabel";
            this.warningMessageLabel.Size = new System.Drawing.Size(38, 15);
            this.warningMessageLabel.TabIndex = 5;
            this.warningMessageLabel.Text = "label1";
            this.warningMessageLabel.Visible = false;
            // 
            // MakeReferralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 182);
            this.Controls.Add(this.warningMessageLabel);
            this.Controls.Add(this.createReferralBtn);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "MakeReferralForm";
            this.Text = "MakeReferralForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label nameLabel;
        private Label lastNameLabel;
        private TextBox lastNameTextBox;
        private TextBox nameTextBox;
        private Button createReferralBtn;
        private Label warningMessageLabel;
    }
}