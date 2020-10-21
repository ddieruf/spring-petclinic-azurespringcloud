using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using spring_petclinic_vets_api.Repository;

namespace spring_petclinic_vets_api.Controllers
{
  [Route("[controller]")]
  [ApiController]
  [Produces("application/json")]
  public class VetsController : ControllerBase
  {
    private readonly ILogger<VetsController> _logger;
    private readonly IVets _vetsRepo;

    public VetsController(ILogger<VetsController> logger, IVets vetsRepo)
    {
      _logger = logger;
      _vetsRepo = vetsRepo;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<DTOs.Vet>), 200)]
    public async Task<ActionResult<List<DTOs.Vet>>> ShowResourcesVetList(CancellationToken cancellationToken)
    {
      var vets = await _vetsRepo.FindAll(cancellationToken);
      return Ok(vets);
    }
  }
}
