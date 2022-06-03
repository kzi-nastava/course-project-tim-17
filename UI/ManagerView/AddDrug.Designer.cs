namespace HealthcareSystem.UI.ManagerView
{
    partial class AddDrug
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
            this.label1 = new System.Windows.Forms.Label();
            this.drugNameTextBox = new System.Windows.Forms.TextBox();
            this.ingredientTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.addDrugButton = new System.Windows.Forms.Button();
            this.ingredientsView = new System.Windows.Forms.ListView();
            this.Name = new System.Windows.Forms.ColumnHeader();
            this.deleteIngredientButton = new System.Windows.Forms.Button();
            this.reviseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // drugNameTextBox
            // 
            this.drugNameTextBox.Location = new System.Drawing.Point(13, 42);
            this.drugNameTextBox.Name = "drugNameTextBox";
            this.drugNameTextBox.Size = new System.Drawing.Size(169, 23);
            this.drugNameTextBox.TabIndex = 1;
            // 
            // ingredientTextBox
            // 
            this.ingredientTextBox.Location = new System.Drawing.Point(12, 101);
            this.ingredientTextBox.Name = "ingredientTextBox";
            this.ingredientTextBox.Size = new System.Drawing.Size(170, 23);
            this.ingredientTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ingredient";
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Location = new System.Drawing.Point(13, 140);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(95, 23);
            this.addIngredientButton.TabIndex = 4;
            this.addIngredientButton.Text = "Add Ingredient";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // addDrugButton
            // 
            this.addDrugButton.Location = new System.Drawing.Point(59, 298);
            this.addDrugButton.Name = "addDrugButton";
            this.addDrugButton.Size = new System.Drawing.Size(75, 23);
            this.addDrugButton.TabIndex = 5;
            this.addDrugButton.Text = "Add";
            this.addDrugButton.UseVisualStyleBackColor = true;
            this.addDrugButton.Click += new System.EventHandler(this.addDrugButton_Click);
            // 
            // ingredientsView
            // 
            this.ingredientsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name});
            this.ingredientsView.Location = new System.Drawing.Point(12, 169);
            this.ingredientsView.Name = "ingredientsView";
            this.ingredientsView.Size = new System.Drawing.Size(170, 123);
            this.ingredientsView.TabIndex = 6;
            this.ingredientsView.UseCompatibleStateImageBehavior = false;
            this.ingredientsView.View = System.Windows.Forms.View.Details;
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 200;
            // 
            // deleteIngredientButton
            // 
            this.deleteIngredientButton.Location = new System.Drawing.Point(114, 140);
            this.deleteIngredientButton.Name = "deleteIngredientButton";
            this.deleteIngredientButton.Size = new System.Drawing.Size(68, 23);
            this.deleteIngredientButton.TabIndex = 7;
            this.deleteIngredientButton.Text = "Delete";
            this.deleteIngredientButton.UseVisualStyleBackColor = true;
            this.deleteIngredientButton.Click += new System.EventHandler(this.deleteIngredientButton_Click);
            // 
            // reviseButton
            // 
            this.reviseButton.Location = new System.Drawing.Point(61, 298);
            this.reviseButton.Name = "reviseButton";
            this.reviseButton.Size = new System.Drawing.Size(73, 23);
            this.reviseButton.TabIndex = 8;
            this.reviseButton.Text = "Revise";
            this.reviseButton.UseVisualStyleBackColor = true;
            this.reviseButton.Click += new System.EventHandler(this.reviseButton_Click);
            // 
            // AddDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 333);
            this.Controls.Add(this.reviseButton);
            this.Controls.Add(this.deleteIngredientButton);
            this.Controls.Add(this.ingredientsView);
            this.Controls.Add(this.addDrugButton);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ingredientTextBox);
            this.Controls.Add(this.drugNameTextBox);
            this.Controls.Add(this.label1);
           
            this.Text = "AddDrug";
            this.Load += new System.EventHandler(this.AddDrug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox drugNameTextBox;
        private TextBox ingredientTextBox;
        private Label label2;
        private Button addIngredientButton;
        private Button addDrugButton;
        private ListView ingredientsView;
        private ColumnHeader Name;
        private Button deleteIngredientButton;
        private Button reviseButton;
    }
}