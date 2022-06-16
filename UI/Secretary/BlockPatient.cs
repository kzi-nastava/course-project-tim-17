using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity.UserModel;
using HealthcareSystem.RoleControllers;

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
            UserService us = new UserService(secretaryControllers);
            us.blockUser();
            Console.WriteLine("Patient is sucessfully blocked! ");

        }

        public void Unblock() {
            UserService us = new UserService(secretaryControllers);
            us.unblockUser();
        }



    }
}
