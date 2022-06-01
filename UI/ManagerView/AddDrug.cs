using HealthcareSystem.Entity;
using HealthcareSystem.Entity.DrugModel;
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
        DrugController drugRepository;
        List<Ingredient> ingredients;

        public AddDrug(IMongoDatabase database)
        {
            drugRepository = new DrugController(database);
            ingredients = new List<Ingredient>();
            InitializeComponent();

        }

        private void AddDrug_Load(object sender, EventArgs e)
        {

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
            drugRepository.InsertToCollection(drug);
            MessageBox.Show("Strava");
            this.Dispose();
        }

        private void deleteIngredientButton_Click(object sender, EventArgs e)
        {
            ingredients.RemoveAt(ingredientsView.SelectedItems[0].Index);
            ingredientsView.Items.Clear();
            foreach (Ingredient i in ingredients)
            {
                ListViewItem item = new ListViewItem(i.name);
                ingredientsView.Items.Add(item);


            }
        }
    }
}
