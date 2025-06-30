using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundingPortal_API.Enum;
using RoundingPortal_API.Interfaces;
using RoundingPortal_API.Models;
using RoundingPortal_API.View;
using System.Security.Claims;


namespace RoundingPortal_API.Controllers
{
    [Authorize(Roles="developer,technical-assistant")]
    [Route("api/issue")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWorkstationRepository _workstationRepository;
        private readonly ILabRepository _labRepository;
        public IssueController(IWorkstationRepository workstationRepository, IIssueRepository issuerepository, IUserRepository userRepository, ILabRepository labRepository)
        {
            _workstationRepository = workstationRepository;
            _issueRepository = issuerepository;
            _userRepository = userRepository;
            _labRepository = labRepository;
        }

        [HttpGet("getIssues")]
        public async Task<IActionResult> GetAllIssues()
        {
            List<Issue> issues = await _issueRepository.GetAllIssuesAsync();
            List<IssueView> issueView = new List<IssueView>();
            foreach (Issue issue in issues) {

                string status = "";
                string priority = "";

                switch (issue.Priority)
                {
                    case Priority.Low:
                        priority = "Low";
                        break;
                    case Priority.High:
                        priority = "High";
                        break;
                    case Priority.Medium:
                        priority = "Medium";
                        break;
                }
                switch (issue.Status)
                {
                    case IssueStatus.Unsolved:
                        status = "Unsolved";
                        break;
                    case IssueStatus.On_Hold:
                        status = "On-Hold";
                        break;
                    case IssueStatus.In_Progress:
                        status = "In-Progress";
                        break;
                    case IssueStatus.Completed:
                        status = "Completed";
                        break;
                    case IssueStatus.Closed:
                        status = "Closed";
                        break;
                    case IssueStatus.Cancelled:
                        status = "Cancelled";
                        break;

                }

                IssueView newIssueView = new IssueView()
                {
                    Id = issue.Id.ToString(),
                    Description = issue.Description,
                    Priority = priority,
                    Workstation = issue.Workstation?.Name,
                    Title = issue.Title,
                    Status = status,
                    Reported_Date = issue.ReportedDate.ToShortDateString(),
                    ReporterName = issue.Reporter.Name,
                    Lab = issue.Lab.Name
                };
                
                issueView.Add(newIssueView);
            }

            return Ok(issueView);
        }

        [HttpGet("getIssueById")]
        public async Task<IActionResult> GetIssueById([FromQuery] Guid issueId)
        {

            Issue issue = await _issueRepository.GetIssueByIdAsync(issueId);
            string status = "";
            string priority = "";

            switch (issue.Priority)
            {
                case Priority.Low:
                    priority = "Low";
                    break;
                case Priority.High:
                    priority = "High";
                    break;
                case Priority.Medium:
                    priority = "Medium";
                    break;
            }
            switch (issue.Status)
            {
                case IssueStatus.Unsolved:
                    status = "Unsolved";
                    break;
                case IssueStatus.On_Hold:
                    status = "On-Hold";
                    break;
                case IssueStatus.In_Progress:
                    status = "In-Progress";
                    break;
                case IssueStatus.Completed:
                    status = "Completed";
                    break;
                case IssueStatus.Closed:
                    status = "Closed";
                    break;
                case IssueStatus.Cancelled:
                    status = "Cancelled";
                    break;

            }

            IssueView newIssueView = new IssueView()
            {
                Id = issue.Id.ToString(),
                Description = issue.Description,
                Priority = priority,
                Workstation = issue.Workstation?.Name,
                Title = issue.Title,
                Status = status,
                Reported_Date = issue.ReportedDate.ToShortDateString(),
                ReporterName = issue.Reporter.Name,
                Lab = issue.Lab.Name
            };

            return Ok(newIssueView);
        }
        [HttpPost("addIssue")]

        public async Task<IActionResult> AddIssue([FromBody] IssueView issue)
        {
            if (issue == null)
            {
                return BadRequest("Incorrect format of 'Issue' Object");
            }
            User reporter = await _userRepository.GetUserByClaimsAsync(User);
            Workstation? workstation = await _workstationRepository.GetWorkstationByNameAsync(issue.Workstation);
            Lab lab = await _labRepository.GetLabByNameAsync(issue.Lab);
            Priority priority = new Priority();

            if (reporter == null ) {
                return BadRequest("Unable to find the user");
            }
            if (issue.Priority == "high")
            {
                priority = Priority.High;
            }
            else if (issue.Priority == "medium") {
                priority = Priority.Medium;
            }
            else if (issue.Priority == "low")
            {
                priority = Priority.Low;
            }
            Issue newIssue = new Issue()
            {
                Id = Guid.NewGuid(),
                ReportedDate = DateTime.UtcNow,
                Reporter = reporter,
                Description = issue.Description,
                Priority = priority,
                Title = issue.Title,
                Workstation = workstation,
                Lab = lab
            };

            await _issueRepository.AddIssueAsync(newIssue);
            return Ok();
        }
    }
}
