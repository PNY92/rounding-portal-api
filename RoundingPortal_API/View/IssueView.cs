using RoundingPortal_API.Enum;

namespace RoundingPortal_API.View
{
    public class IssueView
    {
        public string? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Priority { get; set; }

        public string? Workstation { get; set; }

        public string Status { get; set; }

        public string? Reported_Date { get; set; }

        public string? ReporterName { get; set; }

        public string Lab { get; set; }   

    }
}
