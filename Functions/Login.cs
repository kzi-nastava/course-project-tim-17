

using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.UI;
using HealthcareSystem.UI.Manager;
using HealthcareSystem.UI.Secretary;
using MongoDB.Driver;

namespace HealthcareSystem.Functions
{
    class Login

    {

        public UserController userRepository;

        public DoctorController doctorRepository;

        public BlockedUserController blockedUserRepository;

        IMongoDatabase database;

        public Login(IMongoDatabase db) {
            this.userRepository = new UserController(db);
            this.doctorRepository = new DoctorController(db);
            this.blockedUserRepository = new BlockedUserController(db);
            this.database = db;
    }

        public int Validate(string email,string password)
        {

            

            User loggedUser = userRepository.CheckCredentials(email, password);

            if (loggedUser != null) {
                if (blockedUserRepository.CheckIfBlocked(loggedUser._id) == null)
                {
                    return 1;
                }

                return 2;
                
            }


            return 0;


        }

        public void SuccessfulLogin(User loggedUser) {
            if (loggedUser.role == Role.MANAGER) {
                ManagerControllers managerControllers = new ManagerControllers(database);
                ManagerGUI managerGUI = new ManagerGUI(loggedUser,managerControllers);
                managerGUI.Show();
                
            }else if (loggedUser.role == Role.SECRETARY)
            {
                
                SecretaryControllers secretaryControllers = new SecretaryControllers(database);
                SecretaryGUI secretaryGUI = new SecretaryGUI(loggedUser, secretaryControllers);
                secretaryGUI.Show();
                
            }

        }
    }
}
