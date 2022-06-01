﻿using HealthcareSystem.Entity.DrugModel;
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

namespace HealthcareSystem.UI.DoctorView
{
    partial class RevisionForm : Form
    {
        public IMongoDatabase database;
        public DrugService drugService;
        public DrugController drugRepository;
        public RevisionForm(IMongoDatabase database)
        {
            this.database = database;
            this.drugService = new DrugService(database);
            this.drugRepository = new DrugController(database);
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RevisionForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            List<Drug> drugsOnHold = drugService.GetCertainDrugs(DrugStatus.ON_HOLD);
            foreach (Drug drug in drugsOnHold)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = drug._id.ToString();
                row.Cells[1].Value = drug.name;
                row.Cells[2].Value = drugService.IngredientsToString(drug);

                dataGridView1.Rows.Add(row);

            }
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            ChangeDrugStatus(DrugStatus.ACTIVE);
            
        }
        private void ChangeDrugStatus(DrugStatus drugStatus)
        {
            
            Drug drug = drugRepository.FindById(new ObjectId(GetSelectedRow()));
            drug.DrugStatus = drugStatus;
            drugRepository.UpdateDrug(drug);
        }

        private void declineBtn_Click(object sender, EventArgs e)
        {
            ChangeDrugStatus(DrugStatus.DECLINED);
        }

        private void reviseBtn_Click(object sender, EventArgs e)
        {
            
            AddDescriptionForm adf = new AddDescriptionForm(database, new ObjectId(GetSelectedRow()));
            adf.Show();
            ChangeDrugStatus(DrugStatus.CHANGES_REQUIRED);
        }
        private string GetSelectedRow()
        {
            int rowindex = dataGridView1.CurrentRow.Index;
            return (string)dataGridView1.Rows[rowindex].Cells[0].Value;
            
        }
    }
}
