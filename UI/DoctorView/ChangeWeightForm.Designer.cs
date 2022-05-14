namespace HealthcareSystem.UI.DoctorView
{
    partial class ChangeWeightForm
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
            this.newWeightTextBox = new System.Windows.Forms.TextBox();
            this.newWeightLabel = new System.Windows.Forms.Label();
            this.changeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newWeightTextBox
            // 
            this.newWeightTextBox.Location = new System.Drawing.Point(101, 51);
            this.newWeightTextBox.Name = "newWeightTextBox";
            this.newWeightTextBox.Size = new System.Drawing.Size(100, 23);
            this.newWeightTextBox.TabIndex = 0;
            this.newWeightTextBox.TextChanged += new System.EventHandler(this.newWeightTextBox_TextChanged);
            // 
            // newWeightLabel
            // 
            this.newWeightLabel.AutoSize = true;
            this.newWeightLabel.Location = new System.Drawing.Point(23, 54);
            this.newWeightLabel.Name = "newWeightLabel";
            this.newWeightLabel.Size = new System.Drawing.Size(72, 15);
            this.newWeightLabel.TabIndex = 1;
            this.newWeightLabel.Text = "New Weight";
            // 
            // changeBtn
            // 
            this.changeBtn.Location = new System.Drawing.Point(76, 102);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(75, 23);
            this.changeBtn.TabIndex = 2;
            this.changeBtn.Text = "Change";
            this.changeBtn.UseVisualStyleBackColor = true;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // ChangeWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 147);
            this.Controls.Add(this.changeBtn);
            this.Controls.Add(this.newWeightLabel);
            this.Controls.Add(this.newWeightTextBox);
            this.Name = "ChangeWeight";
            this.Text = "ChangeWeight";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox newWeightTextBox;
        private Label newWeightLabel;
        private Button changeBtn;
    }
}