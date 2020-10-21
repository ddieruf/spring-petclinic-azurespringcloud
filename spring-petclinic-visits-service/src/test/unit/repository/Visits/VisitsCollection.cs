
using Xunit;

namespace spring_petclinic_visits_unit_test.Repository.Pets {
  [CollectionDefinition("Visits Test Collection")]
  public class VisitsCollection : ICollectionFixture<VisitsRepo> {
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
  }
}
