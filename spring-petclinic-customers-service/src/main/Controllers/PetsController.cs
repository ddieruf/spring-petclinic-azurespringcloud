using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using spring_petclinic_customers_api.DTOs;
using spring_petclinic_customers_api.Repository;
using spring_petclinic_customers_api.Views;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace spring_petclinic_customers_api.Controllers
{
  [Route("")]
  [ApiController]
  [Produces("application/json")]
  public class PetsController : ControllerBase
  {
    private readonly IPets _petsRepo;
    private readonly ILogger<PetsController> _logger;
    private readonly IOwners _ownersRepo;

    public PetsController(ILogger<PetsController> logger, IPets petsRepo, IOwners ownersRepo)
    {
      _petsRepo = petsRepo;
      _logger = logger;
      _ownersRepo = ownersRepo;
    }

    [HttpGet("petTypes")]
    [ProducesResponseType(typeof(List<PetType>), 200)]
    public async Task<ActionResult<List<PetType>>> GetPetTypes(CancellationToken cancellationToken)
    {
      var ret = await _petsRepo.FindPetTypes(cancellationToken);
      return Ok(ret);
    }

    [HttpGet("owners/pets/{petId}")]
    [ProducesResponseType(typeof(PetDetails), 200)]
    public async Task<ActionResult<PetDetails>> FindPet(int petId, CancellationToken cancellationToken)
    {
      var pet = await _petsRepo.FindById(petId, cancellationToken);

      if (pet == null)
        throw new ResourceNotFoundException("Pet " + petId + " not found");

      var ret = new PetDetails(pet);

      return Ok(ret);
    }

    [HttpPost("owners/{ownerId}/pets")]
    [ProducesResponseType(typeof(Pet), 201)]
    [ProducesResponseType(typeof(ResourceNotFoundException), 404)]
    public async Task<ActionResult<Pet>> ProcessCreationForm(int ownerId, [FromBody] PetRequest petRequest, CancellationToken cancellationToken)
    {
      var owner = await _ownersRepo.FindById(ownerId, cancellationToken);

      if (owner == null)
        throw new ResourceNotFoundException("Owner " + ownerId + " not found");

      //var pet = new Pet();
      //owner.AddPet(pet);

      _logger.LogInformation($"Saving pet {petRequest}");
      var newPet = await _petsRepo.Save(ownerId, petRequest, cancellationToken);

      return Created($"owners/pets/{newPet.Id}", newPet);
    }

    [HttpPut("owners/pets/{petId}")]
    [ProducesResponseType(204)]
    public async Task<ActionResult> ProcessUpdateForm(int petId, [FromBody] PetRequest petRequest, CancellationToken cancellationToken)
    {
      var pet = await _petsRepo.FindById(petId, cancellationToken);

      if (pet == null)
        throw new ResourceNotFoundException("Pet " + petId + " not found");

      _logger.LogInformation($"Updating pet {petRequest}");
      await _petsRepo.Update(petId, petRequest, cancellationToken);

      return NoContent();
    }
  }
}
