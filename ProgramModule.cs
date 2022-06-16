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
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.ReferralModel;
using HealthcareSystem.Entity.Survey.DoctorSurvey;
using HealthcareSystem.Entity.Survey.HospitalSurvey;
using HealthcareSystem.Entity.Survey;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.Entity.NotificationModel;

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
            builder.RegisterType<CheckRepository>().As<ICheckRepository>();
            builder.RegisterType<CheckService>().AsSelf();
            builder.RegisterType<FreeDayRequestRepository>().As<IFreeDayRequestRepository>();
            builder.RegisterType<FreeDayRequestService>().AsSelf();
            builder.RegisterType<ReferralRepository>().As<IReferralRepository>();
            builder.RegisterType<ReferralService>().AsSelf();
            builder.RegisterType<DoctorRepository>().As<IDoctorRepository>();
            builder.RegisterType<DoctorService>().AsSelf();
            builder.RegisterType<RevisionRepository>().As<IRevisionRepository>();
            builder.RegisterType<RevisionService>().AsSelf();
            builder.RegisterType<DoctorSurveysRepository>().As<IDoctorSurveysRepository>();
            builder.RegisterType<HospitalSurveysRepository>().As<IHospitalSurveysRepository>();
            builder.RegisterType<SurveyService>().AsSelf();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().AsSelf();
            builder.RegisterType<NotificationFreeDayRepository>().As<INotificationFreeDayRepository>();
            builder.RegisterType<NotificationFreeDayService>().AsSelf();
        }
    }
}
