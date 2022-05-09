using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using MongoDB.Driver;


namespace HealthCareSystem.Entity.UserModel
{
    class UserService
    {

        public SecretaryControllers secretaryControllers { get; set; }

        public UserService(SecretaryControllers sc) {
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
            secretaryControllers.userController.DeleteFromCollection(u._id);
            return u;
        }

        public User UpdateUser() {
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
            } else if (choice == "2")
            {
                Console.WriteLine("Enter new lastname: ");
                u.lastName = Console.ReadLine();
            } else if (choice == "3")
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
            secretaryControllers.blockedUserController.InsertToCollection(blockedUser);

        }


        public void unblockUser() {
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            User u = secretaryControllers.userController.FindByEmail(email);
            BlockedUser bu = secretaryControllers.blockedUserController.FindByUserId(u._id);
            secretaryControllers.blockedUserController.Unblock(bu._id);

        }
    }

    
}


