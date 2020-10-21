using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using spring_petclinic_visits_api.Repository;

namespace spring_petclinic_visits_api.Controllers
{
  [Route("")]
  [ApiController]
  [Produces("application/json")]
  public class VetsController : ControllerBase
  {
    private readonly ILogger<VetsController> _logger;
    private readonly IVisits _visitsRepo;

    public VetsController(ILogger<VetsController> logger, IVisits visitsRepo)
    {
      _logger = logger;
      _visitsRepo = visitsRepo;
    }

    [HttpGet("owners/pets/{petId:int}/visits")]
    [ProducesResponseType(typeof(List<DTOs.Visit>), 200)]
    public async Task<ActionResult<List<DTOs.Visit>>> Visits(int petId, CancellationToken cancellationToken)
    {
      var visits = await _visitsRepo.FindByPetId(petId, cancellationToken);
      return Ok(visits);
    }

    [HttpGet("pets/visits")]
    [ProducesResponseType(typeof(List<DTOs.Visit>), 200)]
    public async Task<ActionResult<List<DTOs.Visit>>> VisitsMultiGet([FromQuery] int[] petId, CancellationToken cancellationToken) {
      var visits = await _visitsRepo.FindByPetIdIn(petId, cancellationToken);
      return Ok(visits);
    }

    [HttpPost("owners/pets/{petId:int}/visits")]
    [ProducesResponseType(201)]
    public async Task<ActionResult> Create(int petId,[FromBody] DTOs.Visit visit, CancellationToken cancellationToken) {
      _logger.LogInformation($"Saving visit {visit}");
      var newVisit = await _visitsRepo.Save(petId, visit, cancellationToken);
      return Created($"owners/pets/{petId}/visits", newVisit);
    }
  }
}
