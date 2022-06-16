using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.ReferralModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.HealthCardModel
{
    class HealthCardService
    {

       public IHealthCardRepository healthCardRepository { get; set; }  

        public HealthCardService(IHealthCardRepository healthCardRepository)
        {
             this.healthCardRepository = healthCardRepository;
           
        }
        public void Update(HealthCard healthCard)
        {
            healthCardRepository.Update(healthCard);
        }
        public List<HealthCard> GetAll()
        {
            return healthCardRepository.GetAll();
        }
        public HealthCard GetByPatientId(ObjectId id)
        {
            return healthCardRepository.FindByPatientId(id);
        }
        public void CreateHealthCard(User patient)
        {
            Console.WriteLine("Enter patient's height: ");
            double height = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter patient's weight: ");
            double weight = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter '1' if patient has allergies: ");
            List<Ingredient> ingredients = new List<Ingredient>();
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Enter patients allergies(separate them with coma): ");
                string allergies = Console.ReadLine();
                string[] splitted = allergies.Split(',');

                foreach (string s in splitted)
                {
                    ingredients.Add(new Ingredient(s));
                }
            }
            HealthCard hc = new HealthCard(height, weight, patient._id, ingredients);

            healthCardRepository.Insert(hc);

        }

        public void DeleteHealthCard(User patient)
        {
            List<HealthCard> healthCards = healthCardRepository.GetAll();
            foreach (HealthCard healthCard in healthCards)
            {
                if (healthCard.patientId == patient._id)
                {
                    healthCardRepository.Delete(healthCard._id);
                }

            }

        }


        public void UpdateHealthCard(User patient)
        {
            Console.WriteLine("1 -> Edit height");
            Console.WriteLine("2 -> Edit weight");
            Console.WriteLine("3 -> Add allergy");
            HealthCard found = null;
            List<HealthCard> healthCards = healthCardRepository.GetAll();
            foreach (HealthCard healthCard in healthCards)
            {
                if (healthCard.patientId == patient._id)
                {
                    found = healthCard;
                }

            }
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Enter new value for height: ");
                found.height = Double.Parse(Console.ReadLine());
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter new value for weight: ");
                found.weight = Double.Parse(Console.ReadLine());

            }
            else if (choice == "3")
            {
                Console.WriteLine("Enter new allergy: ");
                Ingredient a = new Ingredient(Console.ReadLine());
                found.allergies.Add(a);
            }

            healthCardRepository.Update(found);


        }

     /*

        public List<Referral> getReferrals(HealthCard healthCard)
        {
            List<Referral> referrals = new List<Referral>();
            List<ObjectId> ids = healthCard.referrals;
            foreach (ObjectId id in ids)
            {
                referrals.Add(secretaryControllers.referralController.findById(id));
            }

            return referrals;
        }

        public void addRefferral(HealthCard healthCard, Doctor doctor, Referral r)
        {

            healthCard.referrals.Add(r._id);
            secretaryControllers.healthCardController.healthCardCollection.ReplaceOne(item => item._id == healthCard._id, healthCard);
        }
     */
        public string GetAllergies(HealthCard h)
        {
            string gatheredAllergies = "";
            List<Ingredient> allergies = h.allergies;
            foreach (Ingredient a in allergies)
            {
                if (a != null)
                {
                    gatheredAllergies += a.name + ";";
                }
            }
            if (gatheredAllergies != "")
            {
                return gatheredAllergies;
            }
            else
            {
                return "None";
            }


        }
    }


}
