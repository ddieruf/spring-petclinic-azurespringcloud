using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using spring_petclinic_customers_api.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace spring_petclinic_customers_api.Repository
{
  internal class Owners : IOwners
  {
    private readonly ILogger<Owners> _logger;
    private readonly CustomersContext _dbContext;

    public Owners(ILogger<Owners> logger, CustomersContext dbContext)
    {
      _logger = logger;
      _dbContext = dbContext;
    }

    public Task<DTOs.Owner> FindById(int id, CancellationToken cancellationToken = default)
    {
      return _dbContext.Owners.FirstAsync(q => q.Id == id, cancellationToken);
    }

    public Task<List<DTOs.Owner>> FindAll(CancellationToken cancellationToken = default)
    {
      return _dbContext.Owners.ToListAsync(cancellationToken);
    }

    public Task<List<DTOs.Owner>> FindAll(int page, int pageSize, CancellationToken cancellationToken = default)
    {
      return _dbContext.Owners.Skip(page * pageSize).Take(pageSize).ToListAsync(cancellationToken);
    }

    public async Task<DTOs.Owner> Save(DTOs.Owner owner, CancellationToken cancellationToken = default)
    {
      _dbContext.Owners.Add(owner);
      await _dbContext.SaveChangesAsync(cancellationToken);
      return owner;
    }
    public async Task<DTOs.Owner> Update(DTOs.Owner owner, DTOs.Owner newOwnerVals, CancellationToken cancellationToken = default)
    {
      owner.FirstName = newOwnerVals.FirstName ?? owner.FirstName;
      owner.LastName = newOwnerVals.LastName ?? owner.LastName;
      owner.City = newOwnerVals.City ?? owner.City;
      owner.Address = newOwnerVals.Address ?? owner.Address;
      owner.Telephone = newOwnerVals.Telephone ?? owner.Telephone;

      _dbContext.Owners.Update(owner);
      await _dbContext.SaveChangesAsync(cancellationToken);
      return owner;
    }
    public Task Delete(DTOs.Owner Owner, CancellationToken cancellationToken = default)
    {
      _dbContext.Owners.Remove(Owner);
      return _dbContext.SaveChangesAsync(cancellationToken);
    }
  }
}
