using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoundingPortal_API.Enum;
using RoundingPortal_API.Interfaces;
using RoundingPortal_API.Models;
using RoundingPortal_API.Repositories;
using RoundingPortal_API.View;

namespace RoundingPortal_API.Controllers
{
    [Authorize(Roles = "developer,technical-assistant")]
    [Route("api/workstationRecord")]
    [ApiController]
    public class WorkstationRecordController : Controller
    {

        private readonly IWorkstationRecordRepository _workstationRecordRepository;
        private readonly IWorkstationRepository _workstationRepository;
        private readonly IUserRepository _userRepository;


        public WorkstationRecordController(IWorkstationRecordRepository workstationRecordRepository, IWorkstationRepository workstationRepository, IUserRepository userRepository)
        {
            _workstationRecordRepository = workstationRecordRepository;
            _workstationRepository = workstationRepository;
            _userRepository = userRepository;
        }

        [HttpGet("getRecords")]
        public async Task<IActionResult> GetRecords([FromQuery] Guid? labId, [FromQuery] Guid? workstationId)
        {
            List<WorkstationRecord> workstationRecords = new List<WorkstationRecord>();
            List<WorkstationRecordView> workstationRecordsView = new List<WorkstationRecordView>();

            if (labId != null) {
                workstationRecords = await _workstationRecordRepository.GetAllWorkstationRecordsByLabAsync((Guid) labId);
                
            }
            else if (workstationId != null)
            {
                workstationRecords = await _workstationRecordRepository.GetWorkstationRecordsByWorkstationAsync((Guid) workstationId);
            }
            else
            {
                workstationRecords = await _workstationRecordRepository.GetAllWorkstationRecordsAsync();
            }

            foreach (WorkstationRecord record in workstationRecords)
            {
                WorkstationRecordView newView = new WorkstationRecordView
                {
                    Rounder = record.Rounder.Name,
                    Workstation = record.Workstation.Name,
                    Id = record.Id,
                    Boot_To_Windows = record.Boot_To_Windows,
                    Browser = record.Browser,
                    Conduiting = record.Conduiting,
                    DeepFreeze_Frozen = record.DeepFreeze_Frozen,
                    DeepFreeze_Policy = record.DeepFreeze_Policy,
                    Display = record.Display,
                    Domain = record.Domain,
                    Kensington_Lock = record.Kensington_Lock,
                    Microsoft_Office = record.Microsoft_Office,
                    Microsoft_Teams = record.Microsoft_Teams,
                    Mouse_Keyboard = record.Mouse_Keyboard,
                    Shift = record.Shift,
                    Tidiness = record.Tidiness,
                    Timestamp = record.Timestamp.ToShortDateString()
                };

                workstationRecordsView.Add(newView);
            }
            
            return Ok(workstationRecordsView) ;
        }

        [HttpPost("addRecord")]

        public async Task<IActionResult> AddRecord([FromBody] WorkstationRecordView workstationRecordView)
        {
            Workstation workstation = await _workstationRepository.GetWorkstationByNameAsync(workstationRecordView.Workstation);
            WorkstationRecord workstationRecord = new WorkstationRecord
            {
                Id = Guid.NewGuid(),
                Workstation = workstation,
                Rounder = await _userRepository.GetUserByClaimsAsync(User),
                Boot_To_Windows = workstationRecordView.Boot_To_Windows,
                Browser = workstationRecordView.Browser,
                Conduiting = workstationRecordView.Conduiting,
                DeepFreeze_Frozen = workstationRecordView.DeepFreeze_Frozen,
                DeepFreeze_Policy = workstationRecordView.DeepFreeze_Policy,
                Display = workstationRecordView.Display,
                Domain = workstationRecordView.Domain,
                Kensington_Lock = workstationRecordView.Kensington_Lock,
                Microsoft_Office = workstationRecordView.Microsoft_Office,
                Microsoft_Teams = workstationRecordView.Microsoft_Teams,
                Mouse_Keyboard = workstationRecordView.Mouse_Keyboard,
                Tidiness = workstationRecordView.Tidiness,
                Timestamp = DateTime.Now
            };

            await _workstationRecordRepository.AddWorkstationRecordAsync(workstationRecord);

            return Ok("Completed");
        }
    }
}
