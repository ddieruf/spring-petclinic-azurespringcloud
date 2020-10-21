using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace spring_petclinic_vets_api.Repository {
  public interface IVets {
    Task<List<DTOs.Vet>> FindAll(CancellationToken cancellationToken = default);
  }
}
