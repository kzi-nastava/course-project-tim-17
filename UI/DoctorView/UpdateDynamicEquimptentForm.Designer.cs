namespace HealthcareSystem.UI.DoctorView
{
    partial class UpdateDynamicEquimptentForm
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
            this.equipmentNameTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.equipmentNameLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.finishBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.updateBtn = new System.Windows.Forms.Button();
            this.loadEquipmentBtn = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // equipmentNameTextBox
            // 
            this.equipmentNameTextBox.Location = new System.Drawing.Point(118, 279);
            this.equipmentNameTextBox.Name = "equipmentNameTextBox";
            this.equipmentNameTextBox.Size = new System.Drawing.Size(100, 23);
            this.equipmentNameTextBox.TabIndex = 1;
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(283, 279);
            this.quantityTextBox.Multiline = true;
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(36, 23);
            this.quantityTextBox.TabIndex = 2;
            // 
            // equipmentNameLabel
            // 
            this.equipmentNameLabel.AutoSize = true;
            this.equipmentNameLabel.Location = new System.Drawing.Point(12, 287);
            this.equipmentNameLabel.Name = "equipmentNameLabel";
            this.equipmentNameLabel.Size = new System.Drawing.Size(100, 15);
            this.equipmentNameLabel.TabIndex = 3;
            this.equipmentNameLabel.Text = "Equipment Name";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(224, 287);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(53, 15);
            this.quantityLabel.TabIndex = 4;
            this.quantityLabel.Text = "Quantity";
            this.quantityLabel.Click += new System.EventHandler(this.quantityLabel_Click);
            // 
            // finishBtn
            // 
            this.finishBtn.Location = new System.Drawing.Point(457, 279);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(75, 23);
            this.finishBtn.TabIndex = 6;
            this.finishBtn.Text = "Finish";
            this.finishBtn.UseVisualStyleBackColor = true;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.quantity});
            this.dataGridView1.Location = new System.Drawing.Point(283, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(249, 226);
            this.dataGridView1.TabIndex = 7;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(361, 279);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 8;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // loadEquipmentBtn
            // 
            this.loadEquipmentBtn.Location = new System.Drawing.Point(53, 31);
            this.loadEquipmentBtn.Name = "loadEquipmentBtn";
            this.loadEquipmentBtn.Size = new System.Drawing.Size(129, 23);
            this.loadEquipmentBtn.TabIndex = 9;
            this.loadEquipmentBtn.Text = "Load Equipment";
            this.loadEquipmentBtn.UseVisualStyleBackColor = true;
            this.loadEquipmentBtn.Click += new System.EventHandler(this.loadEquipmentBtn_Click);
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            // 
            // UpdateDynamicEquimptentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 330);
            this.Controls.Add(this.loadEquipmentBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.finishBtn);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.equipmentNameLabel);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.equipmentNameTextBox);
            this.Name = "UpdateDynamicEquimptentForm";
            this.Text = "UpdateDynamicEquimptentForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox equipmentNameTextBox;
        private TextBox quantityTextBox;
        private Label equipmentNameLabel;
        private Label quantityLabel;
        private Button finishBtn;
        private DataGridView dataGridView1;
        private Button updateBtn;
        private Button loadEquipmentBtn;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn quantity;
    }
}