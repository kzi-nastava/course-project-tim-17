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
using Autofac;
using HealthcareSystem.Entity.ApointmentModel;
using MongoDB.Bson;

namespace HealthcareSystem.Entity.UserModel
{
    class UserService
    {
        public IUserRepository userRepository;
        public IHealthCardRepository healthCardRepository;
        public BlockedUserController blockedUserRepository;

        public UserService(IUserRepository userRepository, IHealthCardRepository healthCardRepository)
        {
            this.userRepository = userRepository;
            this.healthCardRepository = healthCardRepository;
            this.blockedUserRepository = new BlockedUserController(Globals.database);
            
            
        }

        public User Add()
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
            userRepository.Insert(user);
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
                userRepository.Insert(user);
                return user;
            }
            return null;

        }

        public List<User> GetAll()
        {

            return userRepository.GetAll();
        }

        public List<User> GetAllPatients()
        {
            return userRepository.GetAllPatients();
        }
        public User GetById(ObjectId id)
        {
            return userRepository.GetById(id);
        }


        public User GetByEmail(string email)
        {
            return userRepository.GetByEmail(email);
        }

        public User CheckCredentials(string email, string password)
        {
            return userRepository.CheckCredentials(email, password);
        }


        public User DeleteUser()
        {
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            User u = GetByEmail(email);
            
            if (u != null)
            {
                BlockedUser b = blockedUserRepository.CheckIfBlocked(u._id);
                if (b != null)
                {
                    blockedUserRepository.Unblock(u._id);
                }
                userRepository.Delete(u._id);
                new AppointmentRepository().DeleteApointmentByPatientId(u._id);
                return u;
            }
            return null;
        }

        public User UpdateUser()
        {
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            User u = GetByEmail(email);
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

            userRepository.Update(u);
            return u;
        }

        public User GetByNameAndLastName(string name, string lastName)
        {
            return userRepository.GetByNameAndLastName(name, lastName);
        }

        public void blockUser()
        {
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            User u = GetByEmail(email);
            BlockedUser blockedUser = new BlockedUser(u._id, BlockedBy.SECRETARY);
            blockedUserRepository.InsertToCollection(blockedUser);

        }


        public void unblockUser()
        {
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            User u = GetByEmail(email);
            BlockedUser bu = blockedUserRepository.FindByUserId(u._id);
            blockedUserRepository.Unblock(bu._id);

        }


        public bool doesUserExist(string email, string password)
        {
            User u = userRepository.CheckCredentials(email, password);
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
                if (blockedUserRepository.FindByUserId(patients[i]._id) == null)
                {
                    Console.WriteLine(" ------------------------------------");
                    Console.WriteLine("Name: " + " " + patients[i].name);
                    Console.WriteLine("Last name: " + " " + patients[i].lastName);
                    Console.WriteLine("Email: " + " " + patients[i].email);
                    HealthCard found = null;
                    List<HealthCard> healthCards = healthCardRepository.GetAll();
                    foreach (HealthCard healthCard in healthCards)
                    {
                        if (healthCard.patientId == patients[i]._id)
                        {
                            found = healthCard;
                        }
                    }
                    Console.WriteLine("Weight: " + found.weight.ToString());
                    Console.WriteLine("height: " + found.height.ToString());
                    Console.WriteLine("Allergies: " + Globals.container.Resolve<HealthCardService>().GetAllergies(found));
                }
            }
        }

        public void PrintPatientsWithReferrals(List<User> patients)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (blockedUserRepository.FindByUserId(patients[i]._id) == null)
                {
                    Console.WriteLine(" ------------------------------------");
                    Console.WriteLine("Name: " + " " + patients[i].name);
                    Console.WriteLine("Last name: " + " " + patients[i].lastName);
                    Console.WriteLine("Email: " + " " + patients[i].email);
                    HealthCard found = null;
                    List<HealthCard> healthCards = healthCardRepository.GetAll();
                    foreach (HealthCard healthCard in healthCards)
                    {

                        if (healthCard.patientId == patients[i]._id)
                        {
                            found = healthCard;
                        }
                    }
                    ReferralRepository rr = new ReferralRepository();
                    List<Referral> referrals = rr.GetReferralsOfHealthCard(found);
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


