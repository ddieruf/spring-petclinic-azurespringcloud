using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using spring_petclinic_customers_api.Data;
using spring_petclinic_customers_api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace spring_petclinic_customers_api.Repository
{
  internal class Pets : IPets
  {
    private readonly ILogger<Pets> _logger;
    private readonly CustomersContext _dbContext;

    public Pets(ILogger<Pets> logger, CustomersContext dbContext)
    {
      _logger = logger;
      _dbContext = dbContext;
    }

    public Task<List<DTOs.PetType>> FindPetTypes(CancellationToken cancellationToken = default)
    {
      return _dbContext.PetTypes.OrderByDescending(q => q.Name).ToListAsync(cancellationToken);
    }

    public Task<DTOs.PetType> FindPetTypeById(int id, CancellationToken cancellationToken = default)
    {
      return _dbContext.PetTypes.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }


    public Task<DTOs.Pet> FindById(int id, CancellationToken cancellationToken = default)
    {
      return _dbContext.Pets.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public Task<List<DTOs.Pet>> FindAll(CancellationToken cancellationToken = default)
    {
      return _dbContext.Pets.ToListAsync(cancellationToken);
    }

    public Task<List<DTOs.Pet>> FindAll(int page, int pageSize, CancellationToken cancellationToken = default)
    {
      return _dbContext.Pets.Skip(page * pageSize).Take(pageSize).ToListAsync(cancellationToken);
    }

    public async Task<DTOs.Pet> Save(int ownerId, Views.PetRequest petReuqest, CancellationToken cancellationToken = default)
    {

      var owner = await _dbContext.Owners.FirstOrDefaultAsync(q => q.Id == ownerId, cancellationToken);

      if (owner == null)
        throw new ArgumentOutOfRangeException(nameof(ownerId));

      var newPet = new DTOs.Pet()
      {
        BirthDate = petReuqest.BirthDate,
        Id = petReuqest.Id,
        Name = petReuqest.Name,
        OwnerId = ownerId,
        TypeId = petReuqest.PetTypeId
      };

      _dbContext.Pets.Add(newPet);
      await _dbContext.SaveChangesAsync(cancellationToken);
      return newPet;
    }
    public async Task<Pet> Update(int petId, Views.PetRequest petReuqest, CancellationToken cancellationToken = default)
    {
      var pet = await FindById(petId);

      pet.BirthDate = petReuqest.BirthDate ?? pet.BirthDate;
      pet.Name = petReuqest.Name ?? pet.Name;

      _dbContext.Pets.Update(pet);
      await _dbContext.SaveChangesAsync(cancellationToken);
      return pet;
    }
    //public Task Delete(DTOs.Pet pet, CancellationToken cancellationToken = default)
    //{
    //  _dbContext.Pets.Remove(pet);
    //  return _dbContext.SaveChangesAsync(cancellationToken);
    //}
  }
}
