using RoundingPortal_API.Enum;

namespace RoundingPortal_API.Models
{
    public class Issue
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public Workstation? Workstation {  get; set; }

        public Lab Lab { get; set; }

        public User Reporter { get; set; }

        public IssueStatus Status { get; set; }

        public DateTime ReportedDate { get; set; }

        public DateTime SLA {  get; set; }

    }
}
