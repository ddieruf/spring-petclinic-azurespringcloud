using spring_petclinic_visits_api.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace spring_petclinic_visits_api.Repository {
  public interface IVisits {
    Task<List<Visit>> FindByPetId(int petId, CancellationToken cancellationToken = default);
    Task<List<Visit>> FindByPetIdIn(int[] petIds, CancellationToken cancellationToken = default);
    Task<DTOs.Visit> Save(int petId, DTOs.Visit visit, CancellationToken cancellationToken = default);
  }
}
