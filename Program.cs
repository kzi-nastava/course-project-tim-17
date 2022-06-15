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
using Autofac;
using HealthcareSystem.Entity.RoomModel.RoomFiles;

namespace HealthcareSystem

{
    class Program

    {
        

        static void Main(string[] args)
        {
             Globals.Load();
           
            ApplicationConfiguration.Initialize();

            Application.Run(new LoginGUI(Globals.database));
        }
    }
}