
using Xunit;

namespace spring_petclinic_vets_unit_test.Repository.Pets {
  [CollectionDefinition("Vets Test Collection")]
  public class VetsCollection : ICollectionFixture<VetsRepo> {
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
  }
}
