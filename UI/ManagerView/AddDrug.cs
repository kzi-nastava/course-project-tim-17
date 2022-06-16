using HealthcareSystem.Entity;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.Enumerations;
using Autofac;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthcareSystem.UI.ManagerView
{
    partial class AddDrug : Form
    {
        DrugService drugService;
        List<Ingredient> ingredients;
        Drug drugInRevision;
        
        bool inRevision;

        public AddDrug()
        {
            drugService = Globals.container.Resolve<DrugService>();
            ingredients = new List<Ingredient>();
            inRevision = false;
            drugInRevision = null;
            InitializeComponent();

        }

        private void AddDrug_Load(object sender, EventArgs e)
        {
            if (!inRevision)
            { 
                reviseButton.Visible = false;
                addDrugButton.Visible = true;
            }
            if (inRevision)
            {
                reviseButton.Visible = true;
                addDrugButton.Visible = false;
            }
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            string name = ingredientTextBox.Text;
            Ingredient ingredient = new Ingredient(name);
            ListViewItem item = new ListViewItem(name);
           
            ingredientsView.Items.Add(item);
            ingredients.Add(ingredient);
        }

        private void addDrugButton_Click(object sender, EventArgs e)
        {
            Drug drug = new Drug(drugNameTextBox.Text, ingredients);
            drugService.Insert(drug);
            MessageBox.Show("Strava");
            this.Dispose();
        }

        private void deleteIngredientButton_Click(object sender, EventArgs e)
        {
            ingredients.RemoveAt(ingredientsView.SelectedItems[0].Index);
            loadIngredientView();
            
        }
        private void loadIngredientView()
        {
            ingredientsView.Items.Clear();
            foreach (Ingredient i in ingredients)
            {
                ListViewItem item = new ListViewItem(i.name);
                ingredientsView.Items.Add(item);


            }

        }

        public void Revise(Drug drug) 
        {
            this.ingredients = drug.ingredients;
            drugNameTextBox.Text = drug.name;
            inRevision = true;
            drugInRevision = drug;
            loadIngredientView();
        }

        private void reviseButton_Click(object sender, EventArgs e)
        {
            drugInRevision.ingredients = this.ingredients;
            drugInRevision.name = drugNameTextBox.Text;
            drugInRevision.DrugStatus = DrugStatus.ON_HOLD;
            drugService.Update(drugInRevision);
            Globals.container.Resolve<RevisionService>()
                .Delete(drugInRevision._id);
            MessageBox.Show("cool");
            this.Dispose();

        }
    }
}
