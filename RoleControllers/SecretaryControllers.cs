using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.ApointmentModel;
using HealthcareSystem.Entity.AppointmentRequestsModel;
using HealthcareSystem.Entity.CheckAppointmentRequestModel;
using HealthcareSystem.Entity.CheckModel;
using HealthcareSystem.Entity.DoctorModel;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.ReferralModel;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.Entity.RoomModel.TransferEquipment;
using HealthcareSystem.Entity.UserModel;
using MongoDB.Driver;

namespace HealthcareSystem.RoleControllers
{
    class SecretaryControllers
    {

        public UserRepository userController;
        public HealthCardRepository healthCardController;
        public BlockedUserController blockedUserController;
        public CheckAppointmentRequestRepository checkAppointemtRequestController;
        public AppointmentRequestsRepository appointmentRequestsController;
        public RoomRepository roomController;
        public AppointmentRepository AppointmentController;
        public CheckRepository checkController;
        public ReferralRepository referralController;
        public DoctorRepository doctorController;
        public EquipmentRequestRepository equipmentRequestController;
        public SecretaryControllers(IMongoDatabase database)
        {
            this.userController = new UserRepository();
            this.healthCardController = new HealthCardRepository();
            this.blockedUserController = new BlockedUserController(database);
            this.AppointmentController = new AppointmentRepository();
            this.roomController = new RoomRepository();
            this.appointmentRequestsController = new AppointmentRequestsRepository();

            this.checkController = new CheckRepository();
            this.referralController = new ReferralRepository();
            this.doctorController = new DoctorRepository();
            this.equipmentRequestController = new EquipmentRequestRepository();
        }
    }
}
