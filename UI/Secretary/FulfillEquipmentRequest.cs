using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HealthcareSystem.Entity;
using HealthcareSystem.Entity.RoomModel;
using HealthcareSystem.Entity.RoomModel.RoomFiles;
using HealthcareSystem.Entity.RoomModel.TransferEquipment;
using HealthcareSystem.RoleControllers;

namespace HealthcareSystem.UI.Secretary
{
    class FulfillEquipmentRequest
    {
        
        public EquipmentRequestService equipmentRequestService;
        public RoomService roomService;

        public FulfillEquipmentRequest()
        {

            this.roomService = Globals.container.Resolve<RoomService>();
            this.equipmentRequestService = Globals.container.Resolve<EquipmentRequestService>();
        }

        public void Fulfiil()
        {
            Room warehouse = roomService.getWarehouse();

            List<EquipmentRequest> requests = equipmentRequestService.GetAll();
            foreach (EquipmentRequest req in requests)
            {
                if (req.DateTime < DateTime.Now)
                {
                    foreach (Equipment e in warehouse.equipments)
                    {
                        if (e.item.ToUpper().Equals(req.ItemName.ToUpper()))
                        {
                            e.quantity += req.Quantity;
                            roomService.Update(warehouse);
                            Console.WriteLine("REQUEST " + req._id + " SUCCESFULLY FULFILLED");

                        }
                        equipmentRequestService.Delete(req);

                    }

                }
            }
        }

    }
}
