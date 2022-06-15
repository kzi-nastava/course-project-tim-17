using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.RoleControllers;

namespace HealthcareSystem.UI.Secretary
{

    class TransferEquipment { 
          public SecretaryControllers secretaryControllers { get; set; }


        public TransferEquipment(SecretaryControllers secretaryControllers)
        {

            this.secretaryControllers = secretaryControllers;

        }

        public void Transfer(Room from, Room to, String ItemName)
        {
            Equipment e = from.equipments.Where(e => e.item.ToUpper() == ItemName.ToUpper()).FirstOrDefault();
            Console.WriteLine("Max quantity you can enter is: " + e.quantity);
            int enteredQuantity = Int32.Parse(Console.ReadLine());
            while (enteredQuantity > e.quantity)
            {
                Console.WriteLine("Not possible. Please enter again: ");
                enteredQuantity = Int32.Parse(Console.ReadLine());
            }
            foreach (Equipment eq in from.equipments)
            {
                if (eq.item.ToUpper().Equals(ItemName.ToUpper()))
                {
                    eq.quantity -= enteredQuantity;
                    secretaryControllers.roomController.Update(from);
                }
            }
            foreach (Equipment eq in to.equipments)
            {
                if (eq.item.ToUpper().Equals(ItemName.ToUpper()))
                {
                    eq.quantity += enteredQuantity;
                    secretaryControllers.roomController.Update(to);
                }
            }

            Console.WriteLine("Sucessfully transfered! ");
        }

    }
}
