using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
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
    
    partial class RevisionsForm : Form
    {
        
        public RevisionController revisionRepository;
        public DrugService drugService;
        public RevisionsForm()
            
        {
            revisionRepository = new RevisionController(Globals.database);

            this.drugService = Globals.container.Resolve<DrugService>();
            
            InitializeComponent();
        }

        private void reviseButton_Click(object sender, EventArgs e)
        {
            Drug drug = drugService.GetById(revisionView.SelectedItems[0].Text);
            AddDrug ad = new AddDrug();
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
