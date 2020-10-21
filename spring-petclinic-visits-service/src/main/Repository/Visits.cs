using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace spring_petclinic_visits_api.Repository {
  internal class Visits : IVisits {
    private readonly ILogger<Visits> _logger;
    private readonly Data.VisitsContext _dbContext;

    public Visits(ILogger<Visits> logger, Data.VisitsContext dbContext) {
      _logger = logger;
      _dbContext = dbContext;
    }

    public Task<List<DTOs.Visit>> FindByPetId(int petId, CancellationToken cancellationToken = default) {
      return _dbContext.Visits.Where(q => q.PetId == petId).ToListAsync(cancellationToken);
    }
    public Task<List<DTOs.Visit>> FindByPetIdIn(int[] petIds, CancellationToken cancellationToken = default) {
      return _dbContext.Visits.Where(q => petIds.Any(r => r == q.PetId)).ToListAsync(cancellationToken);
    }
    public async Task<DTOs.Visit> Save(int petId, DTOs.Visit visit, CancellationToken cancellationToken = default) {
      visit.PetId = petId;

      _dbContext.Visits.Add(visit);
      await _dbContext.SaveChangesAsync(cancellationToken);
      return visit;
    }
  }
}
