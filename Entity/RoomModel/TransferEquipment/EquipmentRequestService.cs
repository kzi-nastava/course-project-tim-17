using HealthcareSystem.Entity.Enumerations;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.RoomModel.TransferEquipment
{
    class EquipmentRequestService
    {
        public EquipmentRequestController equipmentRequestController;
        public EquipmentRequestService(IMongoDatabase database)
        {
            this.equipmentRequestController = new EquipmentRequestController(database);

        }

        public void PrintAllEquipmentRequest(List<EquipmentRequest> requests)
        {
            Console.WriteLine("READY REQUESTS");
            Console.WriteLine("-----------------------------");
            foreach (EquipmentRequest req in requests)
            {
                if (req.DateTime < DateTime.Now)
                {
                    Console.WriteLine("ID: " + req._id);
                    Console.WriteLine("ITEM: " + req.ItemName);
                    Console.WriteLine("DATE: " + req.DateTime);
                    Console.WriteLine("QUANTITY: " + req.Quantity.ToString());
                }
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("REQUESTS YET TO BE FULFILLED");
            Console.WriteLine("-----------------------------");
            foreach (EquipmentRequest req in requests)
            {
                if (req.DateTime >= DateTime.Now)
                {
                    Console.WriteLine("ITEM: " + req.ItemName);
                    Console.WriteLine("DATE: " + req.DateTime);
                    Console.WriteLine("QUANTITY: " + req.Quantity.ToString());
                }
            }
            Console.WriteLine("-----------------------------");
        }

        public void MakeEquipmentRequest()
        {
            Console.WriteLine("Enter the item name you are making request for: ");
            String itemName = Console.ReadLine();
            Console.WriteLine("Enter the quantity: ");
            int quantity = Int32.Parse(Console.ReadLine());
            DateTime date = DateTime.Now.AddDays(1);
            EquipmentRequest er = new EquipmentRequest(itemName, date, quantity);
            equipmentRequestController.InsertToCollection(er);

        }
    }
}
