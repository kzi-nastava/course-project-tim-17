using HealthcareSystem.Entity.RoomModel.RenovationFiles.MergeRenovation;
using HealthcareSystem.Entity.RoomModel.RenovationFiles.SplitRenovation;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.RoomModel.RenovationFiles
{
    internal interface IRenovationRepository : IRepository<Renovation>
    {
        MergeRoomRenovation GetMergeRenovationByRenovationId(ObjectId id);
        SplitRoomRenovation GetSplitRenovationByRenovationId(ObjectId id);
        MergeRoomRenovation GetMergeRenovationById(ObjectId id);
        SplitRoomRenovation GetSplitRenovationById(ObjectId id);

        void DeleteMergeRenovation(ObjectId id);
        void DeleteSplitRenovation(ObjectId id);

        void InsertMergeRenovation(Renovation renovation, MergeRoomRenovation mergeRoomRenovation);

        void InsertSplitRenovation(Renovation renovation, SplitRoomRenovation splitRoomRenovation);
    }
}
