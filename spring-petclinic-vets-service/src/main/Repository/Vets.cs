using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace spring_petclinic_vets_api.Repository {
  internal class Vets : IVets {
    private readonly ILogger<Vets> _logger;
    private readonly Data.VetsContext _dbContext;

    public Vets(ILogger<Vets> logger, Data.VetsContext dbContext) {
      _logger = logger;
      _dbContext = dbContext;
    }

    public Task<List<DTOs.Vet>> FindAll(CancellationToken cancellationToken = default) {
      return _dbContext.Vets.ToListAsync(cancellationToken);
    }
  }
}
