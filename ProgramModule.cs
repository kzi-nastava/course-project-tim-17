using Autofac;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.DrugModel;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.RoomModel.MoveEquipmentFiles;
using HealthcareSystem.Entity.RoomModel.RenovationFiles;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;
using HealthCareSystem.Entity.CheckAppointementRequestModel;
using HealthcareSystem.Entity.RoomModel.TransferEquipment;

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
            builder.RegisterType<HealthCardRepository>().As<IHealthCardRepository>();
            builder.RegisterType<HealthCardService>().AsSelf();
            builder.RegisterType<AppointmentRequestsRepository>().As<IAppointmentRequestRepository>();
            builder.RegisterType<AppointmentRequestsService>().AsSelf();
            builder.RegisterType<CheckAppointmentRequestRepository>().As<ICheckAppointmentRequestRepository>();
            builder.RegisterType<CheckAppointmentRequestService>().AsSelf();
            builder.RegisterType<EquipmentRequestRepository>().As<IEquipmentRequestRepository>();
            builder.RegisterType<EquipmentRequestService>().AsSelf();
        }
    }
}
