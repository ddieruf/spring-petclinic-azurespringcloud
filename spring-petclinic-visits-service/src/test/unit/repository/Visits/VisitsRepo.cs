using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using spring_petclinic_visits_api.Data;
using System;

namespace spring_petclinic_visits_unit_test.Repository
{
  public class VisitsRepo : IDisposable {
    public VisitsRepo()
    {
      //Create DBContext and warm up data
      var dbContext = new VisitsContext(new DbContextOptionsBuilder<VisitsContext>().UseInMemoryDatabase("PetClinic_Visits").Options);

      dbContext.SeedAll();

      Instance = new spring_petclinic_visits_api.Repository.Visits(
        new NullLogger<spring_petclinic_visits_api.Repository.Visits>(),
        dbContext
      );
    }

    public spring_petclinic_visits_api.Repository.IVisits Instance { get; private set; }

    public void Dispose() {
      
    }
  }
}
