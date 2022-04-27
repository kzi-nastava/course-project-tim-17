using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.RoomModel;
using MongoDB.Driver;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.Enumerations;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.CheckModel;
using MongoDB.Bson;
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

            DoctorController d = new DoctorController(database);


            Apointment ap = new Apointment(new DateTime(),ApointmentType.CHECKUP,new ObjectId("62697f1f2816f31909828195"),new ObjectId("62694f1f2816f31909828195"),new ObjectId("62697f1f2816f31909828193"));
            //ApointmentController apc = new ApointmentController(database);
            //apc.InsertToCollection(ap);
           // Console.WriteLine(ap.doctorId);
            //Doctor dr = d.findById(ap.doctorId);
            //Console.WriteLine(dr.name);
            /*
            Anamnesis an = new Anamnesis("bla", "blabla", "blaa");
            Ingredient i = new Ingredient("sastojak");
            List<Ingredient> sastojci = new List<Ingredient>();
            Drug drug = new Drug("droga", sastojci);
            Prescription pr = new Prescription(drug._id, "kada", 6, Meal.AFTER);
            Check check = new Check(ap._id, an, pr);
            CheckController ch = new CheckController(database);
            ch.InsertToCollection(check);
            */
            
            





            
            
        }
    }
}