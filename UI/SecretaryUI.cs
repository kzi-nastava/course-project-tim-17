using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.UserModel;
using HealthCareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Driver;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;
using MongoDB.Bson;

namespace HealthcareSystem.UI
{
    class SecretaryUI
    {
        public User loggedUser { get; set; }
        public SecretaryControllers secretaryControllers { get; set; }
        public SecretaryUI(SecretaryControllers secretaryControllers, User loggedUser)
        {
            this.loggedUser = loggedUser;
            this.secretaryControllers = secretaryControllers;
            this.UI();
        }


        public void PrintCRUDMeni()
        {
            Console.WriteLine("a -> CREATE NEW ACCOUNT");
            Console.WriteLine("b -> PREVIEW OF ACCOUNTS");
            Console.WriteLine("c -> UPDATE ACCOUNT");
            Console.WriteLine("d -> DELETE ACCOUNT");
            Console.WriteLine("x - EXIT");

        }

        public void PrintAllPatients(List<User> patients)
        {                                                                          
            for(int i = 0; i < patients.Count; i++)
            {
                if (secretaryControllers.blockedUserController.FindByUserId(patients[i]._id) == null)
                {
                    Console.WriteLine((i + 1).ToString() + ". ");
                    Console.WriteLine(" -----------------------------");
                    Console.WriteLine("Name: " + " " + patients[i].name);
                    Console.WriteLine("Last name: " + " " + patients[i].lastName);
                    Console.WriteLine("Email: " + " " + patients[i].email);
                    HealthCard found = null;
                    List<HealthCard> healthCards = secretaryControllers.healthCardController.getAllHealthCards();
                    foreach (HealthCard healthCard in healthCards)
                    {
                        if (healthCard.patientId == patients[i]._id)
                        {
                            found = healthCard;
                        }

                    }
                    Console.WriteLine("Weight: " + found.weight.ToString());
                    Console.WriteLine("height: " + found.height.ToString());
                    Console.WriteLine();
                }
            }
        }

        public void HandleCRUD(string option)
        {
            UserService us = new UserService(secretaryControllers);
            

            if (option.Equals("a"))                  // ovo bi trebalo da sam zavrsila
            {
                User patient = us.AddUser();
                HealthCardService hc = new HealthCardService(secretaryControllers, patient);
                hc.CreateHealthCard();
                Console.WriteLine("Patient is sucessfully created! ");
            }
            else if (option.Equals("b"))                 // done
            {
                List<User> patients = us.GetAllPatients();
                PrintAllPatients(patients);
            } else if(option.Equals("c")) {              // ovaj dio hm
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
            else if (option.Equals("d"))                         
            {
                User patient = us.DeleteUser();
                HealthCardService hc = new HealthCardService(secretaryControllers, patient);
                hc.DeleteHealthCard();
                Console.WriteLine("Patient is sucessfully deleted! ");
            }
        }


        public void CancelRequest(CheckAppointementRequest cr) {
            cr.status = Status.DENIED;
        }

        public void ApproveRequest(CheckAppointementRequest cr)
        {
            Console.WriteLine(cr.RequestState.ToString());
            cr.status = Status.ACCEPTED;
        }
        public void UI()
        {
            UserService us = new UserService(secretaryControllers);
            CheckAppointmentRequestService crs = new CheckAppointmentRequestService(secretaryControllers);
            while (true)
            {
            Console.WriteLine("1 -> CREATE/READ/UPDATE/DELETE PATIENT'S ACCOUNT");
            Console.WriteLine("2 -> BLOCK PATIENT");
            Console.WriteLine("3 -> OVERVIEW OF BLOCKED PATIENTS");
            Console.WriteLine("4 -> OVERVIEW OF REQUESTS FOR UPDATE/DELETION OF CHECKUPS");
            Console.WriteLine("5 -> LOG OUT");
            Console.WriteLine("Enter option: ");
            string choice = Console.ReadLine();

                if (choice == "1")
                {
                    bool done = false;
                    while (!done)
                    {
                        PrintCRUDMeni();
                        Console.WriteLine("Enter option: ");
                        string option = Console.ReadLine();
                        if (option.Equals("x"))
                        {
                            done = true;
                            break;
                        }
                        else {
                            HandleCRUD(option);
                        }
                    }
                }
                else if (choice == "2") {
                    List<User> patients = us.GetAllPatients();
                    PrintAllPatients(patients);
                    us.blockUser();
                    Console.WriteLine("Patient is sucessfully blocked! ");

                } else if (choice == "3")
                {
                    secretaryControllers.blockedUserController.PrintBlockedUsers();
                    Console.WriteLine("Enter '1' to unblock a patient: ");
                    string response = Console.ReadLine();
                    if (response.Equals("1")){
                        us.unblockUser();
                    }
              
                }
                else if(choice == "4")
                {
                    crs.printAllRequests();
                    Console.WriteLine("Enter request id: ");
                    ObjectId obI = ObjectId.Parse(Console.ReadLine());
                    CheckAppointementRequest cr = secretaryControllers.checkAppointemtRequestController.FindById(obI);
                    Console.WriteLine("1 -> APPROVE REQUEST");
                    Console.WriteLine("2 -> DECLINE REQUEST");
                    string opt = Console.ReadLine();
                    if (opt.Equals("1"))
                    {
                        cr.status = Status.ACCEPTED;
                        crs.Update(cr);
                       
                    }
                    else if (opt.Equals("2"))
                    {

                        cr.status = Status.DENIED;
                        crs.Update(cr);
                    }

                }
                else if (choice == "5") {
                    break;

                }
            }

        }

    }
}
