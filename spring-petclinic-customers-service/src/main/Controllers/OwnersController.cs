using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using spring_petclinic_customers_api.DTOs;
using spring_petclinic_customers_api.Repository;

namespace spring_petclinic_customers_api.Controllers
{
  [Route("[controller]")]
  [ApiController]
  [Produces("application/json")]
  public class OwnersController : ControllerBase
  {
    private readonly ILogger<OwnersController> _logger;
    private readonly IOwners _ownersRepo;

    public OwnersController(ILogger<OwnersController> logger, IOwners ownersRepo)
    {
      _logger = logger;
      _ownersRepo = ownersRepo;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult> CreateOwner([FromBody] Owner ownerRequest, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"Saving owner {ownerRequest}");
      var owner = await _ownersRepo.Save(ownerRequest, cancellationToken);
      return Created($"owners/{owner.Id}", owner);
    }

    [HttpGet("{ownerId}")]
    [ProducesResponseType(typeof(Owner), 200)]
    public async Task<ActionResult<Owner>> FindOwner(int ownerId, CancellationToken cancellationToken)
    {
      var owner = await _ownersRepo.FindById(ownerId, cancellationToken);
      return Ok(owner);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Owner>), 200)]
    public async Task<ActionResult<List<Owner>>> FindAll(CancellationToken cancellationToken)
    {
      var owner = await _ownersRepo.FindAll(cancellationToken);
      return Ok(owner);
    }

    [HttpPut("{ownerId}")]
    [ProducesResponseType(204)]
    public async Task<ActionResult> ProcessUpdateForm(int ownerId, [FromBody] Owner ownerRequest, CancellationToken cancellationToken)
    {
      var owner = await _ownersRepo.FindById(ownerId, cancellationToken);

      if (owner == null)
        throw new ResourceNotFoundException("Owner " + ownerId + " not found");

      _logger.LogInformation($"Updating owner {ownerRequest}");
      await _ownersRepo.Update(owner, ownerRequest, cancellationToken);

      return NoContent();
    }
  }
}
