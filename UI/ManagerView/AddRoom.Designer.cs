namespace HealthcareSystem.UI.ManagerView
{
    partial class AddRoom
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
            this.roomNameBox = new System.Windows.Forms.TextBox();
            this.roomTypeComboBox = new System.Windows.Forms.ComboBox();
            this.addRoomButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // roomNameBox
            // 
            this.roomNameBox.Location = new System.Drawing.Point(12, 12);
            this.roomNameBox.Name = "roomNameBox";
            this.roomNameBox.Size = new System.Drawing.Size(170, 23);
            this.roomNameBox.TabIndex = 0;
            // 
            // roomTypeComboBox
            // 
            this.roomTypeComboBox.FormattingEnabled = true;
            this.roomTypeComboBox.Location = new System.Drawing.Point(12, 58);
            this.roomTypeComboBox.Name = "roomTypeComboBox";
            this.roomTypeComboBox.Size = new System.Drawing.Size(170, 23);
            this.roomTypeComboBox.TabIndex = 1;
            // 
            // addRoomButton
            // 
            this.addRoomButton.Location = new System.Drawing.Point(60, 112);
            this.addRoomButton.Name = "addRoomButton";
            this.addRoomButton.Size = new System.Drawing.Size(75, 23);
            this.addRoomButton.TabIndex = 2;
            this.addRoomButton.Text = "Add Room";
            this.addRoomButton.UseVisualStyleBackColor = true;
            this.addRoomButton.Click += new System.EventHandler(this.addRoomButton_Click);
            // 
            // AddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 147);
            this.Controls.Add(this.addRoomButton);
            this.Controls.Add(this.roomTypeComboBox);
            this.Controls.Add(this.roomNameBox);
            this.Name = "AddRoom";
            this.Text = "AddRoom";
            this.Load += new System.EventHandler(this.AddRoom_Load);
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox roomNameBox;
        private ComboBox roomTypeComboBox;
        private Button addRoomButton;
    }
}