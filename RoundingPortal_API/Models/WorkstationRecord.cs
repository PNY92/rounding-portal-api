using RoundingPortal_API.Enum;

namespace RoundingPortal_API.Models
{
    public class WorkstationRecord
    {
        public Guid Id { get; set; }
        public Workstation Workstation { get; set; }

        public User Rounder { get; set; }

        public WorkstationStatus Display {  get; set; }

        public WorkstationStatus Mouse_Keyboard { get; set; }
        public WorkstationStatus Kensington_Lock { get; set; }
        public WorkstationStatus Conduiting { get; set; }
        public WorkstationStatus Tidiness { get; set; }

        public WorkstationStatus Boot_To_Windows { get; set; }

        public WorkstationStatus Domain {  get; set; }

        public WorkstationStatus Microsoft_Office { get; set; }

        public WorkstationStatus Microsoft_Teams { get; set; }
        public WorkstationStatus Browser { get; set; }

        public WorkstationStatus DeepFreeze_Frozen { get; set; }
        public string DeepFreeze_Policy { get; set; }
        public DateTime Timestamp { get; set; }

        public Shift Shift { get; set; }
    }
}
