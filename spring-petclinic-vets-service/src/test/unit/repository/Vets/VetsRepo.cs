using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using spring_petclinic_vets_api.Data;
using System;

namespace spring_petclinic_vets_unit_test.Repository.Pets
{
  public class VetsRepo : IDisposable {
    public VetsRepo()
    {
      //Create DBContext and warm up data
      var dbContext = new VetsContext(new DbContextOptionsBuilder<VetsContext>().UseInMemoryDatabase("PetClinic_Vets").Options);

      dbContext.SeedAll();

      Instance = new spring_petclinic_vets_api.Repository.Vets(
        new NullLogger<spring_petclinic_vets_api.Repository.Vets>(),
        dbContext
      );
    }

    public spring_petclinic_vets_api.Repository.IVets Instance { get; private set; }

    public void Dispose() {
      
    }
  }
}
