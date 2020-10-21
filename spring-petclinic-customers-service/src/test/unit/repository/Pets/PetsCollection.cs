
using Xunit;

namespace spring_petclinic_customers_unit_test.Repository.Pets {
  [CollectionDefinition("Pets Test Collection")]
  public class PetsCollection : ICollectionFixture<PetsRepo> {
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
  }
}
