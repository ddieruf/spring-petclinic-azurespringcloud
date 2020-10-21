using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using spring_petclinic_customers_api.Data;
using System;

namespace spring_petclinic_customers_unit_test.Repository.Pets
{
  public class PetsRepo : IDisposable {
    public PetsRepo()
    {
      //Create DBContext and warm up data
      var dbContext = new CustomersContext(new DbContextOptionsBuilder<CustomersContext>().UseInMemoryDatabase("PetClinic_Customers").Options);

      dbContext.SeedAll();

      Instance = new spring_petclinic_customers_api.Repository.Pets(
        new NullLogger<spring_petclinic_customers_api.Repository.Pets>(),
        dbContext
      );
    }

    public spring_petclinic_customers_api.Repository.IPets Instance { get; private set; }

    public void Dispose() {
      
    }
  }
}
