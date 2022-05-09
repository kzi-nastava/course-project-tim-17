

using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.UI;
using HealthcareSystem.UI.DoctorView;
using HealthcareSystem.UI.Manager;
<<<<<<< HEAD
using HealthcareSystem.UI.Patient;
=======
using HealthcareSystem.UI.Secretary;
>>>>>>> angie2
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

            loggedUser = doctorRepository.checkCredentials(email, password);
            if(loggedUser != null)
            {
                return 3;
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
<<<<<<< HEAD
            else if(loggedUser.role == Role.DOCTOR) {
                DoctorRepositories doctorRepositories = new DoctorRepositories(database);
                DoctorGUI doctorGUI = new DoctorGUI((Doctor)loggedUser, doctorRepositories);
                doctorGUI.Show();

            }
            else if (loggedUser.role == Role.PATIENT)
            {
                PatientRepositories patientRepositories = new PatientRepositories(database);
                PatientGUI patientGUI = new PatientGUI(loggedUser, patientRepositories);
                patientGUI.Show();
            }
        
=======

>>>>>>> angie2
        }
    }
}
