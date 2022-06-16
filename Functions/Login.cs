using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.UI;
using HealthcareSystem.UI.DoctorView;
using HealthcareSystem.UI.ManagerView;
using Autofac;
using HealthcareSystem.UI.Secretary;
using HealthcareSystem.UI.Patient;


using HealthcareSystem.UI.Patient;

using HealthcareSystem.UI.Secretary;

using MongoDB.Driver;

namespace HealthcareSystem.Functions
{
    class Login

    {

        public UserService userService;

        public DoctorRepository doctorRepository;

        public BlockedUserService blockedUserService { get; set; }

        IMongoDatabase database;

        public Login(IMongoDatabase db) {
            this.doctorRepository = new DoctorRepository();
            this.blockedUserService = Globals.container.Resolve<BlockedUserService>();
            this.userService = Globals.container.Resolve<UserService>();
            this.database = db;
    }

        public int Validate(string email,string password)
        {

            

            User loggedUser = userService.CheckCredentials(email, password);

            if (loggedUser != null) {
                if (blockedUserService.CheckIfBlocked(loggedUser._id) == null)
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
               
                ManagerGUI managerGUI = new ManagerGUI(loggedUser);
                managerGUI.Show();
                
            }else if (loggedUser.role == Role.SECRETARY)
            {
                
                SecretaryControllers secretaryControllers = new SecretaryControllers(database);
               // SecretaryGUI secretaryGUI = new SecretaryGUI(loggedUser, secretaryControllers);
                //secretaryGUI.Show();

                
                SecretaryUI secretaryUI = new SecretaryUI(secretaryControllers, loggedUser, database);
                

            }

            else if(loggedUser.role == Role.DOCTOR) {
                DoctorGUI doctorGUI = new DoctorGUI((Doctor)loggedUser, database);
                doctorGUI.Show();

            }
            else if (loggedUser.role == Role.PATIENT)
            {
                PatientGUI patientGUI = new PatientGUI(loggedUser);
                patientGUI.Show();
            }
        

        }
    }
}

