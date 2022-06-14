namespace HealthcareSystem.UI.ManagerView
{
    partial class SurveysForm
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
            this.doctorSurveyView = new System.Windows.Forms.ListView();
            this.doctorName = new System.Windows.Forms.ColumnHeader();
            this.ductorLastname = new System.Windows.Forms.ColumnHeader();
            this.averageQuality = new System.Windows.Forms.ColumnHeader();
            this.averageReccomendation = new System.Windows.Forms.ColumnHeader();
            this.reccomendationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.oneLabel = new System.Windows.Forms.Label();
            this.twoLabel = new System.Windows.Forms.Label();
            this.threeLabel = new System.Windows.Forms.Label();
            this.fourLabel = new System.Windows.Forms.Label();
            this.fiveLabel = new System.Windows.Forms.Label();
            this.qualityButton = new System.Windows.Forms.Button();
            this.hospitalSurveyView = new System.Windows.Forms.ListView();
            this.hospitalAverageQuality = new System.Windows.Forms.ColumnHeader();
            this.hospitalAverageCleanliness = new System.Windows.Forms.ColumnHeader();
            this.hospitalAverageSatisfaction = new System.Windows.Forms.ColumnHeader();
            this.hopistalCleanlinessButton = new System.Windows.Forms.Button();
            this.hospitalSatisfactionButton = new System.Windows.Forms.Button();
            this.hospitalQualityButton = new System.Windows.Forms.Button();
            this.commentsView = new System.Windows.Forms.ListView();
            this.comments = new System.Windows.Forms.ColumnHeader();
            this.hospitalCommentsButton = new System.Windows.Forms.Button();
            this.doctorCommentsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // doctorSurveyView
            // 
            this.doctorSurveyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.doctorName,
            this.ductorLastname,
            this.averageQuality,
            this.averageReccomendation});
            this.doctorSurveyView.Location = new System.Drawing.Point(12, 183);
            this.doctorSurveyView.Name = "doctorSurveyView";
            this.doctorSurveyView.Size = new System.Drawing.Size(346, 126);
            this.doctorSurveyView.TabIndex = 0;
            this.doctorSurveyView.UseCompatibleStateImageBehavior = false;
            this.doctorSurveyView.View = System.Windows.Forms.View.Details;
            this.doctorSurveyView.SelectedIndexChanged += new System.EventHandler(this.doctorSurveyView_SelectedIndexChanged);
            // 
            // doctorName
            // 
            this.doctorName.Text = "Name";
            this.doctorName.Width = 70;
            // 
            // ductorLastname
            // 
            this.ductorLastname.Text = "Last Name";
            this.ductorLastname.Width = 70;
            // 
            // averageQuality
            // 
            this.averageQuality.Text = "Average Quality";
            this.averageQuality.Width = 100;
            // 
            // averageReccomendation
            // 
            this.averageReccomendation.Text = "Average Reccomendation";
            this.averageReccomendation.Width = 100;
            // 
            // reccomendationButton
            // 
            this.reccomendationButton.Location = new System.Drawing.Point(245, 154);
            this.reccomendationButton.Name = "reccomendationButton";
            this.reccomendationButton.Size = new System.Drawing.Size(113, 23);
            this.reccomendationButton.TabIndex = 1;
            this.reccomendationButton.Text = "Reccomendation";
            this.reccomendationButton.UseVisualStyleBackColor = true;
            this.reccomendationButton.Click += new System.EventHandler(this.reccomendationButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(33, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "(1)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(76, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "(2)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(119, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "(3)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(169, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "(4)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(218, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "(5)";
            // 
            // oneLabel
            // 
            this.oneLabel.AutoSize = true;
            this.oneLabel.Location = new System.Drawing.Point(33, 161);
            this.oneLabel.Name = "oneLabel";
            this.oneLabel.Size = new System.Drawing.Size(13, 15);
            this.oneLabel.TabIndex = 7;
            this.oneLabel.Text = "0";
            // 
            // twoLabel
            // 
            this.twoLabel.AutoSize = true;
            this.twoLabel.Location = new System.Drawing.Point(76, 161);
            this.twoLabel.Name = "twoLabel";
            this.twoLabel.Size = new System.Drawing.Size(13, 15);
            this.twoLabel.TabIndex = 8;
            this.twoLabel.Text = "0";
            // 
            // threeLabel
            // 
            this.threeLabel.AutoSize = true;
            this.threeLabel.Location = new System.Drawing.Point(119, 161);
            this.threeLabel.Name = "threeLabel";
            this.threeLabel.Size = new System.Drawing.Size(13, 15);
            this.threeLabel.TabIndex = 9;
            this.threeLabel.Text = "0";
            // 
            // fourLabel
            // 
            this.fourLabel.AutoSize = true;
            this.fourLabel.Location = new System.Drawing.Point(169, 161);
            this.fourLabel.Name = "fourLabel";
            this.fourLabel.Size = new System.Drawing.Size(13, 15);
            this.fourLabel.TabIndex = 10;
            this.fourLabel.Text = "0";
            // 
            // fiveLabel
            // 
            this.fiveLabel.AutoSize = true;
            this.fiveLabel.Location = new System.Drawing.Point(218, 161);
            this.fiveLabel.Name = "fiveLabel";
            this.fiveLabel.Size = new System.Drawing.Size(13, 15);
            this.fiveLabel.TabIndex = 11;
            this.fiveLabel.Text = "0";
            // 
            // qualityButton
            // 
            this.qualityButton.Location = new System.Drawing.Point(245, 123);
            this.qualityButton.Name = "qualityButton";
            this.qualityButton.Size = new System.Drawing.Size(113, 23);
            this.qualityButton.TabIndex = 12;
            this.qualityButton.Text = "Quality";
            this.qualityButton.UseVisualStyleBackColor = true;
            this.qualityButton.Click += new System.EventHandler(this.qualityButton_Click);
            // 
            // hospitalSurveyView
            // 
            this.hospitalSurveyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hospitalAverageQuality,
            this.hospitalAverageCleanliness,
            this.hospitalAverageSatisfaction});
            this.hospitalSurveyView.Location = new System.Drawing.Point(12, 12);
            this.hospitalSurveyView.Name = "hospitalSurveyView";
            this.hospitalSurveyView.Size = new System.Drawing.Size(347, 56);
            this.hospitalSurveyView.TabIndex = 13;
            this.hospitalSurveyView.UseCompatibleStateImageBehavior = false;
            this.hospitalSurveyView.View = System.Windows.Forms.View.Details;
            // 
            // hospitalAverageQuality
            // 
            this.hospitalAverageQuality.Text = "Quality";
            this.hospitalAverageQuality.Width = 113;
            // 
            // hospitalAverageCleanliness
            // 
            this.hospitalAverageCleanliness.Text = "Cleanliness";
            this.hospitalAverageCleanliness.Width = 113;
            // 
            // hospitalAverageSatisfaction
            // 
            this.hospitalAverageSatisfaction.Text = "Satisfaction";
            this.hospitalAverageSatisfaction.Width = 113;
            // 
            // hopistalCleanlinessButton
            // 
            this.hopistalCleanlinessButton.Location = new System.Drawing.Point(124, 74);
            this.hopistalCleanlinessButton.Name = "hopistalCleanlinessButton";
            this.hopistalCleanlinessButton.Size = new System.Drawing.Size(115, 32);
            this.hopistalCleanlinessButton.TabIndex = 14;
            this.hopistalCleanlinessButton.Text = "Cleanliness";
            this.hopistalCleanlinessButton.UseVisualStyleBackColor = true;
            this.hopistalCleanlinessButton.Click += new System.EventHandler(this.hopistalCleanlinessButton_Click);
            // 
            // hospitalSatisfactionButton
            // 
            this.hospitalSatisfactionButton.Location = new System.Drawing.Point(245, 74);
            this.hospitalSatisfactionButton.Name = "hospitalSatisfactionButton";
            this.hospitalSatisfactionButton.Size = new System.Drawing.Size(114, 32);
            this.hospitalSatisfactionButton.TabIndex = 15;
            this.hospitalSatisfactionButton.Text = "Satisfaction";
            this.hospitalSatisfactionButton.UseVisualStyleBackColor = true;
            this.hospitalSatisfactionButton.Click += new System.EventHandler(this.hospitalSatisfactionButton_Click);
            // 
            // hospitalQualityButton
            // 
            this.hospitalQualityButton.Location = new System.Drawing.Point(12, 74);
            this.hospitalQualityButton.Name = "hospitalQualityButton";
            this.hospitalQualityButton.Size = new System.Drawing.Size(106, 32);
            this.hospitalQualityButton.TabIndex = 16;
            this.hospitalQualityButton.Text = "Quality";
            this.hospitalQualityButton.UseVisualStyleBackColor = true;
            this.hospitalQualityButton.Click += new System.EventHandler(this.hospitalQualityButton_Click);
            // 
            // commentsView
            // 
            this.commentsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.comments});
            this.commentsView.Location = new System.Drawing.Point(12, 385);
            this.commentsView.Name = "commentsView";
            this.commentsView.Size = new System.Drawing.Size(346, 97);
            this.commentsView.TabIndex = 17;
            this.commentsView.UseCompatibleStateImageBehavior = false;
            this.commentsView.View = System.Windows.Forms.View.Details;
            // 
            // comments
            // 
            this.comments.Text = "Comments";
            this.comments.Width = 340;
            // 
            // hospitalCommentsButton
            // 
            this.hospitalCommentsButton.Location = new System.Drawing.Point(63, 330);
            this.hospitalCommentsButton.Name = "hospitalCommentsButton";
            this.hospitalCommentsButton.Size = new System.Drawing.Size(119, 34);
            this.hospitalCommentsButton.TabIndex = 18;
            this.hospitalCommentsButton.Text = "HComments";
            this.hospitalCommentsButton.UseVisualStyleBackColor = true;
            this.hospitalCommentsButton.Click += new System.EventHandler(this.hospitalCommentsButton_Click);
            // 
            // doctorCommentsButton
            // 
            this.doctorCommentsButton.Location = new System.Drawing.Point(188, 330);
            this.doctorCommentsButton.Name = "doctorCommentsButton";
            this.doctorCommentsButton.Size = new System.Drawing.Size(119, 34);
            this.doctorCommentsButton.TabIndex = 19;
            this.doctorCommentsButton.Text = "DComments";
            this.doctorCommentsButton.UseVisualStyleBackColor = true;
            this.doctorCommentsButton.Click += new System.EventHandler(this.doctorCommentsButton_Click);
            // 
            // SurveysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 494);
            this.Controls.Add(this.doctorCommentsButton);
            this.Controls.Add(this.hospitalCommentsButton);
            this.Controls.Add(this.commentsView);
            this.Controls.Add(this.hospitalQualityButton);
            this.Controls.Add(this.hospitalSatisfactionButton);
            this.Controls.Add(this.hopistalCleanlinessButton);
            this.Controls.Add(this.hospitalSurveyView);
            this.Controls.Add(this.qualityButton);
            this.Controls.Add(this.fiveLabel);
            this.Controls.Add(this.fourLabel);
            this.Controls.Add(this.threeLabel);
            this.Controls.Add(this.twoLabel);
            this.Controls.Add(this.oneLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reccomendationButton);
            this.Controls.Add(this.doctorSurveyView);
            this.Name = "SurveysForm";
            this.Text = "SurveysForm";
            this.Load += new System.EventHandler(this.SurveysForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView doctorSurveyView;
        private ColumnHeader doctorName;
        private ColumnHeader ductorLastname;
        private ColumnHeader averageQuality;
        private ColumnHeader averageReccomendation;
        private Button reccomendationButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label oneLabel;
        private Label twoLabel;
        private Label threeLabel;
        private Label fourLabel;
        private Label fiveLabel;
        private Button qualityButton;
        private ListView hospitalSurveyView;
        private ColumnHeader hospitalAverageQuality;
        private ColumnHeader hospitalAverageCleanliness;
        private ColumnHeader hospitalAverageSatisfaction;
        private Button hopistalCleanlinessButton;
        private Button hospitalSatisfactionButton;
        private Button hospitalQualityButton;
        private ListView commentsView;
        private ColumnHeader comments;
        private Button hospitalCommentsButton;
        private Button doctorCommentsButton;
    }
}