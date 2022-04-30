using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.HealthCardModel;
using HealthcareSystem.Entity.UserModel;
using MongoDB.Driver;

namespace HealthcareSystem.RoleControllers
{
    class SecretaryControllers
    {

        public UserController userController;
        public HealthCardController healthCardController;
        public BlockedUserController blockedUserController;



        public SecretaryControllers(IMongoDatabase database) {
            this.userController = new UserController(database);
            this.healthCardController = new HealthCardController(database);
            this.blockedUserController = new BlockedUserController(database);

        }
    }
}
