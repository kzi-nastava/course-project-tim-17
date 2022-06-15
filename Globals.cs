using Autofac;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem
{
    public static class Globals
    {
        public static IContainer container;
        public static IMongoDatabase database; 
        public static void Load()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ProgramModule>();
            container = containerBuilder.Build();

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Tim17:UXGhApWVw9oc6VGg@cluster0.se6mz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            database = client.GetDatabase("USI");
        }
    }
}
