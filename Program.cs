using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Functions;
using HealthcareSystem.RoleControllers;
using HealthcareSystem.UI;
using MongoDB.Driver;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using MongoDB.Bson;

using HealthcareSystem.Entity.UserActionModel;
namespace HealthcareSystem

{
    class Program
    {
        static void Main(string[] args)

        {

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Tim17:UXGhApWVw9oc6VGg@cluster0.se6mz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("USI");
            UserController uc = new UserController(database);
            HealthCardController hc = new HealthCardController(database);


            User loggedUser = null;
            Boolean notLogged = true;
            string choice = "";

            ApplicationConfiguration.Initialize();

            Application.Run(new LoginGUI(database));





        }
    }
}