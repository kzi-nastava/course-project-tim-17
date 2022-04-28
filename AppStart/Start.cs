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
       
        
        MoveEquipmentRequest mer = new MoveEquipmentRequest(new DateOnly(),new ObjectId("626a71c6500e4e92266aef9e"),new ObjectId("626a71c6200e4e92266aef9e"),new Equipment(EquipmentType.FURNITURE,"Chair",3,false));
        MoveEquipmentRequestController merc = new MoveEquipmentRequestController(database);
        merc.InsertToCollection(mer);

    }

}
