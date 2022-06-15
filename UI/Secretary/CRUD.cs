using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using HealthCareSystem.Entity.UserModel;

namespace HealthcareSystem.UI.Secretary
{
    class CRUD
    {
        public SecretaryControllers secretaryControllers { get; set; }


        public CRUD(SecretaryControllers secretaryControllers)
        {

            this.secretaryControllers = secretaryControllers;

        }

        public void HandleCRUD(string option)
        {
            UserService us = new UserService(secretaryControllers);
            if (option.Equals("a"))
            {                                                                // adding patient
                User patient = us.AddPatient();
                if (patient != null)
                {
                    HealthCardService hc = new HealthCardService(secretaryControllers, patient);
                    hc.CreateHealthCard();
                    Console.WriteLine("Patient is sucessfully created! ");
                }
                else
                {
                    Console.WriteLine("Sorry, patient already exists! ");
                }
            }
            else if (option.Equals("b"))                                                         // preview of patients 
            {
                List<User> patients = us.GetAllPatients();
                us.PrintAllPatients(patients);
            }
            else if (option.Equals("c"))
            {                                                                            // update patient
                User patient = us.UpdateUser();
                HealthCardService hc = new HealthCardService(secretaryControllers, patient);
                Console.WriteLine("To edit patient's healthcard enter '1': ");
                string toEdit = Console.ReadLine();
                if (toEdit.Equals("1"))
                {
                    hc.UpdateHealthCard();
                }
                Console.WriteLine("Patient is sucessfully updated! ");
            }
            else if (option.Equals("d"))                            // delete patient        
            {
                User patient = us.DeleteUser();
                if (patient != null)
                {
                    HealthCardService hc = new HealthCardService(secretaryControllers, patient);
                    hc.DeleteHealthCard();
                    Console.WriteLine("Patient is sucessfully deleted! ");
                }
                else
                {
                    Console.WriteLine("Sorry, patient with entered email does not exist! ");
                }
            }
        }
    }
}
