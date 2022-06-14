using HealthcareSystem.Entity.RoomModel.RenovationFiles.MergeRenovation;
using HealthcareSystem.Entity.RoomModel.RenovationFiles.SplitRenovation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareSystem.Entity.RoomModel.RenovationFiles
{
    internal class RenovationService
    {
        public IRenovationRepository renovationReposotory;

        public RenovationService(IRenovationRepository renovationRepository)
        {
            renovationReposotory = renovationRepository;
        }

        public void Insert(Renovation renovation)
        {
            renovationReposotory.Insert(renovation);
        }

        public void InsertMergeRenovation(Renovation renovation,MergeRoomRenovation mrr)
        {
            renovationReposotory.InsertMergeRenovation(renovation, mrr);
        }
        public void InsertSplitRenovation(Renovation r, SplitRoomRenovation srr)
        {
            renovationReposotory.InsertSplitRenovation(r, srr);
        }
    }
}
