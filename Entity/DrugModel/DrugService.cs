using HealthcareSystem.Entity.Enumerations;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.DrugModel
{  
    class DrugService
    {
        public IDrugRepository drugRepository;
        public DrugService(IDrugRepository drugRepository)
        {
            this.drugRepository = drugRepository;
        }
        public void Insert(Drug drug)
        {
            drugRepository.Insert(drug);
        }
        public void Update(Drug drug)
        {
            drugRepository.Update(drug);
        }
        public Drug GetById(string id)
        {
            return drugRepository.GetById(new ObjectId(id));
        }

        public List<Drug> GetCertainDrugs(DrugStatus drugStatus)
        {
            List<Drug> allDrugs = drugRepository.GetAll();
            List<Drug> certainDrugs = new List<Drug>();
            foreach(Drug drug in allDrugs)
            {
                if (drug.DrugStatus == drugStatus)
                {
                    certainDrugs.Add(drug);
                }
            }
            return certainDrugs;

        }
        public string IngredientsToString(Drug drug)
        {
            string ingredients = "";
            foreach(Ingredient ingredient in drug.ingredients)
            {
                ingredients += ingredient.name + ", ";
                
            }
            if (ingredients.Length > 0)
            {
               ingredients = ingredients.Remove(ingredients.Length - 1);
            }
            return ingredients;
        }
    }
}
