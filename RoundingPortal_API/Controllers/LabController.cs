using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoundingPortal_API.Data;
using RoundingPortal_API.Enum;
using RoundingPortal_API.Interfaces;
using RoundingPortal_API.Models;
using RoundingPortal_API.View;

namespace RoundingPortal_API.Controllers
{
    [Route("api/lab")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly ILabRepository _labRepository;
        private readonly IWorkstationRepository _workstationRepository;
        public LabController(ILabRepository labRepository, IWorkstationRepository workstationRepository)
        {
            _labRepository = labRepository;
            _workstationRepository = workstationRepository;
        }

        [Authorize(Roles = "technical_assistant, developer")]
        [HttpGet("getlabs")]
        public async Task<IActionResult> GetAllLabs([FromQuery] Guid? labId) {

            if (labId != null) {
                var labs = await _labRepository.GetLabByIdAsync((Guid) labId);
                return Ok(labs);
            }
            else
            {
                var labs = await _labRepository.GetAllLabsAsync();

                return Ok(labs);
            }
            
        }


        [Authorize(Roles = "developer")]
        [HttpPost("addlab")]
        
        public async Task<IActionResult> AddLab([FromBody] LabView labView)
        {
            if (labView == null)
            {
                return BadRequest("Incorrect format of 'Lab' Object");
            }

            

            Lab lab = new Lab()
            {
                Name = labView.Name,
                Category = (LabCategory) labView.Category,
                Level = labView.Level,
                Id = Guid.NewGuid(),
                MaxSeats = labView.MaxSeats,
                Status = Enum.LabStatus.Not_Completed
            };
            await _labRepository.AddLabAsync(lab);


            foreach (string workstationName in labView.Workstations)
            {
                Workstation newWorkstation = new Workstation()
                {
                    Id = Guid.NewGuid(),
                    Name = workstationName,
                    Lab = lab
                };
                await _workstationRepository.AddWorkstationAsync(newWorkstation);
            }
            return Ok();
        }
    }
}
