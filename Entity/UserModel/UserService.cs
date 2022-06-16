using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.ReferralModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Driver;


namespace HealthCareSystem.Entity.UserModel
{
    class UserService
    {

        public SecretaryControllers secretaryControllers { get; set; }

        public UserService(SecretaryControllers sc)
        {
            this.secretaryControllers = sc;
        }

        public User AddUser()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter role: ");
            Role role = (Role)Enum.Parse(typeof(Role), Console.ReadLine());
            User user = new User(name, lastName, email, password, role);
            secretaryControllers.userController.InsertToCollection(user);
            return user;
        }


        public User AddPatient()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            Role role = Role.PATIENT;
            User user = new User(name, lastName, email, password, role);
            if (!doesUserExist(email, password))
            {
                secretaryControllers.userController.InsertToCollection(user);
                return user;
            }
            return null;

        }

        public List<User> GetAllPatients()
        {
            List<User> patients = secretaryControllers.userController.userCollection.Find(item => item.role == Role.PATIENT).ToList();
            return patients;
        }





        public User DeleteUser()
        {
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            User u = secretaryControllers.userController.FindByEmail(email);
            if (u != null)
            {
                BlockedUser b = secretaryControllers.blockedUserController.CheckIfBlocked(u._id);
                if (b != null)
                {
                    secretaryControllers.blockedUserController.Delete(u._id);
                }
                secretaryControllers.userController.DeleteFromCollection(u._id);
                secretaryControllers.AppointmentController.DeleteApointmentByPatientId(u._id);
                return u;
            }
            return null;
        }

        public User UpdateUser()
        {
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            User u = secretaryControllers.userController.FindByEmail(email);
            Console.WriteLine("1 -> Edit name");
            Console.WriteLine("2 -> Edit lastname");
            Console.WriteLine("3 -> Edit email");
            Console.WriteLine("4 -> Edit password");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Enter new name: ");
                u.name = Console.ReadLine();
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter new lastname: ");
                u.lastName = Console.ReadLine();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Enter new email: ");
                u.email = Console.ReadLine();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Enter new password: ");
                u.password = Console.ReadLine();
            }

            secretaryControllers.userController.Update(u);
            return u;
        }

        public void blockUser()
        {
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            User u = secretaryControllers.userController.FindByEmail(email);
            BlockedUser blockedUser = new BlockedUser(u._id, BlockedBy.SECRETARY);
            secretaryControllers.blockedUserController.Insert(blockedUser);

        }


        public void unblockUser()
        {
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            User u = secretaryControllers.userController.FindByEmail(email);
            BlockedUser bu = secretaryControllers.blockedUserController.GetByUserId(u._id);
            secretaryControllers.blockedUserController.Delete(bu._id);

        }


        public bool doesUserExist(string email, string password)
        {
            User u = secretaryControllers.userController.CheckCredentials(email, password);
            if (u != null)
            {
                return true;
            }
            return false;
        }



        public void PrintAllPatients(List<User> patients)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (secretaryControllers.blockedUserController.GetByUserId(patients[i]._id) == null)
                {
                    Console.WriteLine(" ------------------------------------");
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
                    Console.WriteLine("Allergies: " + secretaryControllers.healthCardController.GetAllergies(found));
                }
            }
        }

        public void PrintPatientsWithReferrals(List<User> patients)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (secretaryControllers.blockedUserController.GetByUserId(patients[i]._id) == null)
                {
                    Console.WriteLine(" ------------------------------------");
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
                    List<Referral> referrals = secretaryControllers.referralController.GetReferralsOfHealthCard(found);
                    if (referrals.Count > 0)
                    {
                        Console.WriteLine("REFERRALS:");
                        foreach (Referral r in referrals)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Referral's id: " + r._id);
                            Console.WriteLine("------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Patient has no referrals");
                    }
                }
            }


        }
    }



    }


