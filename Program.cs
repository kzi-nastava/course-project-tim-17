using HealthcareSystem.Entity.Drug;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.Room;
using MongoDB.Driver;
using HealthcareSystem.Entity.User;
using HealthcareSystem.Entity.Enumerations;
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

            UserController userController = new UserController(database);

            

            RoomController r = new RoomController(database);

            List<Equipment> equipments = new List<Equipment>();
            Equipment e1 = new Equipment("STOLICA", "BIJELA", 10);
            equipments.Add(e1);
            Equipment e2 = new Equipment("STO", "BIJELI", 10);
            equipments.Add(e2);
            Equipment e3 = new Equipment("Krevet", "Za jednu osobu", 15);
            equipments.Add(e3);


            Room room = new Room("operacija", equipments);

            r.InsertToCollection(room);
            r.getAllDrugs();
        }
    }
}