namespace HealthcareSystem.UI.ManagerView
{
    partial class RevisionsForm
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
            this.revisionView = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.message = new System.Windows.Forms.ColumnHeader();
            this.reviseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // revisionView
            // 
            this.revisionView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.name,
            this.message});
            this.revisionView.Location = new System.Drawing.Point(12, 12);
            this.revisionView.Name = "revisionView";
            this.revisionView.Size = new System.Drawing.Size(384, 224);
            this.revisionView.TabIndex = 0;
            this.revisionView.UseCompatibleStateImageBehavior = false;
            this.revisionView.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 100;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 80;
            // 
            // message
            // 
            this.message.Text = "Message";
            this.message.Width = 200;
            // 
            // reviseButton
            // 
            this.reviseButton.Location = new System.Drawing.Point(62, 242);
            this.reviseButton.Name = "reviseButton";
            this.reviseButton.Size = new System.Drawing.Size(92, 35);
            this.reviseButton.TabIndex = 1;
            this.reviseButton.Text = "Revise";
            this.reviseButton.UseVisualStyleBackColor = true;
            this.reviseButton.Click += new System.EventHandler(this.reviseButton_Click);
            // 
            // RevisionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 288);
            this.Controls.Add(this.reviseButton);
            this.Controls.Add(this.revisionView);
            this.Name = "RevisionsForm";
            this.Text = "RevisionsForm";
            this.Load += new System.EventHandler(this.RevisionsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView revisionView;
        private ColumnHeader id;
        private ColumnHeader name;
        private ColumnHeader message;
        private Button reviseButton;
    }
}