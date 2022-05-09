using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Driver;

namespace HealthcareSystem.Entity.HealthCardModel
{
    class HealthCardService
    {

        public User patient;
        public SecretaryControllers secretaryControllers { get; set; }

        public HealthCardService(SecretaryControllers sc, User patient)
        {
            this.secretaryControllers = sc;
            this.patient = patient;
        }

        public void CreateHealthCard()
        {
            Console.WriteLine("Enter patient's height: ");
            double height = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter patient's weight: ");
            double weight = Double.Parse(Console.ReadLine());
            HealthCard hc = new HealthCard(height, weight, this.patient._id);
            
            secretaryControllers.healthCardController.InsertToCollection(hc);

        }

        public void DeleteHealthCard()
        {
            List<HealthCard> healthCards =secretaryControllers.healthCardController.getAllHealthCards();
            foreach (HealthCard healthCard in healthCards)
            {
                if (healthCard.patientId == this.patient._id)
                {
                    secretaryControllers.healthCardController.deleteHealthCard(healthCard);
                }

            }

        }


        public void UpdateHealthCard()
        { 
            Console.WriteLine("1 -> Edit height");
            Console.WriteLine("2 -> Edit weight");
            HealthCard found = null; 
            List<HealthCard> healthCards = secretaryControllers.healthCardController.getAllHealthCards();
            foreach (HealthCard healthCard in healthCards)
            {
                if (healthCard.patientId == this.patient._id)
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

            secretaryControllers.healthCardController.update(found);

            
        }
    }
        

}
