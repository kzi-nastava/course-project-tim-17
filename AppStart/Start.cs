using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.RoomModel;
using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.HealthCardModel;
using MongoDB.Bson;
namespace HealthcareSystem.AppStart;



static class Start
{

    public static void ProgramStart()
    {

  
        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Tim17:UXGhApWVw9oc6VGg@cluster0.se6mz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase("USI");
        /*
        DoctorController d = new DoctorController(database);


        Apointment ap = new Apointment(new DateTime(), ApointmentType.CHECKUP, new ObjectId("62697f1f2816f31909828195"), new ObjectId("62694f1f2816f31909828195"), new ObjectId("62697f1f2816f31909828193"));
        //ApointmentController apc = new ApointmentController(database);
        //apc.InsertToCollection(ap);
        // Console.WriteLine(ap.doctorId);
        //Doctor dr = d.findById(ap.doctorId);
        //Console.WriteLine(dr.name);

        Anamnesis an = new Anamnesis("ahahahh", "blablahaah", "ahahahah");
        Ingredient i = new Ingredient("sastojak");
        List<Ingredient> sastojci = new List<Ingredient>();
        Drug drug = new Drug("droga", sastojci);
        Prescription pr = new Prescription(drug._id, "kada", 6, Meal.AFTER);
        Check check = new Check(ap._id, an, pr);
        // CheckController ch = new CheckController(database);
        // ch.InsertToCollection(check);
        HealthCardController hc = new HealthCardController(database);
        HealthCard hchchchhc = hc.findById(new ObjectId("6269a92255413fe82e5e8e27"));
        Console.WriteLine(hchchchhc.height);
        */


        DoctorController controller = new DoctorController(database);
        //List<Doctor> useri = controller.doctorCollection.Find(Item => true).ToList();

        UserController userController = new UserController(database);
        DoctorController dc = new DoctorController(database);

        Console.WriteLine("Unesite Vas email: ");
        string newEmail = Console.ReadLine();
        Console.WriteLine("Unesite Vas password: ");
        string newPassword = Console.ReadLine();

        var loggedUser = userController.checkCredentials(newEmail, newPassword);

        if (loggedUser == null)
        {
            loggedUser = dc.checkCredentials(newEmail, newPassword);
        }
        if (loggedUser != null)
        {
            Console.WriteLine(loggedUser.name);
        }







    }

}
