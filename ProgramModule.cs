using Autofac;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.RoomModel.MoveEquipmentFiles;
using HealthcareSystem.Entity.RoomModel.RenovationFiles;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem
{
    internal class ProgramModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RoomRepository>().As<IRoomRepository>();
            builder.RegisterType<MoveEquipmentRepository>().As<IMoveEquipmentRepository>();
            builder.RegisterType<RenovationRepository>().As<IRenovationRepository>();
            builder.RegisterType<RoomService>().AsSelf();
            builder.RegisterType<DrugRepository>().As<IDrugRepository>();
            builder.RegisterType<DrugService>().AsSelf();
            builder.RegisterType<AppointmentRepository>().As<IAppointmentRepository>();
            builder.RegisterType<AppointmentService>().AsSelf();
        }
    }
}
