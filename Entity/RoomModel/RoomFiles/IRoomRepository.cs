using HealthcareSystem.Entity.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.RoomModel.RoomFiles
{
    internal interface IRoomRepository : IRepository<Room>
    {
        Room getWarehouse();
        Room GetByNameAndType(string roomName, RoomType roomType);


    }
}
