using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using NuGet.Protocol;
using RoundingPortal_API.Interfaces;
using RoundingPortal_API.Models;
using RoundingPortal_API.Repositories;
using RoundingPortal_API.View;

namespace RoundingPortal_API.Controllers
{
    [Authorize(Roles = "developer,technical-assistant")]
    [Route("api/workstation")]
    [ApiController]
    public class WorkstationController : ControllerBase
    {
        private readonly IWorkstationRepository _workstationRepository;

        private readonly ILabRepository _labRepository;
        public WorkstationController(IWorkstationRepository workstationRepository, ILabRepository labRepository)
        {
            _workstationRepository = workstationRepository;
            _labRepository = labRepository;
        }

        [HttpGet("getworkstations")]
        public async Task<IActionResult> GetAllWorkstations([FromQuery] Guid? labId)
        {
            List<Workstation> workstations = await _workstationRepository.GetAllWorkstationsAsync();


            if (labId != null)
            {
                workstations = workstations.Where((workstation) => workstation.Lab.Id == labId).ToList();
            }
            return Ok(workstations);
        }

        [HttpPost("addworkstation")]

        public async Task<IActionResult> AddLab([FromBody] WorkstationView workstationView)
        {

            if (workstationView == null)
            {
                return BadRequest("Incorrect format of 'Workstation' Object");
            }

            Lab lab = await _labRepository.GetLabByNameAsync(workstationView.Lab);

            if (lab == null)
            {
                return BadRequest("Couldn't find the lab");
            }

            Workstation workstation = new Workstation
            {
                Id = Guid.NewGuid(),
                Name = workstationView.Name,
                Lab = lab,
            };

            await _workstationRepository.AddWorkstationAsync(workstation);
            return Ok();
        }
    }
}
