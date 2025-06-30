using System.Text.Json.Nodes;

namespace RoundingPortal_API.View
{
    public class LabView
    {
        public string Name {  get; set; }
        public int MaxSeats { get; set; }
        public string Status { get; set; }
        public int Category { get; set; }
        public int Level { get; set; }

        public string[]? Workstations { get; set; }
    }
}
