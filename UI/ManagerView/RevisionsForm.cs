using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
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
    
    partial class RevisionsForm : Form
    {
        public DrugController drugRepository;
        public RevisionController revisionRepository;
        public DrugService drugService;
        public IMongoDatabase database;
        public RevisionsForm(IMongoDatabase database)
            
        {
            revisionRepository = new RevisionController(database);
            drugRepository = new DrugController(database);
            this.drugService = new DrugService(database);
            this.database = database;
            InitializeComponent();
        }

        private void reviseButton_Click(object sender, EventArgs e)
        {
            Drug drug = drugRepository.FindById(new ObjectId(revisionView.SelectedItems[0].Text));
            AddDrug ad = new AddDrug(database);
            ad.Revise(drug);
            ad.Show();
        }

        private void RevisionsForm_Load(object sender, EventArgs e)
        {
            List<Drug> drugs = drugService.GetCertainDrugs(DrugStatus.CHANGES_REQUIRED);

            foreach (Drug d in drugs)
            {
                Revision r = revisionRepository.FindByDrugId(d._id);
                ListViewItem item = new ListViewItem(d._id.ToString());
                item.SubItems.Add(d.name);
                item.SubItems.Add(r.desctription);
                revisionView.Items.Add(item);
            }

        }
    }
}
