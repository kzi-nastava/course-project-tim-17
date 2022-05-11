namespace HealthcareSystem.UI.ManagerView
{
    partial class ModifyRoom
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
            this.roomName = new System.Windows.Forms.TextBox();
            this.roomTypeComboBox = new System.Windows.Forms.ComboBox();
            this.modifyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // roomName
            // 
            this.roomName.Location = new System.Drawing.Point(12, 12);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(172, 23);
            this.roomName.TabIndex = 0;
            // 
            // roomTypeComboBox
            // 
            this.roomTypeComboBox.FormattingEnabled = true;
            this.roomTypeComboBox.Location = new System.Drawing.Point(12, 59);
            this.roomTypeComboBox.Name = "roomTypeComboBox";
            this.roomTypeComboBox.Size = new System.Drawing.Size(172, 23);
            this.roomTypeComboBox.TabIndex = 1;
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(57, 108);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 23);
            this.modifyButton.TabIndex = 2;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // ModifyRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 153);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.roomTypeComboBox);
            this.Controls.Add(this.roomName);
            this.Name = "ModifyRoom";
            this.Text = "ModifyRoom";
            this.Load += new System.EventHandler(this.modifyRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox roomName;
        private ComboBox roomTypeComboBox;
        private Button modifyButton;
    }
}