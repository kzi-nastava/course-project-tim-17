using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;
using Autofac;

namespace HealthcareSystem.UI.Secretary
{
    internal class BlockPatient
    {

        public SecretaryControllers secretaryControllers { get; set; }


        public BlockPatient(SecretaryControllers secretaryControllers)
        {

            this.secretaryControllers = secretaryControllers;
        }


        public void Block() {
            UserService us = Globals.container.Resolve<UserService>();
            us.blockUser();
            Console.WriteLine("Patient is sucessfully blocked! ");

        }

        public void Unblock() {
            UserService us  = Globals.container.Resolve<UserService>();
            us.unblockUser();
        }



    }
}
