namespace HealthcareSystem.UI.DoctorView
{
    partial class ChangeHeightForm
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
            this.newHeightLabel = new System.Windows.Forms.Label();
            this.newHeightTextBox = new System.Windows.Forms.TextBox();
            this.changeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newHeightLabel
            // 
            this.newHeightLabel.AutoSize = true;
            this.newHeightLabel.Location = new System.Drawing.Point(35, 81);
            this.newHeightLabel.Name = "newHeightLabel";
            this.newHeightLabel.Size = new System.Drawing.Size(70, 15);
            this.newHeightLabel.TabIndex = 0;
            this.newHeightLabel.Text = "New Height";
            // 
            // newHeightTextBox
            // 
            this.newHeightTextBox.Location = new System.Drawing.Point(111, 78);
            this.newHeightTextBox.Name = "newHeightTextBox";
            this.newHeightTextBox.Size = new System.Drawing.Size(100, 23);
            this.newHeightTextBox.TabIndex = 1;
            // 
            // changeBtn
            // 
            this.changeBtn.Location = new System.Drawing.Point(111, 138);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(75, 23);
            this.changeBtn.TabIndex = 2;
            this.changeBtn.Text = "Change";
            this.changeBtn.UseVisualStyleBackColor = true;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // ChangeHeightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 186);
            this.Controls.Add(this.changeBtn);
            this.Controls.Add(this.newHeightTextBox);
            this.Controls.Add(this.newHeightLabel);
            this.Name = "ChangeHeightForm";
            this.Text = "ChangeHeightForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label newHeightLabel;
        private TextBox newHeightTextBox;
        private Button changeBtn;
    }
}