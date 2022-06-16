using HealthcareSystem.Entity.DrugModel;
using MongoDB.Bson;
using MongoDB.Driver;
using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthcareSystem.UI.DoctorView
{
    partial class AddDescriptionForm : Form
    {
        public IMongoDatabase database;
        public ObjectId drugId;
        public RevisionService revisionService;
        public AddDescriptionForm(ObjectId drugId)
        {
            this.database = database;
            this.drugId = drugId;
            this.revisionService = Globals.container.Resolve<RevisionService>();                
            InitializeComponent();
        }

        private void AddDescriptionForm_Load(object sender, EventArgs e)
        {
            
        }

        private void reviseBtn_Click(object sender, EventArgs e)
        {
            string description = descriptionTextBox.Text;
            Revision revision = new Revision(description, drugId);
            revisionService.Insert(revision);
            MessageBox.Show("Ide ges");
            this.Dispose();
        }
    }
}
