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
using HealthcareSystem.Functions;

namespace HealthcareSystem.AppStart;



static class Start
{

    public static void ProgramStart()
    {
    

  
        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Tim17:UXGhApWVw9oc6VGg@cluster0.se6mz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase("USI");


        Revision rev = new Revision("NIsta ne znas jebem te usta", new ObjectId("626a60715522d32768c66fef"));
        RevisionController revc = new RevisionController(database);
        revc.InsertToCollection(rev);

    }

}
