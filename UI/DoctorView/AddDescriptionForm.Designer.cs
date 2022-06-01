namespace HealthcareSystem.UI.DoctorView
{
    partial class AddDescriptionForm
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
            this.desriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.reviseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // desriptionLabel
            // 
            this.desriptionLabel.AutoSize = true;
            this.desriptionLabel.Location = new System.Drawing.Point(107, 26);
            this.desriptionLabel.Name = "desriptionLabel";
            this.desriptionLabel.Size = new System.Drawing.Size(67, 15);
            this.desriptionLabel.TabIndex = 0;
            this.desriptionLabel.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(12, 57);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(253, 122);
            this.descriptionTextBox.TabIndex = 1;
            this.descriptionTextBox.Text = "";
            // 
            // reviseBtn
            // 
            this.reviseBtn.Location = new System.Drawing.Point(99, 194);
            this.reviseBtn.Name = "reviseBtn";
            this.reviseBtn.Size = new System.Drawing.Size(75, 23);
            this.reviseBtn.TabIndex = 2;
            this.reviseBtn.Text = "Revise";
            this.reviseBtn.UseVisualStyleBackColor = true;
            this.reviseBtn.Click += new System.EventHandler(this.reviseBtn_Click);
            // 
            // AddDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 229);
            this.Controls.Add(this.reviseBtn);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.desriptionLabel);
            this.Name = "AddDescriptionForm";
            this.Text = "AddDescriptionForm";
            this.Load += new System.EventHandler(this.AddDescriptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label desriptionLabel;
        private RichTextBox descriptionTextBox;
        private Button reviseBtn;
    }
}