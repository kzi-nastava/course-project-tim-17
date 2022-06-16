namespace HealthcareSystem.UI.Patient
{
    partial class DoctorSurvey
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
            this.checkLabel = new System.Windows.Forms.Label();
            this.qualityLabel = new System.Windows.Forms.Label();
            this.recommendationLabel = new System.Windows.Forms.Label();
            this.commentLabel = new System.Windows.Forms.Label();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.successLabel = new System.Windows.Forms.Label();
            this.quality1 = new System.Windows.Forms.RadioButton();
            this.quality2 = new System.Windows.Forms.RadioButton();
            this.quality3 = new System.Windows.Forms.RadioButton();
            this.quality4 = new System.Windows.Forms.RadioButton();
            this.quality5 = new System.Windows.Forms.RadioButton();
            this.recommendation1 = new System.Windows.Forms.RadioButton();
            this.recommendation2 = new System.Windows.Forms.RadioButton();
            this.recommendation3 = new System.Windows.Forms.RadioButton();
            this.recommendation4 = new System.Windows.Forms.RadioButton();
            this.recommendation5 = new System.Windows.Forms.RadioButton();
            this.recommendationPanel = new System.Windows.Forms.Panel();
            this.qualityPanel = new System.Windows.Forms.Panel();
            this.checkBox = new System.Windows.Forms.ComboBox();
            this.recommendationPanel.SuspendLayout();
            this.qualityPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkLabel
            // 
            this.checkLabel.AutoSize = true;
            this.checkLabel.Location = new System.Drawing.Point(12, 23);
            this.checkLabel.Name = "checkLabel";
            this.checkLabel.Size = new System.Drawing.Size(46, 15);
            this.checkLabel.TabIndex = 0;
            this.checkLabel.Text = "Doctor:";
            // 
            // qualityLabel
            // 
            this.qualityLabel.AutoSize = true;
            this.qualityLabel.Location = new System.Drawing.Point(12, 61);
            this.qualityLabel.Name = "qualityLabel";
            this.qualityLabel.Size = new System.Drawing.Size(48, 15);
            this.qualityLabel.TabIndex = 1;
            this.qualityLabel.Text = "Quality:";
            // 
            // recommendationLabel
            // 
            this.recommendationLabel.AutoSize = true;
            this.recommendationLabel.Location = new System.Drawing.Point(12, 98);
            this.recommendationLabel.Name = "recommendationLabel";
            this.recommendationLabel.Size = new System.Drawing.Size(105, 15);
            this.recommendationLabel.TabIndex = 2;
            this.recommendationLabel.Text = "Recommendation:";
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(12, 136);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(64, 15);
            this.commentLabel.TabIndex = 3;
            this.commentLabel.Text = "Comment:";
            // 
            // commentTextBox
            // 
            this.commentTextBox.Location = new System.Drawing.Point(12, 154);
            this.commentTextBox.Multiline = true;
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(310, 124);
            this.commentTextBox.TabIndex = 4;
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(121, 322);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 5;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Location = new System.Drawing.Point(93, 297);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(147, 15);
            this.successLabel.TabIndex = 6;
            this.successLabel.Text = "Survey added successfully!";
            this.successLabel.Visible = false;
            // 
            // quality1
            // 
            this.quality1.AutoSize = true;
            this.quality1.Location = new System.Drawing.Point(3, 5);
            this.quality1.Name = "quality1";
            this.quality1.Size = new System.Drawing.Size(31, 19);
            this.quality1.TabIndex = 7;
            this.quality1.TabStop = true;
            this.quality1.Text = "1";
            this.quality1.UseVisualStyleBackColor = true;
            // 
            // quality2
            // 
            this.quality2.AutoSize = true;
            this.quality2.Location = new System.Drawing.Point(40, 5);
            this.quality2.Name = "quality2";
            this.quality2.Size = new System.Drawing.Size(31, 19);
            this.quality2.TabIndex = 8;
            this.quality2.TabStop = true;
            this.quality2.Text = "2";
            this.quality2.UseVisualStyleBackColor = true;
            // 
            // quality3
            // 
            this.quality3.AutoSize = true;
            this.quality3.Location = new System.Drawing.Point(77, 5);
            this.quality3.Name = "quality3";
            this.quality3.Size = new System.Drawing.Size(31, 19);
            this.quality3.TabIndex = 9;
            this.quality3.TabStop = true;
            this.quality3.Text = "3";
            this.quality3.UseVisualStyleBackColor = true;
            // 
            // quality4
            // 
            this.quality4.AutoSize = true;
            this.quality4.Location = new System.Drawing.Point(114, 5);
            this.quality4.Name = "quality4";
            this.quality4.Size = new System.Drawing.Size(31, 19);
            this.quality4.TabIndex = 10;
            this.quality4.TabStop = true;
            this.quality4.Text = "4";
            this.quality4.UseVisualStyleBackColor = true;
            // 
            // quality5
            // 
            this.quality5.AutoSize = true;
            this.quality5.Location = new System.Drawing.Point(151, 5);
            this.quality5.Name = "quality5";
            this.quality5.Size = new System.Drawing.Size(31, 19);
            this.quality5.TabIndex = 11;
            this.quality5.TabStop = true;
            this.quality5.Text = "5";
            this.quality5.UseVisualStyleBackColor = true;
            // 
            // recommendation1
            // 
            this.recommendation1.AutoSize = true;
            this.recommendation1.Location = new System.Drawing.Point(3, 5);
            this.recommendation1.Name = "recommendation1";
            this.recommendation1.Size = new System.Drawing.Size(31, 19);
            this.recommendation1.TabIndex = 12;
            this.recommendation1.TabStop = true;
            this.recommendation1.Text = "1";
            this.recommendation1.UseVisualStyleBackColor = true;
            // 
            // recommendation2
            // 
            this.recommendation2.AutoSize = true;
            this.recommendation2.Location = new System.Drawing.Point(40, 5);
            this.recommendation2.Name = "recommendation2";
            this.recommendation2.Size = new System.Drawing.Size(31, 19);
            this.recommendation2.TabIndex = 13;
            this.recommendation2.TabStop = true;
            this.recommendation2.Text = "2";
            this.recommendation2.UseVisualStyleBackColor = true;
            // 
            // recommendation3
            // 
            this.recommendation3.AutoSize = true;
            this.recommendation3.Location = new System.Drawing.Point(77, 5);
            this.recommendation3.Name = "recommendation3";
            this.recommendation3.Size = new System.Drawing.Size(31, 19);
            this.recommendation3.TabIndex = 14;
            this.recommendation3.TabStop = true;
            this.recommendation3.Text = "3";
            this.recommendation3.UseVisualStyleBackColor = true;
            // 
            // recommendation4
            // 
            this.recommendation4.AutoSize = true;
            this.recommendation4.Location = new System.Drawing.Point(114, 5);
            this.recommendation4.Name = "recommendation4";
            this.recommendation4.Size = new System.Drawing.Size(31, 19);
            this.recommendation4.TabIndex = 15;
            this.recommendation4.TabStop = true;
            this.recommendation4.Text = "4";
            this.recommendation4.UseVisualStyleBackColor = true;
            // 
            // recommendation5
            // 
            this.recommendation5.AutoSize = true;
            this.recommendation5.Location = new System.Drawing.Point(151, 5);
            this.recommendation5.Name = "recommendation5";
            this.recommendation5.Size = new System.Drawing.Size(31, 19);
            this.recommendation5.TabIndex = 16;
            this.recommendation5.TabStop = true;
            this.recommendation5.Text = "5";
            this.recommendation5.UseVisualStyleBackColor = true;
            // 
            // recommendationPanel
            // 
            this.recommendationPanel.Controls.Add(this.recommendation1);
            this.recommendationPanel.Controls.Add(this.recommendation5);
            this.recommendationPanel.Controls.Add(this.recommendation2);
            this.recommendationPanel.Controls.Add(this.recommendation4);
            this.recommendationPanel.Controls.Add(this.recommendation3);
            this.recommendationPanel.Location = new System.Drawing.Point(123, 93);
            this.recommendationPanel.Name = "recommendationPanel";
            this.recommendationPanel.Size = new System.Drawing.Size(199, 30);
            this.recommendationPanel.TabIndex = 17;
            // 
            // qualityPanel
            // 
            this.qualityPanel.Controls.Add(this.quality1);
            this.qualityPanel.Controls.Add(this.quality2);
            this.qualityPanel.Controls.Add(this.quality5);
            this.qualityPanel.Controls.Add(this.quality3);
            this.qualityPanel.Controls.Add(this.quality4);
            this.qualityPanel.Location = new System.Drawing.Point(123, 52);
            this.qualityPanel.Name = "qualityPanel";
            this.qualityPanel.Size = new System.Drawing.Size(199, 30);
            this.qualityPanel.TabIndex = 17;
            // 
            // checkBox
            // 
            this.checkBox.FormattingEnabled = true;
            this.checkBox.Location = new System.Drawing.Point(123, 15);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(199, 23);
            this.checkBox.TabIndex = 18;
            // 
            // DoctorSurvey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 365);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.qualityPanel);
            this.Controls.Add(this.recommendationPanel);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.recommendationLabel);
            this.Controls.Add(this.qualityLabel);
            this.Controls.Add(this.checkLabel);
            this.Name = "DoctorSurvey";
            this.Text = "DoctorSurvey";
            this.Load += new System.EventHandler(this.DoctorSurvey_Load);
            this.recommendationPanel.ResumeLayout(false);
            this.recommendationPanel.PerformLayout();
            this.qualityPanel.ResumeLayout(false);
            this.qualityPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label checkLabel;
        private Label qualityLabel;
        private Label recommendationLabel;
        private Label commentLabel;
        private TextBox commentTextBox;
        private Button confirmBtn;
        private Label successLabel;
        private RadioButton quality1;
        private RadioButton quality2;
        private RadioButton quality3;
        private RadioButton quality4;
        private RadioButton quality5;
        private RadioButton recommendation1;
        private RadioButton recommendation2;
        private RadioButton recommendation3;
        private RadioButton recommendation4;
        private RadioButton recommendation5;
        private Panel recommendationPanel;
        private Panel qualityPanel;
        private ComboBox checkBox;
    }
}