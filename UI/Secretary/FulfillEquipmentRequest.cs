using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.Entity.RoomModel.TransferEquipment;
using HealthcareSystem.RoleControllers;

namespace HealthcareSystem.UI.Secretary
{
    class FulfillEquipmentRequest
    {
        public SecretaryControllers secretaryControllers { get; set; }


        public FulfillEquipmentRequest(SecretaryControllers secretaryControllers)
        {

            this.secretaryControllers = secretaryControllers;

        }

        public void Fulfiil()
        {
            Room warehouse = secretaryControllers.roomController.getWarehouse();

            List<EquipmentRequest> requests = secretaryControllers.equipmentRequestController.GetAllEquipmentRequests();
            foreach (EquipmentRequest req in requests)
            {
                if (req.DateTime < DateTime.Now)
                {
                    foreach (Equipment e in warehouse.equipments)
                    {
                        if (e.item.ToUpper().Equals(req.ItemName.ToUpper()))
                        {
                            e.quantity += req.Quantity;
                            secretaryControllers.roomController.Update(warehouse);
                            Console.WriteLine("REQUEST " + req._id + " SUCCESFULLY FULFILLED");

                        }
                        secretaryControllers.equipmentRequestController.DeleteEquipmentRequest(req);

                    }

                }
            }
        }

    }
}
