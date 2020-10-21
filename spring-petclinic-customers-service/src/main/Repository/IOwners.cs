using spring_petclinic_customers_api.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace spring_petclinic_customers_api.Repository
{
  public interface IOwners
  {
    Task Delete(Owner Owner, CancellationToken cancellationToken = default);
    Task<List<Owner>> FindAll(CancellationToken cancellationToken = default);
    Task<List<Owner>> FindAll(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<Owner> FindById(int id, CancellationToken cancellationToken = default);
    Task<Owner> Save(Owner Owner, CancellationToken cancellationToken = default);
    Task<DTOs.Owner> Update(DTOs.Owner owner, DTOs.Owner newOwnerVals, CancellationToken cancellationToken = default);
  }
}
