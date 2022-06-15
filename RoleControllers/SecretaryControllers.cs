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

        public UserController userController;
        public HealthCardController healthCardController;
        public BlockedUserController blockedUserController;
        public CheckAppointmentRequestController checkAppointemtRequestController;
        public AppointmentRequestsController appointmentRequestsController;
        public RoomRepository roomController;
        public ApointmentController AppointmentController;
        public CheckController checkController;
        public ReferralController referralController;
        public DoctorController doctorController;
        public EquipmentRequestController equipmentRequestController;
        public SecretaryControllers(IMongoDatabase database)
        {
            this.userController = new UserController(database);
            this.healthCardController = new HealthCardController(database);
            this.blockedUserController = new BlockedUserController(database);
            this.checkAppointemtRequestController = new CheckAppointmentRequestController(database);
            this.AppointmentController = new ApointmentController(database);
            this.roomController = new RoomRepository();
            this.appointmentRequestsController = new AppointmentRequestsController(database);
            this.checkController = new CheckController(database);
            this.referralController = new ReferralController(database);
            this.doctorController = new DoctorController(database);
            this.equipmentRequestController = new EquipmentRequestController(database);
        }
    }
}
