using RoundingPortal_API.Enum;
using RoundingPortal_API.Models;

namespace RoundingPortal_API.View
{
    public class WorkstationRecordView
    {
        public Guid Id { get; set; }
        public string Workstation { get; set; }
        public string? Rounder { get; set; }

        public WorkstationStatus Display { get; set; }

        public WorkstationStatus Mouse_Keyboard { get; set; }
        public WorkstationStatus Kensington_Lock { get; set; }
        public WorkstationStatus Conduiting { get; set; }
        public WorkstationStatus Tidiness { get; set; }

        public WorkstationStatus Boot_To_Windows { get; set; }

        public WorkstationStatus Domain { get; set; }

        public WorkstationStatus Microsoft_Office { get; set; }

        public WorkstationStatus Microsoft_Teams { get; set; }
        public WorkstationStatus Browser { get; set; }

        public WorkstationStatus DeepFreeze_Frozen { get; set; }
        public string DeepFreeze_Policy { get; set; }
        public string? Timestamp { get; set; }

        public Shift? Shift { get; set; }
    }
}
