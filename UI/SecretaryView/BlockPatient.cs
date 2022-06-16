using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using Autofac;

namespace HealthcareSystem.UI.SecretaryView
{
    internal class BlockPatient
    {
        public UserService userService;

        public BlockPatient()
        {

            UserService userService = Globals.container.Resolve<UserService>();
        }


        public void Block() {
            userService.blockUser();
            Console.WriteLine("Patient is sucessfully blocked! ");

        }

        public void Unblock() {
            userService.unblockUser();
        }



    }
}
