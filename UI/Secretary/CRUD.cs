using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.Entity.UserModel;
using Autofac;
namespace HealthcareSystem.UI.Secretary
{
    class CRUD
    {
        public SecretaryControllers secretaryControllers { get; set; }
        public HealthCardService healthCardService { get; set; }

        public CRUD(SecretaryControllers secretaryControllers)
        {

            this.secretaryControllers = secretaryControllers;
            this.healthCardService = Globals.container.Resolve<HealthCardService>();
        }

        public void Add() {
            UserService us = new UserService(secretaryControllers);
            User patient = us.AddPatient();
            if (patient != null)
            {

                healthCardService.CreateHealthCard(patient);
                Console.WriteLine("Patient is sucessfully created! ");
            }
            else
            {
                Console.WriteLine("Sorry, patient already exists! ");
            }

        }

        public void Update() {
            UserService us = new UserService(secretaryControllers);
            User patient = us.UpdateUser();
            Console.WriteLine("To edit patient's healthcard enter '1': ");
            string toEdit = Console.ReadLine();
            if (toEdit.Equals("1"))
            {
                healthCardService.UpdateHealthCard(patient);
            }
            Console.WriteLine("Patient is sucessfully updated! ");
        }

        public void Delete() {
            UserService us = new UserService(secretaryControllers);
            User patient = us.DeleteUser();
            if (patient != null)
            {

                healthCardService.DeleteHealthCard(patient);
                Console.WriteLine("Patient is sucessfully deleted! ");
            }
            else
            {
                Console.WriteLine("Sorry, patient with entered email does not exist! ");
            }

        }

        public void HandleCRUD(string option)
        {
            UserService us = new UserService(secretaryControllers);
            if (option.Equals("a"))
            {                                                              
                Add();
            }
            else if (option.Equals("b"))                                                        
            {
                List<User> patients = us.GetAllPatients();
                us.PrintAllPatients(patients);
            }

            else if (option.Equals("c"))
            {                                                                         
                Update();
            }

            else if (option.Equals("d"))                           
            {
                Delete();
            }
        }
    }
}
