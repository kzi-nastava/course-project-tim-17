using HealthcareSystem.Entity;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.RoleControllers;
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
    partial class PerfomeCheckupForm : Form
    {
        public HealthCardService healthCardService;
        public CheckService checkService;
        public DrugService drugService;
        public HealthCard patientHealthCard;
        public Appointment appointment;
        public PerfomeCheckupForm(Appointment appointment, HealthCard patientHealthCard)
        {
            InitializeComponent();
            this.appointment = appointment;
            this.patientHealthCard = patientHealthCard;
            this.healthCardService = Globals.container.Resolve<HealthCardService>();
            this.checkService = Globals.container.Resolve<CheckService>();
            this.drugService = Globals.container.Resolve<DrugService>();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            Anamnesis anamnesis = GetAnamnesis();
            Drug drug = GetDrug();
            Prescription prescription = GetPrescription(drug);
            if (drug == null)
            {
                warningMessageLabel.Text = "Drug does not exist!";
                warningMessageLabel.Visible = true;
            }
            else if (IsAlergic(drug))
            {
                warningMessageLabel.Text = "Drug contains ingredients that patient is allergic to!";
                warningMessageLabel.Visible = true;
            }
            else
            {
                Check check = new Check(appointment._id, anamnesis, prescription);
                patientHealthCard.checks.Add(check._id);
                healthCardService.Update(patientHealthCard);
                checkService.Instert(check);
                MessageBox.Show("Appointment is finished!");
                UpdateDynamicEquimptentForm updateDynamicEquimptentForm = new UpdateDynamicEquimptentForm(appointment);
                updateDynamicEquimptentForm.Show();
                this.Dispose();

            }

        }

        private bool IsAlergic(Drug drug)
        {
            foreach(Ingredient ingredient in patientHealthCard.allergies)
            {
                foreach(Ingredient ingredientInDrug in drug.ingredients)
                {
                    if (ingredientInDrug.name == ingredient.name)
                    {
                        Console.WriteLine("Jeste");
                        return true;
                        
                    }
                }
            }
            return false;
        }

        private Prescription GetPrescription(Drug drug)
        {
            Drug drugForPerscription = drug;
            string when = whenTextBox.Text;
            int quantityPerDay = Int32.Parse(quantityTextBox.Text);
            Meal meal = GetMeal();
            return new Prescription(drugForPerscription._id, when, quantityPerDay, meal); 



        }

        private Meal GetMeal()
        {
            if (afferRadioBtn.Checked)
            {
                return Meal.AFTER;
            }
            else if (duringRadioBtn.Checked)
            {
                return Meal.DURING;
            }
            else if (dontMatterRadioBtn.Checked)
            {
                return Meal.DOESNOTMATTER;
            }
            return Meal.BEFORE;
        }

        private Anamnesis GetAnamnesis()
        {
            string desctription = desctriptionTextBox.Text;
            string symptoms = symptomsTextBox.Text;
            string diagnosis = diagnosisTextBox.Text;
            return new Anamnesis(desctription, symptoms, diagnosis);
        }
        private Drug GetDrug()
        {
            Drug drug = drugService.FindDrugByName(drugNameTextBox.Text);
            return drug;

        }

        private void PerfomeCheckupForm_Load(object sender, EventArgs e)
        {

        }
    }
}
