using spring_petclinic_customers_api.DTOs;
using spring_petclinic_customers_api.Views;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace spring_petclinic_customers_api.Repository
{
  public interface IPets
  {
    //Task Delete(Pet pet, CancellationToken cancellationToken = default);
    Task<List<Pet>> FindAll(CancellationToken cancellationToken = default);
    Task<List<Pet>> FindAll(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<Pet> FindById(int id, CancellationToken cancellationToken = default);
    Task<PetType> FindPetTypeById(int id, CancellationToken cancellationToken = default);
    Task<List<PetType>> FindPetTypes(CancellationToken cancellationToken = default);
    Task<Pet> Save(int ownerId, PetRequest petReuqest, CancellationToken cancellationToken = default);
    Task<Pet> Update(int petId, Views.PetRequest petReuqest, CancellationToken cancellationToken = default);
  }
}
