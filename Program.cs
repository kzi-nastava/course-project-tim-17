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



            
            
        }
    }
}