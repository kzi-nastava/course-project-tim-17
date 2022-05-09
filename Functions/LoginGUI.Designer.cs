namespace HealthcareSystem.Functions
{
    partial class LoginGUI
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
            this.loginBtn = new System.Windows.Forms.Button();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(99, 169);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(112, 34);
            this.loginBtn.TabIndex = 0;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(143, 29);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(150, 31);
            this.emailBox.TabIndex = 1;
            this.emailBox.TextChanged += new System.EventHandler(this.emailBox_TextChanged);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(143, 84);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(150, 31);
            this.passwordBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusLabel.ForeColor = System.Drawing.Color.Red;
            this.statusLabel.Location = new System.Drawing.Point(12, 134);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 25);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "null";
            this.statusLabel.Visible = false;
            // 
            // LoginGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 215);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.loginBtn);
            this.Name = "LoginGUI";
            this.Text = "LoginGUI";
            this.Load += new System.EventHandler(this.LoginGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button loginBtn;
        private TextBox emailBox;
        private TextBox passwordBox;
        private Label label1;
        private Label label2;
        private Label statusLabel;
    }
}